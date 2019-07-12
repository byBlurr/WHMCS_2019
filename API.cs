using System;
using System.Collections.Specialized;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WHMCS.Clients;
using WHMCS.Login;
using WHMCS.Orders;
using WHMCS_2019.Clients;
using WHMCS_2019.Orders;

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
        /// Accepts a pending order.
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
        /// Adds a Billable Item to a client.
        /// </summary>
        /// <param name="ClientId">The client to add the item to</param>
        /// <param name="Description">The description of the Billable Item. This will appear on the invoice</param>
        /// <param name="InvoiceAmount">the total amount to invoice for</param>
        /// <param name="InvoiceAction">One of ‘noinvoice’, ‘nextcron’, ‘nextinvoice’, ‘duedate’, ‘recur’</param>
        /// <param name="Recur">When $invoiceaction=recur. The frequency of the recurrence.</param>
        /// <param name="RecurCycle">How often to recur the Billable Item. Days, Weeks, Months or Years.</param>
        /// <param name="RecurFor">How many times the Billable Item should create an invoice.</param>
        /// <param name="DueDate">Date the invoice should be due (only required for duedate & recur invoice actions). YYYY-mm-dd</param>
        /// <param name="Quantity">number of hours/quantity the item corresponds to. (not required for single quantities)</param>
        /// <returns>Returns the new billable item id int</returns>
        public int AddBillableItem(int ClientId, string Description, float InvoiceAmount, string InvoiceAction = "", int Recur = -1, string RecurCycle = "", int RecurFor = -1, string DueDate = "", float Quantity = -1.0f)
        {
            NameValueCollection data = new NameValueCollection()
            {
                { "action", APIEnums.Actions.AddBillableItem.ToString() },
                { EnumUtil.GetString(APIEnums.AddBillableItemParams.ClientId), ClientId.ToString() },
                { EnumUtil.GetString(APIEnums.AddBillableItemParams.Description), Description.ToString() },
                { EnumUtil.GetString(APIEnums.AddBillableItemParams.InvoiceAmount), InvoiceAmount.ToString() }
            };

            if (InvoiceAction != "")
            {
                if (InvoiceAction == "noinvoice" || InvoiceAction == "nextcron" || InvoiceAction == "nextinvoice" || InvoiceAction == "duedate" || InvoiceAction == "recur")
                    data.Add(EnumUtil.GetString(APIEnums.AddBillableItemParams.InvoiceAction), InvoiceAction.ToString());
                else
                    throw new Exception("An API Error occurred", new Exception("InvoiceAction must be one of ‘noinvoice’, ‘nextcron’, ‘nextinvoice’, ‘duedate’ or ‘recur’."));
            }
            if (Recur != -1)
                data.Add(EnumUtil.GetString(APIEnums.AddBillableItemParams.Recur), Recur.ToString());
            if (RecurCycle != "")
            {
                if (RecurCycle.ToLower() == "days" || RecurCycle.ToLower() == "weeks" || RecurCycle.ToLower() == "months" || RecurCycle.ToLower() == "years")
                    data.Add(EnumUtil.GetString(APIEnums.AddBillableItemParams.RecurCycle), RecurCycle.ToString());
                else
                    throw new Exception("An API Error occurred", new Exception("RecurCycle must be one of ‘Days’, ‘Weeks’, ‘Months’ or ‘Years’."));
            }
            if (RecurFor != -1)
                data.Add(EnumUtil.GetString(APIEnums.AddBillableItemParams.RecurFor), RecurFor.ToString());
            if (DueDate != "")
                data.Add(EnumUtil.GetString(APIEnums.AddBillableItemParams.DueDate), DueDate.ToString());
            if (Quantity != -1)
                data.Add(EnumUtil.GetString(APIEnums.AddBillableItemParams.Quantity), Quantity.ToString());

            string req = _call.MakeCall(data);
            JObject result = JObject.Parse(req);

            if (result["result"].ToString() == "success")
                return Convert.ToInt32(result["billableid"]);
            else
                throw new Exception("An API Error occurred", new Exception(result["message"].ToString()));
        }

        /// <summary>
        /// Adds a Cancellation Request.
        /// </summary>
        /// <param name="ServiceId">The Service ID to cancel</param>
        /// <param name="Type">The type of cancellation. ‘Immediate’ or ‘End of Billing Period’</param>
        /// <param name="Reason">The customer reason for cancellation</param>
        /// <returns>Object of CancelRequestResponse</returns>
        public CancelRequestResponse AddCancelRequest(int ServiceId, string Type = "", string Reason = "")
        {
            NameValueCollection data = new NameValueCollection()
            {
                { "action", APIEnums.Actions.AddCancelRequest.ToString() },
                { EnumUtil.GetString(APIEnums.AddCancelRequestParams.ServiceId), ServiceId.ToString() },
            };

            if (Type != "")
                data.Add(EnumUtil.GetString(APIEnums.AddCancelRequestParams.Type), Type.ToString());
            if (Reason != "")
                data.Add(EnumUtil.GetString(APIEnums.AddCancelRequestParams.Reason), Reason.ToString());

            string req = _call.MakeCall(data);
            JObject result = JObject.Parse(req);

            if (result["result"].ToString() == "success")
                return JsonConvert.DeserializeObject<CancelRequestResponse>(req, settings);
            else
                throw new Exception("An API Error Ocurred", new Exception(result["message"].ToString()));
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
        /// Adds a Client Note.
        /// </summary>
        /// <param name="ClientId">The Client ID to apply the note to</param>
        /// <param name="Notes">The note to add</param>
        /// <param name="Sticky">Should the note be made sticky. Makes the note ‘sticky’ and displays the note throughout the client’s account and on any tickets they submit in the admin area</param>
        /// <returns>The id of the newly created note</returns>
        public int AddClientNote(int ClientId, string Notes, bool Sticky = false)
        {
            NameValueCollection data = new NameValueCollection()
            {
                { "action", APIEnums.Actions.AddClientNote.ToString() },
                { EnumUtil.GetString(APIEnums.AddClientNoteParams.ClientId), ClientId.ToString() },
                { EnumUtil.GetString(APIEnums.AddClientNoteParams.Notes), Notes.ToString() },
                { EnumUtil.GetString(APIEnums.AddClientNoteParams.Sticky), Sticky.ToString() },
            };

            string req = _call.MakeCall(data);
            JObject result = JObject.Parse(req);

            if (result["result"].ToString() == "success")
                return Convert.ToInt32(result["noteid"]);
            else
                throw new Exception("An API Error Ocurred", new Exception(result["message"].ToString()));
        }

        /// <summary>
        /// Adds a contact to a client account.
        /// </summary>
        /// <param name="ClientId">The ClientID the information is being added to</param>
        /// <param name="Contact">The contact information to add</param>
        /// <returns>The id of the newly added contact.</returns>
        public int AddContact(int ClientId, Contact Contact)
        {
            NameValueCollection data = new NameValueCollection()
            {
                { "action", APIEnums.Actions.AddContact.ToString() },
                { EnumUtil.GetString(APIEnums.AddContactParams.ClientId), ClientId.ToString() },
            };
            
            foreach (string key in Contact.ContactInfo)
            {
                data.Add(key, Contact.ContactInfo[key]);
            }

            JObject result = JObject.Parse(_call.MakeCall(data));

            if (result["result"].ToString() == "success")
                return Convert.ToInt32(result["contactid"]);
            else
                throw new Exception("An API Error Ocurred", new Exception(result["message"].ToString()));
        }

        /// <summary>
        /// Adds credit to a given client.
        /// </summary>
        /// <param name="ClientId">Client you are adding credit to</param>
        /// <param name="Description">Admin only notes for credit justification</param>
        /// <param name="Amount">Amount of credit to add</param>
        /// <returns>The new total credit balance</returns>
        public double AddCredit(int ClientId, string Description, float Amount)
        {
            NameValueCollection data = new NameValueCollection()
            {
                { "action", APIEnums.Actions.AddCredit.ToString() },
                { EnumUtil.GetString(APIEnums.AddCreditParams.ClientId), ClientId.ToString() },
                { EnumUtil.GetString(APIEnums.AddCreditParams.Description), Description.ToString() },
                { EnumUtil.GetString(APIEnums.AddCreditParams.Amount), Amount.ToString() }
            };

            string req = _call.MakeCall(data);
            JObject result = JObject.Parse(req);

            if (result["result"].ToString() == "success")
                return Convert.ToDouble(result["newbalance"]);
            else
                throw new Exception("An API Error occurred", new Exception(result["message"].ToString()));
        }

        /// <summary>
        /// Adds payment to a given invoice.
        /// </summary>
        /// <param name="InvoiceId"></param>
        /// <param name="TransactionId">The unique transaction id that should be applied to the payment</param>
        /// <param name="Gateway">The gateway used in system name format, eg. paypal, authorize</param>
        /// <param name="DateTime">The date that the payment should have assigned. Format: YYYY-MM-DD HH:mm:ss</param>
        /// <param name="Amount">The amount paid, can be left undefined to take full amount of invoice</param>
        /// <param name="Fees">The amount of the payment that was taken as a fee by the gateway</param>
        /// <param name="NoEmail">Set to true to not send an email for the invoice payment</param>
        /// <returns>Returns true if successful</returns>
        public bool AddInvoicePayment(int InvoiceId, string TransactionId, string Gateway, string DateTime = "", float Amount = 0f, float Fees = 0f, bool NoEmail = false)
        {
            NameValueCollection data = new NameValueCollection()
            {
                { "action", APIEnums.Actions.AddInvoicePayment.ToString() },
                { EnumUtil.GetString(APIEnums.AddInvoicePaymentParams.InvoiceId), InvoiceId.ToString() },
                { EnumUtil.GetString(APIEnums.AddInvoicePaymentParams.TransactionId), TransactionId.ToString() },
                { EnumUtil.GetString(APIEnums.AddInvoicePaymentParams.Gateway), Gateway.ToString() },
                { EnumUtil.GetString(APIEnums.AddInvoicePaymentParams.NoEmail), NoEmail.ToString() },
            };

            if (DateTime != "") data.Add(EnumUtil.GetString(APIEnums.AddInvoicePaymentParams.DateTime), DateTime.ToString());
            if (Amount != 0f) data.Add(EnumUtil.GetString(APIEnums.AddInvoicePaymentParams.Amount), Amount.ToString());
            if (Fees != 0f) data.Add(EnumUtil.GetString(APIEnums.AddInvoicePaymentParams.Fees), Fees.ToString());

            string req = _call.MakeCall(data);
            JObject result = JObject.Parse(req);

            if (result["result"].ToString() == "success")
                return true;
            else
                throw new Exception("An API Error occurred", new Exception(result["message"].ToString()));
        }

        /// <summary>
        /// Adds an order to a client.
        /// </summary>
        /// <param name="ClientId">ClientId to add the order to</param>
        /// <param name="Order">The order to add</param>
        /// <returns>OrderIds</returns>
        public OrderIds AddOrder(int ClientId, NewOrder Order)
        {
            NameValueCollection data = new NameValueCollection()
            {
                { "action", APIEnums.Actions.AddOrder.ToString() },
                { EnumUtil.GetString(APIEnums.AddOrderParams.ClientId), ClientId.ToString() },
            };

            foreach (string key in Order.OrderDetails)
            {
                data.Add(key, Order.OrderDetails[key]);
            }

            string req = _call.MakeCall(data);
            JObject result = JObject.Parse(req);

            if (result["result"].ToString() == "success")
                return JsonConvert.DeserializeObject<OrderIds>(req, settings);
            else
                throw new Exception("An API Error Ocurred", new Exception(result["message"].ToString()));
        }

        // AddProduct

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
        public Orders.GetInvoices.ClientsInvoices GetInvoices(int LimitStart = 0, int LimitNumber = 25, int UserID = -1, string Status = "")
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

            return JsonConvert.DeserializeObject<Orders.GetInvoices.ClientsInvoices>(_call.MakeCall(data), settings);
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
        public Orders.GetTransactions.ClientsTransactions GetTransactions(int InvoiceID = -1, int ClientID = -1, string TransactionID = "")
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

            return JsonConvert.DeserializeObject<Orders.GetTransactions.ClientsTransactions>(_call.MakeCall(data), settings);
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

        /// <summary>
        /// This is not recommended. Read the API Wrapper wiki page ()
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public JObject UnsupportedAction(NameValueCollection data)
        {
            string req = _call.MakeCall(data);
            JObject result = JObject.Parse(req);

            if (result["result"].ToString() == "success")
                return result;
            else
                throw new Exception("An API Error Ocurred", new Exception(result["message"].ToString()));
        }
    }
}
