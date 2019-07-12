using Newtonsoft.Json;
using System.Collections.Generic;

namespace WHMCS.Clients
{
    public class Clients
    {
        [JsonProperty("client")]
        public IList<Client> Client { get; set; }
    }

    public class ClientsInfo
    {
        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("totalresults")]
        public int TotalResult { get; set; }

        [JsonProperty("startnumber")]
        public int StartNumber { get; set; }

        [JsonProperty("numreturned")]
        public int NumReturned { get; set; }

        [JsonProperty("clients")]
        public Clients Clients { get; set; }
    }
}
