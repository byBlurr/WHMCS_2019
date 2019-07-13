using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using WHMCS;

namespace WHMCS.Orders
{
    public class NewOrder
    {
        public readonly NameValueCollection OrderDetails;
        
        public NewOrder(string PaymentMethod, int[] ProductIds = null, string[] Domains = null, string[] BillingCycles = null, string[] DomainTypes = null, int[] RegistrationPeriods = null, string[] EppCodes = null, string Nameserver1 = "", string Nameserver2 = "", string Nameserver3 = "", string Nameserver4 = "", string Nameserver5 = "", string[] CustomFields = null, string[] ConfigOptions = null, float[] PriceOverride = null, string PromoCode = "", bool PromoOverride = false, int AffiliateId = -1, bool NoInvoice = false, bool NoInvoiceEmail = false, bool NoEmail = false, string[] Addons = null, string[] Hostname = null, string[] Ns1Prefix = null, string[] Ns2Prefix = null, string[] RootPassword = null, int ContactId = -1, bool[] DnsManagement = null, string[] DomainFields = null, bool[] EmailForwarding = null, bool[] IdProtection = null, float[] DomainPriceOverride = null, float[] DomainRenewOverride = null, /*array DomainRenewals = null,*/ string ClientIp = "", int AddonId = -1, int ServiceId = -1, int[] AddonIds = null, int[] ServiceIds = null)
        {
            OrderDetails = new NameValueCollection()
            {
                { EnumUtil.GetString(APIEnums.AddOrderParams.PaymentMethod), PaymentMethod.ToString() },
                { EnumUtil.GetString(APIEnums.AddOrderParams.PromoOverride), PromoOverride.ToString() },
                { EnumUtil.GetString(APIEnums.AddOrderParams.NoInvoice), NoInvoice.ToString() },
                { EnumUtil.GetString(APIEnums.AddOrderParams.NoInvoiceEmail), NoInvoiceEmail.ToString() },
                { EnumUtil.GetString(APIEnums.AddOrderParams.NoEmail), NoEmail.ToString() },
            };

            if (ProductIds != null) OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.ProductIds), ProductIds.ToString());
            if (Domains != null) OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.Domains), Domains.ToString());
            if (BillingCycles != null) OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.BillingCycles), BillingCycles.ToString());
            if (DomainTypes != null) OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.DomainTypes), DomainTypes.ToString());
            if (RegistrationPeriods != null) OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.RegistrationPeriods), RegistrationPeriods.ToString());
            if (EppCodes != null) OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.EppCodes), EppCodes.ToString());
            if (Nameserver1 != "") OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.Nameserver1), Nameserver1.ToString());
            if (Nameserver2 != "") OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.Nameserver2), Nameserver2.ToString());
            if (Nameserver3 != "") OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.Nameserver3), Nameserver3.ToString());
            if (Nameserver4 != "") OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.Nameserver4), Nameserver4.ToString());
            if (Nameserver5 != "") OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.Nameserver5), Nameserver5.ToString());
            if (CustomFields != null) OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.CustomFields), CustomFields.ToString());
            if (ConfigOptions != null) OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.ConfigOptions), ConfigOptions.ToString());
            if (PriceOverride != null) OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.PriceOverride), PriceOverride.ToString());
            if (PromoCode != "") OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.PromoCode), PromoCode.ToString());
            if (AffiliateId != -1) OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.AffiliateId), AffiliateId.ToString());
            if (Addons != null) OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.Addons), Addons.ToString());
            if (Hostname != null) OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.Hostname), Hostname.ToString());
            if (Ns1Prefix != null) OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.Ns1Prefix), Ns1Prefix.ToString());
            if (Ns2Prefix != null) OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.Ns2Prefix), Ns2Prefix.ToString());
            if (RootPassword != null) OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.RootPassword), RootPassword.ToString());
            if (ContactId != -1) OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.ContactId), ContactId.ToString());
            if (DnsManagement != null) OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.DnsManagement), DnsManagement.ToString());
            if (DomainFields != null) OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.DomainFields), DomainFields.ToString());
            if (EmailForwarding != null) OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.EmailForwarding), EmailForwarding.ToString());
            if (IdProtection != null) OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.IdProtection), IdProtection.ToString());
            if (DomainPriceOverride != null) OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.DomainPriceOverride), DomainPriceOverride.ToString());
            if (DomainRenewOverride != null) OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.DomainRenewOverride), DomainRenewOverride.ToString());

            // if (DomainRenewals != null) OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.DomainRenewals), DomainRenewals.ToString()); // TODO: Add DomainRenewals

            if (ClientIp != "") OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.ClientIp), ClientIp.ToString());
            if (AddonId != -1) OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.AddonId), AddonId.ToString());
            if (ServiceId != -1) OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.ServiceId), ServiceId.ToString());
            if (AddonIds != null) OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.AddonIds), AddonIds.ToString());
            if (ServiceIds != null) OrderDetails.Add(EnumUtil.GetString(APIEnums.AddOrderParams.ServiceIds), ServiceIds.ToString());
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
