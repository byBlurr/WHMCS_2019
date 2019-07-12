using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHMCS
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
