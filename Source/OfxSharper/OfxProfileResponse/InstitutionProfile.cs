using Restless.OfxSharper.Core;
using System.Xml;

namespace Restless.OfxSharper.Profile
{
    /// <summary>
    /// Represents the portion of a financial institution profile that describes the FI.
    /// </summary>
    public class InstitutionProfile : ProfileData
    {
        #region Public properties
        /// <summary>
        /// ADDR1. FI address, line 1, A-32.
        /// </summary>
        [NodeInfo("ADDR1")]
        public string Address1
        {
            get;
            private set;
        }

        /// <summary>
        /// ADDR2. FI address, line 2, A-32.
        /// </summary>
        [NodeInfo("ADDR2")]
        public string Address2
        {
            get;
            private set;
        }

        /// <summary>
        /// ADDR3. FI address, line 3, A-32.
        /// </summary>
        [NodeInfo("ADDR3")]
        public string Address3
        {
            get;
            private set;
        }

        /// <summary>
        /// INTU.BROKERID. Broker Id. Thanks Quicken...
        /// </summary>
        [NodeInfo("INTU.BROKERID")]
        public string BrokerId
        {
            get;
            private set;
        }

        /// <summary>
        /// CITY. FI address city, A-32.
        /// </summary>
        [NodeInfo("CITY")]
        public string City
        {
            get;
            private set;
        }

        /// <summary>
        /// COUNTRY. FI address country; 3-letter country code from ISO/DIS-3166, A-3.
        /// </summary>
        [NodeInfo("COUNTRY")]
        public string Country
        {
            get;
            private set;
        }

        /// <summary>
        /// CSPHONE. Customer service telephone number, A-32.
        /// </summary>
        [NodeInfo("CSPHONE")]
        public string CustomerServicePhone
        {
            get;
            private set;
        }

        /// <summary>
        /// EMAIL. Gets the email address for FI, A-80
        /// </summary>
        [NodeInfo("EMAIL")]
        public string Email
        {
            get;
            private set;
        }

        /// <summary>
        /// FAXPHONE. Gets the fax number.
        /// </summary>
        [NodeInfo("FAXPHONE")]
        public string FaxPhone
        {
            get;
            private set;
        }

        /// <summary>
        /// FINAME. Name of institution, A-32.
        /// </summary>
        [NodeInfo("FINAME")]
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// POSTALCODE. FI address postal code, A-11.
        /// </summary>
        [NodeInfo("POSTALCODE")]
        public string PostalCode
        {
            get;
            private set;
        }

        /// <summary>
        /// STATE. FI address state, A-5.
        /// </summary>
        [NodeInfo("STATE")]
        public string State
        {
            get;
            private set;
        }

        /// <summary>
        /// TSPHONE. Technical support telephone number, A-32.
        /// </summary>
        [NodeInfo("TSPHONE")]
        public string TechSupportPhone
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="InstitutionProfile"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal InstitutionProfile(XmlNode rootNode) : base(rootNode)
        {
            if (rootNode != null)
            {
                Address1 = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(Address1))));
                Address2 = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(Address2))));
                Address3 = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(Address3))));
                BrokerId = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(BrokerId))));
                City = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(City))));
                Country = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(Country))));
                CustomerServicePhone = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(CustomerServicePhone))));
                Email = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(Email))));
                FaxPhone = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(FaxPhone))));
                Name = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(Name))));
                PostalCode = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(PostalCode))));
                State = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(State))));
                TechSupportPhone = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(TechSupportPhone))));
            }
        }
        #endregion
    }
}
