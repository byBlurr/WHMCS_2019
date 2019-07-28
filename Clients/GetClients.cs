using Newtonsoft.Json;
using System.Collections.Generic;

namespace WHMCS.Clients
{
    public class AClient
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("companyname")]
        public string CompanyName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("datecreated")]
        public string DateCreated { get; set; }

        [JsonProperty("groupid")]
        public int GroupId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class AllClients
    {
        [JsonProperty("client")]
        public IList<AClient> Clients { get; set; }
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
        public AllClients Clients { get; set; }
    }
}
