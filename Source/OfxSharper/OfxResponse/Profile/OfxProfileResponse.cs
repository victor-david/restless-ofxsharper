using Restless.OfxSharper.Core;
using System;
using System.Xml;

namespace Restless.OfxSharper.Profile
{
    /// <summary>
    /// Represents the response to a profile inquiry for a financial institution.
    /// </summary>
    public class OfxProfileResponse : OfxResponseBase
    {
        #region Public properties
        /// <summary>
        /// DTPROFUP. Date / time profile was updated on server, datetime.
        /// </summary>
        [NodeInfo("DTPROFUP", Required = true)]
        public DateTime ProfileDate
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the basic profile information for bank operations.
        /// </summary>
        [NodeInfo("BANKMSGSETV1")]
        public BankAccountProfile Bank
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the basic profile information for bill pay operations.
        /// </summary>
        [NodeInfo("BILLPAYMSGSETV1")]
        public BillPayProfile BillPay
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the basic profile information for credit card operations.
        /// </summary>
        [NodeInfo("CREDITCARDMSGSETV1")]
        public AccountProfile CreditCard
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the profile information for email operations.
        /// </summary>
        [NodeInfo("EMAILMSGSETV1")]
        public EmailProfile Email
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the basic profile information for profile operations.
        /// </summary>
        [NodeInfo("PROFMSGSETV1")]
        public ProfileData Profile
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the basic profile information for signon operations.
        /// </summary>
        [NodeInfo("SIGNONMSGSETV1")]
        public ProfileData SignOn
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the basic profile information for signup operations.
        /// </summary>
        [NodeInfo("SIGNUPMSGSETV1")]
        public ProfileData SignUp
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the signon info portion of the profile.
        /// </summary>
        [NodeInfo("SIGNONINFO")]
        public SignonInfoProfile SignonInfo
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the institution info portion of the profile.
        /// </summary>
        [NodeInfo("FINAME")]
        public InstitutionProfile Institution
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the investment info portion of the profile.
        /// </summary>
        [NodeInfo("INVSTMTMSGSETV1")]
        public InvestmentProfile Investment
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="OfxProfileResponse"/> class.
        /// </summary>
        /// <param name="header">The Ofx header object.</param>
        /// <param name="xmlDoc">The Xml document</param>
        public OfxProfileResponse(OfxHeader header, XmlDocument xmlDoc) : base(header, xmlDoc)
        {
            ProfileDate = GetDateTimeValue(xmlDoc.FirstChild, nameof(ProfileDate));
            Bank = new BankAccountProfile(GetNestedNode(xmlDoc.FirstChild, GetNodeName(nameof(Bank))));
            BillPay = new BillPayProfile(GetNestedNode(xmlDoc.FirstChild, GetNodeName(nameof(BillPay))));
            CreditCard = new AccountProfile(GetNestedNode(xmlDoc.FirstChild, GetNodeName(nameof(CreditCard))));
            Email = new EmailProfile(GetNestedNode(xmlDoc.FirstChild, GetNodeName(nameof(Email))));
            Profile = new ProfileData(GetNestedNode(xmlDoc.FirstChild, GetNodeName(nameof(Profile))));
            SignOn = new ProfileData(GetNestedNode(xmlDoc.FirstChild, GetNodeName(nameof(SignOn))));
            SignUp = new ProfileData(GetNestedNode(xmlDoc.FirstChild, GetNodeName(nameof(SignUp))));
            SignonInfo = new SignonInfoProfile(GetNestedNode(xmlDoc.FirstChild, GetNodeName(nameof(SignonInfo))));
            Institution = new InstitutionProfile(GetNestedNode(xmlDoc.FirstChild, GetNodeName(nameof(Institution))));
            Investment = new InvestmentProfile(GetNestedNode(xmlDoc.FirstChild, GetNodeName(nameof(Investment))));

        }
        #endregion
    }
}
