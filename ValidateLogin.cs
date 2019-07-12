using Newtonsoft.Json;

namespace WHMCS.Login
{
    public class LoginDetails
    {

        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("userid")]
        public int UserID { get; set; }

        [JsonProperty("contactid")]
        public int ContactID { get; set; }

        [JsonProperty("passwordhash")]
        public string PasswordHash { get; set; }
    }
}
