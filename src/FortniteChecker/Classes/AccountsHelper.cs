using System.Collections.Generic;
using System.IO;
using FortniteChecker.Models;

namespace FortniteChecker.Classes
{
    static class AccountsHelper
    {
        public static List<FortniteAccount> ValidateAndLoadAccounts(IEnumerable<string> files)
        {
            var accounts = new List<FortniteAccount>();

            foreach (var file in files)
            {
                var lines = File.ReadAllLines(file);

                // NOTE: These are the most common separators
                var accountDelimiters = new[]
                {
                    ':',
                    ';',
                    '|',
                    ','
                };

                foreach (var line in lines)
                {
                    var separatedAccount = line.Split(accountDelimiters);

                    var account = new FortniteAccount();

                    if (separatedAccount.Length != 2)
                    {
                        continue;
                    }

                    account.EmailAddress = separatedAccount[0];
                    account.Password = separatedAccount[1];

                    accounts.Add(account);
                }
            }

            return accounts;
        }
    }
}
