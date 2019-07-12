using Newtonsoft.Json;

namespace WHMCS_2019.Orders
{
    public class CancelRequestResponse
    {
        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("serviceid")]
        public int Status { get; set; }

        [JsonProperty("userid")]
        public int WhoIs { get; set; }
    }
}
