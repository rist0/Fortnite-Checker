using System.Collections.Generic;
using Newtonsoft.Json;

namespace FortniteChecker.Models.FortniteAPI
{
    class FortniteError
    {
        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }

        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }

        [JsonProperty("messageVars")]
        public List<string> MessageVars { get; set; }

        [JsonProperty("numericErrorCode")]
        public long NumericErrorCode { get; set; }

        [JsonProperty("originatingService")]
        public string OriginatingService { get; set; }

        [JsonProperty("intent")]
        public string Intent { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
