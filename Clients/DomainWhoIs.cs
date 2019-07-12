using Newtonsoft.Json;

namespace WHMCS.Clients
{
    public class DomainWhoIs
    {

        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("whois")]
        public string WhoIs { get; set; }
    }
}
