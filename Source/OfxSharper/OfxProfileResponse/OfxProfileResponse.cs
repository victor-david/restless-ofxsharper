using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents the response to a profile inquiry for a financial institution.
    /// </summary>
    public class OfxProfileResponse : OfxResponseBase
    {
        #region Public properties
        /// <summary>
        /// Gets the basic profile information for bank operations.
        /// </summary>
        public ProfileData Bank
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the basic profile information for bill pay operations.
        /// </summary>
        public BillPayProfile BillPay
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the basic profile information for credit card operations.
        /// </summary>
        public ProfileData CreditCard
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the profile information for email operations.
        /// </summary>
        public EmailProfile Email
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the basic profile information for profile operations.
        /// </summary>
        public ProfileData Profile
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the basic profile information for signon operations.
        /// </summary>
        public ProfileData SignOn
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the basic profile information for signup operations.
        /// </summary>
        public ProfileData SignUp
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the profile information regarding inta bank transfers.
        /// </summary>
        public TransferProfile Transfer
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the signon info portion of the profile.
        /// </summary>
        public SignonInfoProfile SignonInfo
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the institution info portion of the profile.
        /// </summary>
        public InstitutionProfile Institution
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
            Bank = new ProfileData(GetNestedNode(xmlDoc.FirstChild, "BANKMSGSETV1"));
            BillPay = new BillPayProfile(GetNestedNode(xmlDoc.FirstChild, "BILLPAYMSGSETV1"));
            CreditCard = new ProfileData(GetNestedNode(xmlDoc.FirstChild, "CREDITCARDMSGSETV1"));
            Email = new EmailProfile(GetNestedNode(xmlDoc.FirstChild, "EMAILMSGSETV1"));
            Profile = new ProfileData(GetNestedNode(xmlDoc.FirstChild, "PROFMSGSETV1"));
            SignOn = new ProfileData(GetNestedNode(xmlDoc.FirstChild, "SIGNONMSGSETV1"));
            SignUp = new ProfileData(GetNestedNode(xmlDoc.FirstChild, "SIGNUPMSGSETV1"));
            Transfer = new TransferProfile(GetNestedNode(xmlDoc.FirstChild, "XFERPROF"));
            SignonInfo = new SignonInfoProfile(GetNestedNode(xmlDoc.FirstChild, "SIGNONINFO"));
            Institution = new InstitutionProfile(GetNestedNode(xmlDoc.FirstChild, "DTPROFUP"));
        }
        #endregion
    }
}
