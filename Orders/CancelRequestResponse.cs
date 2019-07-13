using Newtonsoft.Json;

namespace WHMCS.Orders
{
    public class CancelRequestResponse
    {
        /// <summary>
        /// The result of the operation: success or error.
        /// </summary>
        [JsonProperty("result")]
        public string Result { get; set; }

        /// <summary>
        /// The id of the service the request was for
        /// </summary>
        [JsonProperty("serviceid")]
        public int Status { get; set; }

        /// <summary>
        /// The id of the user the service belongs to
        /// </summary>
        [JsonProperty("userid")]
        public int WhoIs { get; set; }
    }
}
