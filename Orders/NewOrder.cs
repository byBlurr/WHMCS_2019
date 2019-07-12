using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace WHMCS_2019.Orders
{
    public class NewOrder
    {
        public readonly NameValueCollection OrderDetails;

        // TODO: Holy shit theres a lot to do here.
        public NewOrder()
        {
        }
    }

    public class OrderIds
    {
        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("orderid")]
        public int OrderId { get; set; }

        [JsonProperty("productids")]
        public string ProductIds { get; set; }

        [JsonProperty("addonids")]
        public string AddonIds { get; set; }

        [JsonProperty("domainids")]
        public string DomainIds { get; set; }

        [JsonProperty("invoiceid")]
        public int InvoiceId { get; set; }
    }
}
