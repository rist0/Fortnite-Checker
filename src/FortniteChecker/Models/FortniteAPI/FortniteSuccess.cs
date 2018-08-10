using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FortniteChecker.Models.FortniteAPI
{
    class FortniteSuccess
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public long ExpiresIn { get; set; }

        [JsonProperty("expires_at")]
        public DateTimeOffset ExpiresAt { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("refresh_expires")]
        public long RefreshExpires { get; set; }

        [JsonProperty("refresh_expires_at")]
        public DateTimeOffset RefreshExpiresAt { get; set; }

        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("internal_client")]
        public bool InternalClient { get; set; }

        [JsonProperty("client_service")]
        public string ClientService { get; set; }

        [JsonProperty("lastPasswordValidation")]
        public DateTimeOffset LastPasswordValidation { get; set; }

        [JsonProperty("perms")]
        public List<Perm> Perms { get; set; }

        [JsonProperty("app")]
        public string App { get; set; }

        [JsonProperty("in_app_id")]
        public string InAppId { get; set; }
    }

    public class Perm
    {
        [JsonProperty("resource")]
        public string Resource { get; set; }

        [JsonProperty("action")]
        public long Action { get; set; }
    }
}
