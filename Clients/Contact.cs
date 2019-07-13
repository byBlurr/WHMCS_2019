using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using WHMCS;

namespace WHMCS.Clients
{
    public class Contact
    {
        public readonly NameValueCollection ContactInfo;

        /// <summary>
        /// Contact Information
        /// </summary>
        /// <param name="FirstName">[Optional] </param>
        /// <param name="LastName">[Optional] </param>
        /// <param name="CompanyName">[Optional] </param>
        /// <param name="Email">[Optional] Email address to identify the contact. This should be unique if the contact will be a sub-account</param>
        /// <param name="Address1">[Optional] </param>
        /// <param name="Address2">[Optional] </param>
        /// <param name="City">[Optional] </param>
        /// <param name="State">[Optional] </param>
        /// <param name="PostCode">[Optional] </param>
        /// <param name="Country">[Optional] 2 character ISO country code</param>
        /// <param name="PhoneNumber">[Optional] </param>
        /// <param name="TaxId">[Optional] </param>
        /// <param name="Password2">[Optional] if creating a sub-account</param>
        /// <param name="GeneralEmails">set true to receive general email types, Default: false</param>
        /// <param name="ProductEmails">set true to receive product related emails, Default: false</param>
        /// <param name="DomainEmails">set true to receive domain related emails, Default: false</param>
        /// <param name="InvoiceEmails">set true to receive billing related emails, Default: false</param>
        /// <param name="SupportEmails">set true to receive support ticket related emails, Default: false</param>
        /// <param name="Permissions">[Optional] A comma separated list of sub-account permissions. eg manageproducts,managedomains</param>
        public Contact(string FirstName = "", string LastName = "", string CompanyName = "", string Email = "", string Address1 = "", string Address2 = "", string City = "", string State = "", string Postcode = "", string Country = "", string PhoneNumber = "", string TaxId = "", string Password2 = "", bool GeneralEmails = false, bool ProductEmails = false, bool DomainEmails = false, bool InvoiceEmails = false, bool SupportEmails = false, string Permissions = "")
        {
            ContactInfo = new NameValueCollection();

            if (FirstName != "") ContactInfo.Add(EnumUtil.GetString(APIEnums.AddContactParams.FirstName), FirstName.ToString());
            if (LastName != "") ContactInfo.Add(EnumUtil.GetString(APIEnums.AddContactParams.LastName), LastName.ToString());
            if (CompanyName != "") ContactInfo.Add(EnumUtil.GetString(APIEnums.AddContactParams.CompanyName), CompanyName.ToString());
            if (Email != "") ContactInfo.Add(EnumUtil.GetString(APIEnums.AddContactParams.Email), Email.ToString());
            if (Address1 != "") ContactInfo.Add(EnumUtil.GetString(APIEnums.AddContactParams.Address1), Address1.ToString());
            if (Address2 != "") ContactInfo.Add(EnumUtil.GetString(APIEnums.AddContactParams.Address2), Address2.ToString());
            if (City != "") ContactInfo.Add(EnumUtil.GetString(APIEnums.AddContactParams.City), City.ToString());
            if (State != "") ContactInfo.Add(EnumUtil.GetString(APIEnums.AddContactParams.State), State.ToString());
            if (Postcode != "") ContactInfo.Add(EnumUtil.GetString(APIEnums.AddContactParams.Postcode), Postcode.ToString());
            if (Country != "") ContactInfo.Add(EnumUtil.GetString(APIEnums.AddContactParams.Country), Country.ToString());
            if (PhoneNumber != "") ContactInfo.Add(EnumUtil.GetString(APIEnums.AddContactParams.PhoneNumber), PhoneNumber.ToString());
            if (TaxId != "") ContactInfo.Add(EnumUtil.GetString(APIEnums.AddContactParams.TaxId), TaxId.ToString());
            if (Password2 != "") ContactInfo.Add(EnumUtil.GetString(APIEnums.AddContactParams.Password2), Password2.ToString());
            ContactInfo.Add(EnumUtil.GetString(APIEnums.AddContactParams.GeneralEmails), GeneralEmails.ToString());
            ContactInfo.Add(EnumUtil.GetString(APIEnums.AddContactParams.ProductEmails), ProductEmails.ToString());
            ContactInfo.Add(EnumUtil.GetString(APIEnums.AddContactParams.DomainEmails), DomainEmails.ToString());
            ContactInfo.Add(EnumUtil.GetString(APIEnums.AddContactParams.InvoiceEmails), InvoiceEmails.ToString());
            ContactInfo.Add(EnumUtil.GetString(APIEnums.AddContactParams.SupportEmails), SupportEmails.ToString());
            if (Permissions != "") ContactInfo.Add(EnumUtil.GetString(APIEnums.AddContactParams.Permissions), Permissions.ToString());
        }
    }
}
