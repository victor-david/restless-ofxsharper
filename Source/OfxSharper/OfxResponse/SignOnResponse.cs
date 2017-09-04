using System;
using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents an Ofx signon response
    /// </summary>
    public class SignOnResponse : OfxObjectBase
    {
        #region Public properties
        /// <summary>
        /// ACCESSKEY. Access key that the client should return in the next SONRQ, A-1000
        /// </summary>
        [NodeInfo("ACCESSKEY")]
        public string AccessKey
        {
            get;
            private set;
        }

        /// <summary>
        /// DTACCTUP. Date and time of last update to account information (see Chapter 8), datetime
        /// </summary>
        [NodeInfo("DTACCTUP")]
        public DateTime? AccountUpdate
        {
            get;
            private set;
        }

        /// <summary>
        /// FI. Financial-Institution-identification aggregate.
        /// The client will determine out-of-band whether a FI aggregate should be used and if so, the appropriate values for it.
        /// If the FI aggregate is to be used, then the client should send it in every request, and the server should return it in every response.
        /// </summary>
        [NodeInfo("FI")]
        public InstitutionIdentification InstitutionId
        {
            get;
            private set;
        }

        /// <summary>
        /// LANGUAGE. Language used in text responses, language
        /// </summary>
        [NodeInfo("LANGUAGE")]
        public string Language
        {
            get;
            private set;
        }

        /// <summary>
        /// DTPROFUP. Date and time of last update to profile information for any service supported by this FI (see Chapter 7), datetime
        /// </summary>
        [NodeInfo("DTPROFUP")]
        public DateTime? ProfileDate
        {
            get;
            private set;
        }

        /// <summary>
        ///  DTSERVER. Date and time of the server response, datetime
        /// </summary>
        [NodeInfo("DTSERVER")]
        public DateTime ServerDateTime
        {
            get;
            private set;
        }

        /// <summary>
        /// SESSCOOKIE. Session cookie that the client should return on the next SONRQ, A-1000
        /// </summary>
        [NodeInfo("SESSCOOKIE")]
        public string SessionCookie
        {
            get;
            private set;
        }

        /// <summary>
        /// STATUS. Gets the response status aggregate.
        /// </summary>
        /// <remarks>
        /// <para>
        /// To provide as much feedback as possible to clients and their users, OFX defines a STATUS aggregate. 
        /// The most important element is the code that identifies the error. Each response defines the codes it uses. 
        /// Codes 0 through 2999 have common meanings in all OFX transactions. Codes from 3000 and up have meanings specific to each transaction.
        /// </para>
        /// <para>
        /// The last 10 error codes in each assigned range of 1000 is reserved for server-specific status codes.
        /// For example, of the general status codes, 2990¬-2999 are reserved for status codes defined by the server.Of the banking status codes, 
        /// codes 10990-10999 are reserved for the server. If a client receives a server-specific status code that it does not know, 
        /// it will handle it as a general error 2000.
        /// </para>
        /// </remarks>
        [NodeInfo("STATUS")]
        public StatusAggregate Status
        {
            get;
            private set;
        }

        /// <summary>
        /// USERKEY. Use user key instead of USERID and USERPASS for subsequent requests. TSKEYEXPIRE can limit lifetime. A-64
        /// </summary>
        [NodeInfo("USERKEY")]
        public string UserKey
        {
            get;
            private set;
        }

        /// <summary>
        /// TSKEYEXPIRE. Date and time that USERKEY expires, datetime.
        /// </summary>
        [NodeInfo("TSKEYEXPIRE")] 
        public DateTime? UserKeyExpire
        {
            get;
            private set;
        }

        #endregion

        /************************************************************************/

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SignOnResponse"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        public SignOnResponse(XmlNode rootNode)
        {
            ValidateNull(rootNode, "SignOn.Node");
            AccessKey = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(AccessKey))));
            AccountUpdate = GetNullableDateTimeValue(GetNestedNode(rootNode, GetNodeName(nameof(AccountUpdate))));
            var node = GetNestedNode(rootNode, GetNodeName(nameof(InstitutionId)));
            if (node != null)
            {
                InstitutionId = new InstitutionIdentification(node);
            }

            Language = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(Language))));
            ProfileDate = GetNullableDateTimeValue(GetNestedNode(rootNode, GetNodeName(nameof(ProfileDate))));
            ServerDateTime = GetDateTimeValue(GetNestedNode(rootNode, GetNodeName(nameof(ServerDateTime))));
            SessionCookie = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(SessionCookie))));
            Status = new StatusAggregate(GetNestedNode(rootNode, GetNodeName(nameof(Status))));
            UserKey = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(UserKey))));
            UserKeyExpire = GetNullableDateTimeValue(GetNestedNode(rootNode, GetNodeName(nameof(UserKeyExpire))));
        }
        #endregion
    }
}