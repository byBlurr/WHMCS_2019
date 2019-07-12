using System;
using System.Reflection;

namespace WHMCS
{
    public static class APIEnums  
    {

        public enum AcceptOrderParams
        {
            [StringValue("orderid")] OrderId,
            [StringValue("serverid")] ServerId,
            [StringValue("serviceusername")] ServiceUsername,
            [StringValue("servicepassword")] ServicePassword,
            [StringValue("registrar")] Registrar,
            [StringValue("sendregistrar")] SendRegistrar,
            [StringValue("autosetup")] AutoSetup,
            [StringValue("sendemail")] SendEmail
        }

        public enum AcceptQuoteParams
        {
            [StringValue("quoteid")] QuoteId,
        }

        public enum AddAnnounementParams
        {
            [StringValue("date")] DateTime,
            [StringValue("title")] Title,
            [StringValue("announcement")] Announcement,
            [StringValue("published")] Publish,
        }

        public enum AddBannedIpParams
        {
            [StringValue("ip")] Ip,
            [StringValue("reason")] Reason,
            [StringValue("days")] Days,
            [StringValue("expires")] Expires
        }

        public enum AddBillableItemParams
        {
            [StringValue("clientid")] ClientId,
            [StringValue("description")] Description,
            [StringValue("amount")] InvoiceAmount,
            [StringValue("invoiceaction")] InvoiceAction,
            [StringValue("recur")] Recur,
            [StringValue("recurcycle")] RecurCycle,
            [StringValue("recurfor")] RecurFor,
            [StringValue("duedate")] DueDate,
            [StringValue("hours")] Quantity,
        }

        public enum AddCancelRequestParams
        {
            [StringValue("serviceid")] ServiceId,
            [StringValue("type")] Type,
            [StringValue("reason")] Reason,
        }

        public enum AddClientParams
        {
            [StringValue("firstname")] Firstname,
            [StringValue("lastname")] Lastname,
            [StringValue("email")] Email,
            [StringValue("address1")] Address1,
            [StringValue("city")] City,
            [StringValue("state")] State,
            [StringValue("postcode")] Postcode,
            [StringValue("countrycode")] CountryCode,
            [StringValue("phonenumber")] PhoneNumber,
            [StringValue("password2")] Password,
            [StringValue("noemail")] NoEmail,
            [StringValue("companyname")] CompanyName,
            [StringValue("address2")] Address2,
            [StringValue("securityqid")] SecurityQuestionID,
            [StringValue("securityqans")] SecurityQuestionAnswer,
            [StringValue("cardtype")] CardType,
            [StringValue("cardnum")] CardNumber,
            [StringValue("expdate")] ExpiricyDate,
            [StringValue("startdate")] StartDate,
            [StringValue("issuenumber")] IssueNumber,
            [StringValue("cvv")] CVV,
            [StringValue("currency")] Currency,
            [StringValue("groupid")] GroupID,
            [StringValue("customfields")] CustomFields,
            [StringValue("language")] Language,
            [StringValue("clientip")] ClientIP,
            [StringValue("notes")] Notes,
            [StringValue("skipvalidation")] SkipValidation
        }

        public enum AddClientNoteParams
        {
            [StringValue("userid")] ClientId,
            [StringValue("notes")] Notes,
            [StringValue("sticky")] Sticky,
        }

        public enum AddContactParams
        {
            [StringValue("clientid")] ClientId,
            [StringValue("firstname")] FirstName,
            [StringValue("lastname")] LastName,
            [StringValue("companyname")] CompanyName,
            [StringValue("email")] Email,
            [StringValue("address1")] Address1,
            [StringValue("address2")] Address2,
            [StringValue("city")] City,
            [StringValue("state")] State,
            [StringValue("postcode")] Postcode,
            [StringValue("country")] Country,
            [StringValue("phonenumber")] PhoneNumber,
            [StringValue("tax_id")] TaxId,
            [StringValue("password2")] Password2,
            [StringValue("generalemails")] GeneralEmails,
            [StringValue("productemails")] ProductEmails,
            [StringValue("domainemails")] DomainEmails,
            [StringValue("invoiceemails")] InvoiceEmails,
            [StringValue("supportemails")] SupportEmails,
            [StringValue("permissions")] Permissions,
        }

        public enum AddCreditParams
        {
            [StringValue("clientid")] ClientId,
            [StringValue("description")] Description,
            [StringValue("amount")] Amount,
        }

        public enum AddInvoicePaymentParams
        {
            [StringValue("invoiceid")] InvoiceId,
            [StringValue("transid")] TransactionId,
            [StringValue("gateway")] Gateway,
            [StringValue("date")] DateTime,
            [StringValue("amount")] Amount,
            [StringValue("fees")] Fees,
            [StringValue("noemail")] NoEmail,
        }

        public enum AddOrderParams
        {
            [StringValue("clientid")] ClientId,
            [StringValue("paymentmethod")] PaymentMethod,
            [StringValue("pid")] ProductIds,
            [StringValue("domain")] Domains,
            [StringValue("billingcycle")] BillingCycles,
            [StringValue("domaintype")] DomainTypes,
            [StringValue("regperiod")] RegistrationPeriods,
            [StringValue("eppcode")] EppCodes,
            [StringValue("nameserver1")] Nameserver1,
            [StringValue("nameserver2")] Nameserver2,
            [StringValue("nameserver3")] Nameserver3,
            [StringValue("nameserver4")] Nameserver4,
            [StringValue("nameserver5")] Nameserver5,
            [StringValue("customfields")] CustomFields,
            [StringValue("configoptions")] ConfigOptions,
            [StringValue("priceoverride")] PriceOverride,
            [StringValue("promocode")] PromoCode,
            [StringValue("promooverride")] PromoOverride,
            [StringValue("affid")] AffiliateId,
            [StringValue("noinvoice")] NoInvoice,
            [StringValue("noinvoiceemail")] NoInvoiceEmail,
            [StringValue("noemail")] NoEmail,
            [StringValue("addons")] Addons,
            [StringValue("hostname")] Hostname,
            [StringValue("ns1prefix")] Ns1Prefix,
            [StringValue("ns2prefix")] Ns2Prefix,
            [StringValue("rootpw")] RootPassword,
            [StringValue("contactid")] ContactId,
            [StringValue("dnsmanagement")] DnsManagement,
            [StringValue("domainfields")] DomainFields,
            [StringValue("emailforwarding")] EmailForwarding,
            [StringValue("idprotection")] IdProtection,
            [StringValue("domainpriceoverride")] DomainPriceOverride,
            [StringValue("domainrenewoverride")] DomainRenewOverride,
            [StringValue("domainrenewals")] DomainRenewals,
            [StringValue("clientip")] ClientIp,
            [StringValue("addonid")] AddonId,
            [StringValue("serviceid")] ServiceId,
            [StringValue("addonids")] AddonIds,
            [StringValue("serviceids")] ServiceIds,
        }

        public enum DomainWhoisParams
        {
            [StringValue("domain")] Domain
        }

        public enum GetClientsParams
        {
            [StringValue("limitstart")] LimitStart,
            [StringValue("limitnum")] LimitNum,
            [StringValue("sorting")] Sorting,
            [StringValue("search")] Search
        }

        public enum GetClientsDetailsParams
        {
            [StringValue("clientid")] ClientID,
            [StringValue("email")] Email,
            [StringValue("stats")] Stats
        }

        public enum GetOrdersParams
        {
            [StringValue("limitstart")] LimitStart,
            [StringValue("limitnum")] LimitNumber,
            [StringValue("id")] OrderID,
            [StringValue("userid")] UserID,
            [StringValue("status")] Status
        }

        public enum GetTransactionsParams
        {
            [StringValue("invoiceid")] InvoiceID,
            [StringValue("clientid")] ClientID,
            [StringValue("transid")] TransactionID
        }

        public enum GetClientsProductsParams
        {
            [StringValue("limitstart")] ResultsStartOffset,
            [StringValue("limitnum")] ResultsLimit,
            [StringValue("clientid")] ClientID,
            [StringValue("serviceid")] ServiceID,
            [StringValue("pid")] ProductID,
            [StringValue("domain")] Domain,
            [StringValue("username2")] Username
        }

        public enum GetInvoicesParams
        {
            [StringValue("limitstart")] LimitStart,
            [StringValue("limitnum")] LimitNumber,
            [StringValue("userid")] UserID,
            [StringValue("status")] Status
        }

        public enum ModuleChangePasswordParams
        {
            [StringValue("accountid")] ServiceID,
            [StringValue("servicepassword")] NewPassword
        }

        public enum ModuleCustomCommandParams
        {
            [StringValue("accountid")] ServiceID,
            [StringValue("func_name")] Command
        }

        public enum GetInvoiceParams
        {
            [StringValue("invoiceid")] InvoiceID
        }

        public enum GetClientsDomainsParams
        {
            [StringValue("limitstart")] LimitStart,
            [StringValue("limitnum")] LimitNumber,
            [StringValue("clientid")] ClientID,
            [StringValue("domainid")] DomainID,
            [StringValue("domain")] Domain
        }

		public enum UpdateClientProductParams
		{
			[StringValue("serviceid")] ServiceID,
			[StringValue("pid")] PackageID,
			[StringValue("serverid")] ServerID,
			[StringValue("nextduedate")] NextDueDate,
			[StringValue("terminationDate")] TerminationDate,
			[StringValue("completedDate")] CompletedDate,
			[StringValue("domain")] Domain,
			[StringValue("firstpaymentamount")] FirstPaymentAmount,
			[StringValue("recurringamount")] RecurringAmount,
			[StringValue("paymentmethod")] PaymentMethod,
			[StringValue("subscriptionid")] SubscriptionID,
			[StringValue("status")] Status,
			[StringValue("notes")] Notes,
			[StringValue("serviceusername")] ServiceUsername,
			[StringValue("servicepassword")] ServicePassword,
			[StringValue("overideautosuspend")] OverideAutoSuspend,
			[StringValue("overidesuspenduntil")] OverideSuspendUntil,
			[StringValue("ns1")] NameServer1,
			[StringValue("ns2")] NameServer2,
			[StringValue("dedicatedip")] DedicatedIP,
			[StringValue("assignedips")] AssignedIPs,
			[StringValue("diskusage")] DiskUsage,
			[StringValue("disklimit")] DiskLimit,
			[StringValue("bwusage")] BandwidthUsage,
			[StringValue("bwlimit")] BandwidthLimit,
			[StringValue("suspendreason")] SuspendReason,
			[StringValue("promoid")] PromoID,
			[StringValue("unset")] Unset,
			[StringValue("autorecalc")] AutoRecalculate,
			[StringValue("customfields")] CustomFields,
			[StringValue("configoptions")] ConfigurationOptions
		}

        public enum ValidateLoginParams
        {
            [StringValue("email")] Email,
            [StringValue("password2")] Password
        }

        public static class UpdateClientProductSubEnums
		{
			public enum Status
			{
				Null,
				[StringValue("Terminated")] Terminated,
				[StringValue("Active")] Active,
				[StringValue("Pending")] Pending,
				[StringValue("Suspended")] Suspended,
				[StringValue("Canceled")] Canceled,
				[StringValue("Fraud")] Fraud
			}

			public enum Unset
			{
				[StringValue("ns1")] NameServer1,
				[StringValue("ns2")] NameServer2,
				[StringValue("serviceusername")] ServiceUsername,
				[StringValue("servicepassword")] ServicePassword,
				[StringValue("subscriptionid")] SubscriptionID,
				[StringValue("dedicatedip")] DedicatedIP,
				[StringValue("assignedips")] AssignedIPs,
				[StringValue("notes")] Notes,
				[StringValue("suspendreason")] SuspendReason
			}

			public enum OverideAutoSuspend
			{
				Null,
				[StringValue("on")] True,
				[StringValue("off")] False
			}

			public enum AutoRecalculate
			{
				Null,
				[StringValue("true")] True,
				[StringValue("false")] False
			}
		}

        /// <summary>
        /// Actions Supported by the WHMCS API that are implemented in this Wrapper
        /// </summary>
        public enum Actions
        {
            [StringValue("AcceptOrder")] AcceptOrder,
            [StringValue("AcceptQuote")] AcceptQuote,
            [StringValue("AddAnnouncement")] AddAnnouncement,
            [StringValue("AddBannedIp")] AddBannedIp,
            [StringValue("AddBillableItem")] AddBillableItem,
            [StringValue("AddCancelRequest")] AddCancelRequest,
            [StringValue("AddClient")] AddClient,
            [StringValue("AddClientNote")] AddClientNote,
            [StringValue("AddContact")] AddContact,
            [StringValue("AddCredit")] AddCredit,
            [StringValue("AddInvoicePayment")] AddInvoicePayment,
            [StringValue("AddOrder")] AddOrder,
            [StringValue("DomainWhois")] DomainWhois,
            [StringValue("GetClients")] GetClients,
            [StringValue("GetClientsDetails")] GetClientsDetails,
            [StringValue("GetOrders")] GetOrders,
            [StringValue("GetTransactions")] GetTransactions,
            [StringValue("GetClientsProducts")] GetClientsProducts,
            [StringValue("GetInvoices")] GetInvoices,
            [StringValue("GetInvoice")] GetInvoice,
            [StringValue("GetClientsDomains")] GetClientsDomains,
            [StringValue("ModuleChangePw")] ModuleChangePassword,
            [StringValue("ModuleCustom")] ModuleCustomCommand,
			[StringValue("UpdateClientProduct")] UpdateClientProduct,
            [StringValue("ValidateLogin")] ValidateLogin,
        }
    }

    /// <summary>
    /// Creates an attribute called StringValue
    /// </summary>
    public class StringValue : Attribute
    {
        private readonly string _value;

        public StringValue(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }        

    }

    /// <summary>
    /// Used to get the string out of the Enum
    /// </summary>
    public static class EnumUtil
    {
        public static string GetString(Enum value)
        {
            string output = null;
            Type type = value.GetType();

            FieldInfo fi = type.GetField(value.ToString());
            StringValue[] attrs =
               fi.GetCustomAttributes(typeof(StringValue),
                                       false) as StringValue[];
            if (attrs.Length > 0)
            {
                output = attrs[0].Value;
            }

            return output;
        }
    }

}


