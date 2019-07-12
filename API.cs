using System;
using System.Collections.Specialized;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WHMCS.Clients;
using WHMCS.Login;
using WHMCS.Orders;

namespace WHMCS
{
    public class API
    {
        JsonSerializerSettings settings;

        private readonly Call _call;
        public API(string Username, string Password, string AccessKey, string Url)
        {
            _call = new Call(Username, Password, AccessKey, Url);
            settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
        }

        // Actions

        /// <summary>
        /// Accepts a pending order. \n https://github.com/byBlurr/WHMCS_2019/wiki/AcceptOrder%28%29
        /// </summary>
        /// <param name="OrderId">The order id to be accepted</param>
        /// <param name="ServerId">The specific server to assign to products within the order</param>
        /// <param name="ServiceUsername">The specific username to assign to products within the order</param>
        /// <param name="ServicePassword">The specific password to assign to products within the order</param>
        /// <param name="Registrar">The specific registrar to assign to domains within the order</param>
        /// <param name="SendRegistrar">Send the request to the registrar to register the domain. Default: true</param>
        /// <param name="AutoSetup">Send the request to the product module to activate the service. This can override the product configuration. Default: true</param>
        /// <param name="SendEmail">Send any automatic emails. This can be Product Welcome, Domain Renewal, Domain Transfer etc. Default: true</param>
        /// <returns>The result of the operation: success or error String</returns>
        public string AcceptOrder(int OrderId, int ServerId = -1, string ServiceUsername = "", string ServicePassword = "", string Registrar = "", bool SendRegistrar = true, bool AutoSetup = true, bool SendEmail = true)
        {
            NameValueCollection data = new NameValueCollection()
            {
                { "action", APIEnums.Actions.AcceptOrder.ToString() }
            };

            data.Add(EnumUtil.GetString(APIEnums.AcceptOrderParams.OrderId), OrderId.ToString());

            if (ServerId != -1)
                data.Add(EnumUtil.GetString(APIEnums.AcceptOrderParams.ServerId), ServerId.ToString());
            if (ServiceUsername != "")
                data.Add(EnumUtil.GetString(APIEnums.AcceptOrderParams.ServiceUsername), ServiceUsername.ToString());
            if (ServicePassword != "")
                data.Add(EnumUtil.GetString(APIEnums.AcceptOrderParams.ServicePassword), ServicePassword.ToString());
            if (Registrar != "")
                data.Add(EnumUtil.GetString(APIEnums.AcceptOrderParams.Registrar), Registrar.ToString());

            data.Add(EnumUtil.GetString(APIEnums.AcceptOrderParams.SendRegistrar), SendRegistrar.ToString());
            data.Add(EnumUtil.GetString(APIEnums.AcceptOrderParams.AutoSetup), AutoSetup.ToString());
            data.Add(EnumUtil.GetString(APIEnums.AcceptOrderParams.SendEmail), SendEmail.ToString());

            string req = _call.MakeCall(data);
            JObject result = JObject.Parse(req);

            if (result["result"].ToString() == "success")
                return result.ToString();
            else
                throw new Exception("An API Error Ocurred", new Exception(result["message"].ToString()));
        }

        /// <summary>
        /// Accepts a quote.
        /// </summary>
        /// <param name="QuoteId">The quote id to be accepted and converted to an invoice</param>
        /// <returns>InvoiceId int</returns>
        public int AcceptQuote(int QuoteId)
        {
            NameValueCollection data = new NameValueCollection()
            {
                { "action", APIEnums.Actions.AcceptQuote.ToString() },
                { APIEnums.AcceptQuoteParams.QuoteId.ToString(), QuoteId.ToString() }
            };

            JObject result = JObject.Parse(_call.MakeCall(data));

            if (result["result"].ToString() == "success")
                return Convert.ToInt32(result["invoiceid"]);
            else
                throw new Exception("An API Error Ocurred", new Exception(result["message"].ToString()));
        }

        /// <summary>
        /// Adds an announcement.
        /// </summary>
        /// <param name="DateTime">Date in the format YYYY-MM-DD HH:MM:SS</param>
        /// <param name="Title">Announcement title</param>
        /// <param name="Announcement">Announcement text</param>
        /// <param name="Publish">Pass as true to publish. Default: true</param>
        /// <returns>AnnouncmentId int</returns>
        public int AddAnnouncement(string DateTime, string Title, string Announcement, bool Publish = true)
        {
            NameValueCollection data = new NameValueCollection()
            {
                { "action", APIEnums.Actions.AddAnnouncement.ToString() },
                { EnumUtil.GetString(APIEnums.AddAnnounementParams.DateTime), DateTime.ToString() },
                { EnumUtil.GetString(APIEnums.AddAnnounementParams.Title), Title.ToString() },
                { EnumUtil.GetString(APIEnums.AddAnnounementParams.Announcement), Announcement.ToString() },
                { EnumUtil.GetString(APIEnums.AddAnnounementParams.Publish), Publish.ToString() }
            };

            string req = _call.MakeCall(data);
            JObject result = JObject.Parse(req);
            if (result["result"].ToString() == "success")
                return Convert.ToInt32(result["announcementid"]);
            else
                throw new Exception("An API Error occurred", new Exception(result["message"].ToString()));
        }

        /// <summary>
        /// Adds an IP to the ban list.
        /// </summary>
        /// <param name="Ip">Ip to be banned</param>
        /// <param name="Reason">Admin only reason</param>
        /// <param name="Days">If passed, expires date is auto calculated</param>
        /// <param name="Expires">YYYY-MM-DD HH:MM:SS (OPTIONAL)</param>
        /// <returns>BanId int</returns>
        public int AddBannedIp(string Ip, string Reason, int Days, string Expires = "")
        {
            NameValueCollection data = new NameValueCollection()
            {
                { "action", APIEnums.Actions.AddBannedIp.ToString() },
                { EnumUtil.GetString(APIEnums.AddBannedIpParams.Ip), Ip.ToString() },
                { EnumUtil.GetString(APIEnums.AddBannedIpParams.Reason), Reason.ToString() },
                { EnumUtil.GetString(APIEnums.AddBannedIpParams.Days), Days.ToString() }
            };

            if (Expires != "")
                data.Add(EnumUtil.GetString(APIEnums.AddBannedIpParams.Expires), Expires.ToString());

            string req = _call.MakeCall(data);
            JObject result = JObject.Parse(req);
            if (result["result"].ToString() == "success")
                return Convert.ToInt32(result["banid"]);
            else
                throw new Exception("An API Error occurred", new Exception(result["message"].ToString()));
        }

        /// <summary>
        /// Adds a client.
        /// </summary>
        /// <param name="ClientInfo">ClientInfo object containing all client information.</param>
        /// <returns>ClientId Int</returns>
        public int AddClient(ClientInputInfo ClientInfo)
        {
            NameValueCollection data = new NameValueCollection()
            {
                { "action", APIEnums.Actions.AddClient.ToString() }
            };

            //Processes all the data in ClientInfo model into the data NameValueCollection
            foreach (string key in ClientInfo.ClientInfo)
            {
                data.Add(key, ClientInfo.ClientInfo[key]);
            }

            JObject result = JObject.Parse(_call.MakeCall(data));

            if (result["result"].ToString() == "success")
                return Convert.ToInt32(result["clientid"]);
            else
                throw new Exception("An API Error Ocurred", new Exception(result["message"].ToString()));

        }

        /// <summary>
        /// Retrieve domain whois information.
        /// </summary>
        /// <param name="Domain">The domain name to lookup</param>
        /// <returns>DomainWhoIs Object</returns>
        public DomainWhoIs DomainWhoIs(string Domain)
        {
            NameValueCollection data = new NameValueCollection()
            {
                { "action", APIEnums.Actions.DomainWhois.ToString() },
                { EnumUtil.GetString(APIEnums.DomainWhoisParams.Domain), Domain },
            };

            string req = _call.MakeCall(data);
            JObject result = JObject.Parse(req);

            if (result["result"].ToString() == "success")
                return JsonConvert.DeserializeObject<DomainWhoIs>(req, settings);
            else
                throw new Exception("An API Error Ocurred", new Exception(result["message"].ToString()));

        }

        /// <summary>
        /// Obtain the Clients that match passed criteria. 
        /// </summary>
        /// <param name="LimitStart">The offset for the returned log data (default: 0)</param>
        /// <param name="LimitNum">The number of records to return (default: 25)</param>
        /// <param name="Sorting">The direction to sort the results. ASC or DESC. Default: ASC</param>
        /// <param name="Search">The search term to look for at the start of email, firstname, lastname, fullname or companyname</param>
        /// <returns>ClientsInfo Object</returns>
        public ClientsInfo GetClients(int LimitStart = 0, int LimitNum = 25, string Sorting = "ASC", string Search = "")
        {
            if (!Sorting.Equals("ASC") && !Sorting.Equals("DESC"))
                throw new Exception("Sorting parameter must be 'ASC' or 'DESC'");

            NameValueCollection data = new NameValueCollection()
            {
                { "action", APIEnums.Actions.GetClients.ToString() },
            };

            data.Add(EnumUtil.GetString(APIEnums.GetClientsParams.LimitStart), LimitStart.ToString());
            data.Add(EnumUtil.GetString(APIEnums.GetClientsParams.LimitNum), LimitNum.ToString());
            data.Add(EnumUtil.GetString(APIEnums.GetClientsParams.Sorting), Sorting.ToString());

            if (Search != "")
                data.Add(EnumUtil.GetString(APIEnums.GetClientsParams.Search), Search.ToString());

            string req = _call.MakeCall(data);
            JObject result = JObject.Parse(req);
            if (result["result"].ToString() == "success")
                return JsonConvert.DeserializeObject<ClientsInfo>(req, settings);
            else
                throw new Exception("An API Error occurred", new Exception(result["message"].ToString()));
        }

        /// <summary>
        /// Obtain the Clients Details for a specific client.
        /// </summary>
        /// <param name="ClientID">The client id to obtain the details for. $clientid or $email is required</param>
        /// <param name="ClientEmail">The email address of the client to search for</param>
        /// <param name="Stats">Also return additional client statistics</param>
        /// <returns>ClientsDetails Object</returns>
        public ClientsDetails GetClientsDetails(int ClientID = -1, string ClientEmail = "", bool Stats = false)
        {
            if (ClientID == -1 && ClientEmail == "")
                throw new Exception("ClientID or ClientEmail needed");

            NameValueCollection data = new NameValueCollection()
            {
                { "action", APIEnums.Actions.GetClientsDetails.ToString() },
                { EnumUtil.GetString(APIEnums.GetClientsDetailsParams.Stats), Stats.ToString() },
            };
            if (ClientID != -1)
                data.Add(EnumUtil.GetString(APIEnums.GetClientsDetailsParams.ClientID), ClientID.ToString());
            if (ClientEmail != "" && ClientID == -1)
                data.Add(EnumUtil.GetString(APIEnums.GetClientsDetailsParams.Email), ClientEmail);

            string req = _call.MakeCall(data);
            JObject result = JObject.Parse(req);
            if (result["result"].ToString() == "success")
                return JsonConvert.DeserializeObject<ClientsDetails>(req, settings);
            else
                throw new Exception("An API Error occurred", new Exception(result["message"].ToString()));
        }

        /// <summary>
        /// Obtain a list of Client Purchased Domains matching the provided criteria.
        /// </summary>
        /// <param name="LimitStart">The offset for the returned log data (default: 0)</param>
        /// <param name="LimitNumber">The number of records to return (default: 25)</param>
        /// <param name="ClientID">The client id to obtain the details for.</param>
        /// <param name="DomainID">The specific domain id to obtain the details for</param>
        /// <param name="Domain">The specific domain to obtain the details for</param>
        /// <returns>ClientsDomains Object</returns>
        public ClientsDomains GetClientsDomains(int LimitStart = 0, int LimitNumber = 25, int ClientID = -1, int DomainID = -1, string Domain = "")
        {
            NameValueCollection data = new NameValueCollection()
            {
                { "action", EnumUtil.GetString(APIEnums.Actions.GetClientsDomains) },
                { EnumUtil.GetString(APIEnums.GetClientsDomainsParams.LimitStart), LimitStart.ToString() },
                { EnumUtil.GetString(APIEnums.GetClientsDomainsParams.LimitNumber), LimitNumber.ToString() }
            };

            if (ClientID != -1)
                data.Add(EnumUtil.GetString(APIEnums.GetClientsDomainsParams.ClientID), ClientID.ToString());
            if (DomainID != -1)
                data.Add(EnumUtil.GetString(APIEnums.GetClientsDomainsParams.DomainID), DomainID.ToString());
            if (Domain != "")
                data.Add(EnumUtil.GetString(APIEnums.GetClientsDomainsParams.Domain), Domain);

            return JsonConvert.DeserializeObject<ClientsDomains>(_call.MakeCall(data), settings);
        }

        /// <summary>
        /// Obtain a list of Client Purchased Products matching the provided criteria.
        /// </summary>
        /// <param name="LimitStart">The offset for the returned log data (default: 0)</param>
        /// <param name="LimitNum">The number of records to return (default: 25)</param>
        /// <param name="ClientID">The client id to obtain the details for.</param>
        /// <param name="ServiceID">The specific service id to obtain the details for</param>
        /// <param name="ProductID">The specific product id to obtain the details for</param>
        /// <param name="Domain">The specific domain to obtain the service details for</param>
        /// <param name="Username">The specific username to obtain the details for</param>
        /// <returns>ClientsProducts Object</returns>
        public ClientsProducts GetClientsProducts(int LimitStart = 0, int LimitNum = 25, int ClientID = -1, int ServiceID = -1, int ProductID = -1, string Domain = "", string Username = "")
        {
            NameValueCollection data = new NameValueCollection()
            {
                { "action", APIEnums.Actions.GetClientsProducts.ToString() },
                { EnumUtil.GetString(APIEnums.GetClientsProductsParams.ResultsStartOffset), LimitStart.ToString()},
                { EnumUtil.GetString(APIEnums.GetClientsProductsParams.ResultsLimit), LimitNum.ToString()},
            };

            if (ClientID != -1)
                data.Add(EnumUtil.GetString(APIEnums.GetClientsProductsParams.ClientID), ClientID.ToString());
            if (ServiceID != -1)
                data.Add(EnumUtil.GetString(APIEnums.GetClientsProductsParams.ServiceID), ServiceID.ToString());
            if (ProductID != -1)
                data.Add(EnumUtil.GetString(APIEnums.GetClientsProductsParams.ProductID), ProductID.ToString());
            if (Domain != "")
                data.Add(EnumUtil.GetString(APIEnums.GetClientsProductsParams.Domain), Domain);
            if (Username != "")
                data.Add(EnumUtil.GetString(APIEnums.GetClientsProductsParams.Username), Username);

            return JsonConvert.DeserializeObject<ClientsProducts>(_call.MakeCall(data), settings);
        }

        /// <summary>
        /// Retrieve a specific invoice.
        /// </summary>
        /// <param name="InvoiceID">The ID of the invoice to retrieve</param>
        /// <returns>Invoice Object</returns>
        public Invoice GetInvoice(int InvoiceID)
        {
            NameValueCollection data = new NameValueCollection()
            {
                { "action", EnumUtil.GetString(APIEnums.Actions.GetInvoice) },
                { EnumUtil.GetString(APIEnums.GetInvoiceParams.InvoiceID), InvoiceID.ToString() }
            };

            string req = _call.MakeCall(data);

            JObject result = JObject.Parse(req);

            if (result["result"].ToString() == "success")
                return JsonConvert.DeserializeObject<Invoice>(req, settings);
            else
                throw new Exception("An API Error Ocurred", new Exception(result["message"].ToString()));

        }

        /// <summary>
        /// Retrieve a list of invoices.
        /// </summary>
        /// <param name="LimitStart">The offset for the returned invoice data (default: 0)</param>
        /// <param name="LimitNumber">The number of records to return (default: 25)</param>
        /// <param name="UserID">Find invoices for a specific client id</param>
        /// <param name="Status">Find invoices for a specific status. Standard Invoice statuses plus Overdue</param>
        /// <returns>ClientsInvoices Object</returns>
        public ClientsInvoices GetInvoices(int LimitStart = 0, int LimitNumber = 25, int UserID = -1, string Status = "")
        {
            NameValueCollection data = new NameValueCollection()
            {
                { "action", APIEnums.Actions.GetInvoices.ToString() },
                { EnumUtil.GetString(APIEnums.GetInvoicesParams.LimitStart), LimitStart.ToString() },
                { EnumUtil.GetString(APIEnums.GetInvoicesParams.LimitNumber), LimitNumber.ToString() }
            };
            if (UserID != -1)
                data.Add(EnumUtil.GetString(APIEnums.GetInvoicesParams.UserID), UserID.ToString());
            if (Status != "")
                data.Add(EnumUtil.GetString(APIEnums.GetInvoicesParams.Status), Status);

            return JsonConvert.DeserializeObject<ClientsInvoices>(_call.MakeCall(data), settings);
        }

        /// <summary>
        /// Obtain orders matching the passed criteria.
        /// </summary>
        /// <param name="LimitStart">The offset for the returned order data (default: 0)</param>
        /// <param name="LimitNumber">The number of records to return (default: 25)</param>
        /// <param name="OrderID">Find orders for a specific id</param>
        /// <param name="UserID">Find orders for a specific client id</param>
        /// <param name="Status">Find orders for a specific status</param>
        /// <returns>ClientsOrders Model</returns>
        public ClientsOrders GetOrders(int LimitStart = 0, int LimitNumber = 25, int OrderID = -1, int UserID = -1, string Status = "")
        {
            NameValueCollection data = new NameValueCollection()
            {
                { "action", APIEnums.Actions.GetOrders.ToString() },
                { EnumUtil.GetString(APIEnums.GetOrdersParams.LimitStart), LimitStart.ToString() },
                { EnumUtil.GetString(APIEnums.GetOrdersParams.LimitNumber), LimitNumber.ToString() }
            };
            if (OrderID != -1)
                data.Add(EnumUtil.GetString(APIEnums.GetOrdersParams.OrderID), OrderID.ToString());
            if (UserID != -1)
                data.Add(EnumUtil.GetString(APIEnums.GetOrdersParams.UserID), UserID.ToString());
            if (Status != "")
                data.Add(EnumUtil.GetString(APIEnums.GetOrdersParams.Status), Status);

            return JsonConvert.DeserializeObject<ClientsOrders>(_call.MakeCall(data), settings);
        }

        /// <summary>
        /// Obtain transactions matching the passed criteria.
        /// </summary>
        /// <param name="InvoiceID">Obtain transactions for a specific invoice id</param>
        /// <param name="ClientID">Find transactions for a specific client id</param>
        /// <param name="TransactionID">Find transactions for a specific transaction id</param>
        /// <returns>ClientsTransactions Object</returns>
        public ClientsTransactions GetTransactions(int InvoiceID = -1, int ClientID = -1, string TransactionID = "")
        {
            NameValueCollection data = new NameValueCollection()
            {
                { "action", APIEnums.Actions.GetTransactions.ToString() }
            };
            if (InvoiceID != -1)
                data.Add(EnumUtil.GetString(APIEnums.GetTransactionsParams.InvoiceID), InvoiceID.ToString());
            if (ClientID != -1)
                data.Add(EnumUtil.GetString(APIEnums.GetTransactionsParams.ClientID), ClientID.ToString());
            if (TransactionID != "")
                data.Add(EnumUtil.GetString(APIEnums.GetTransactionsParams.TransactionID), TransactionID);

            return JsonConvert.DeserializeObject<ClientsTransactions>(_call.MakeCall(data), settings);
        }

        /// <summary>
        /// Runs a change password action for a given service.
        /// </summary>
        /// <param name="ServiceID">The service ID to run the action for</param>
        /// <param name="NewPassword">A new password to assign to the service</param>
        /// <param name="getException">Default: true</param>
        /// <returns>If the password was changed Bool</returns>
        public bool ModuleChangePassword(int ServiceID, string NewPassword, bool getException = true)
        {
            NameValueCollection data = new NameValueCollection()
            {
                { "action", EnumUtil.GetString(APIEnums.Actions.ModuleChangePassword) },
                { EnumUtil.GetString(APIEnums.ModuleChangePasswordParams.ServiceID), ServiceID.ToString() },
                { EnumUtil.GetString(APIEnums.ModuleChangePasswordParams.NewPassword), NewPassword }
            };

            JObject result = JObject.Parse(_call.MakeCall(data));

            if (result["result"].ToString() == "success")
                return true;
            else if(result["result"].ToString() != "success" && getException)
                throw new Exception("An API Error Ocurred", new Exception(result["message"].ToString()));
            return false;
        }

        /// <summary>
        /// Runs a custom module action for a given service.
        /// </summary>
        /// <param name="ServiceID">The service ID to run the action for</param>
        /// <param name="Command">The name of the custom function to run</param>
        /// <param name="getException"></param>
        /// <returns>If the command was successful Bool</returns>
        public bool ModuleCustomCommand(int ServiceID, string Command, bool getException = true)
        {
            NameValueCollection data = new NameValueCollection()
            {
                { "action", EnumUtil.GetString(APIEnums.Actions.ModuleCustomCommand) },
                { EnumUtil.GetString(APIEnums.ModuleCustomCommandParams.ServiceID), ServiceID.ToString() },
                { EnumUtil.GetString(APIEnums.ModuleCustomCommandParams.Command), Command }
            };

            JObject result = JObject.Parse(_call.MakeCall(data));

            if (result["result"].ToString() == "success")
                return true;
            else if (result["result"].ToString() != "success" && getException)
                throw new Exception("An API Error Ocurred", new Exception(result["message"].ToString()));
            return false;

        }

        /// <summary>
        /// Updates a Client Service.
        /// </summary>
        /// <param name="ClientProductUpdateInfo"></param>
        /// <returns>Returns true if successful</returns>
		public bool UpdateClientProduct(UpdateClientProduct ClientProductUpdateInfo)
		{

			JObject result = JObject.Parse(_call.MakeCall(ClientProductUpdateInfo.nvm));

			if (result["result"].ToString() == "success")
				return true;
			else
				throw new Exception("An API Error Ocurred", new Exception(result["message"].ToString()));

		}

        /// <summary>
        /// Validate client login credentials. \nThis command can be used to validate an email address and password against a registered user in WHMCS. On success, the userid and password hash will be returned which can be used to create an authenticated session by setting the session key ‘uid’ to the userid and the session key ‘upw’ to the passwordhash. Note: if session IP validation is enabled, this API call must be executed via the local API to receive a valid hash.
        /// </summary>
        /// <param name="Email">Client or Sub-Account Email Address</param>
        /// <param name="Password">Password to validate</param>
        /// <returns>ValidateLogin Object</returns>
        public LoginDetails ValidateLogin(string Email, string Password)
        {
            NameValueCollection data = new NameValueCollection()
            {
                { "action", APIEnums.Actions.ValidateLogin.ToString() },
                { EnumUtil.GetString(APIEnums.ValidateLoginParams.Email), Email },
                { EnumUtil.GetString(APIEnums.ValidateLoginParams.Password), Password }
            };

            string req = _call.MakeCall(data);
            JObject result = JObject.Parse(req);

            if (result["result"].ToString() == "success")
                return JsonConvert.DeserializeObject<LoginDetails>(req, settings);
            else
                throw new Exception("An API Error Ocurred", new Exception(result["message"].ToString()));
        }
    }
}
