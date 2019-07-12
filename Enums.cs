﻿using System;
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
            [StringValue("AddClient")] AddClient,
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

