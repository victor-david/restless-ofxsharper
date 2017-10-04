using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Specifies a complete billing address for a payee.
    /// </summary>
    public class Payee : OfxObjectBase
    {
        #region Public properties
        /// <summary>
        /// ADDR1. Payee address, line 1, A-32.
        /// </summary>
        [NodeInfo("ADDR1")]
        public string Address1
        {
            get;
            private set;
        }

        /// <summary>
        /// ADDR2. Payee address, line 2, A-32.
        /// </summary>
        [NodeInfo("ADDR2")]
        public string Address2
        {
            get;
            private set;
        }

        /// <summary>
        /// ADDR3. Payee address, line 3, A-32.
        /// </summary>
        [NodeInfo("ADDR3")]
        public string Address3
        {
            get;
            private set;
        }

        /// <summary>
        /// CITY. Payee address city, A-32.
        /// </summary>
        [NodeInfo("CITY")]
        public string City
        {
            get;
            private set;
        }

        /// <summary>
        /// COUNTRY. Payee address country; 3-letter country code from ISO/DIS-3166, A-3.
        /// </summary>
        [NodeInfo("COUNTRY")]
        public string Country
        {
            get;
            private set;
        }

        /// <summary>
        /// DAYSTOPAY. Gets the number of days before payment occurs.
        /// </summary>
        [NodeInfo("DAYSTOPAY")]
        public int DaysToPay
        {
            get;
            private set;
        }

        /// <summary>
        /// PAYEELSTID. List id for the payee.
        /// </summary>
        [NodeInfo("PAYEELSTID")]
        public string ListId
        {
            get;
            private set;
        }

        /// <summary>
        /// NAME. Name of payee.A-32
        /// </summary>
        [NodeInfo("NAME")]
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// PAYACCT. Payee account.
        /// </summary>
        [NodeInfo("PAYACCT")]
        public string PayAccount
        {
            get;
            private set;
        }

        /// <summary>
        /// PHONE. Payee's telephone number.
        /// </summary>
        [NodeInfo("PHONE")]
        public string Phone
        {
            get;
            private set;
        }

        /// <summary>
        /// POSTALCODE. Payee address postal code, A-11.
        /// </summary>
        [NodeInfo("POSTALCODE")]
        public string PostalCode
        {
            get;
            private set;
        }

        /// <summary>
        /// STATE. Payee address state, A-5.
        /// </summary>
        [NodeInfo("STATE")]
        public string State
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Payee"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal Payee(XmlNode rootNode)
        {
            // Note: When this constructor is called from the constructor of PayeeCollection, 
            // DaysToPay, ListId and PayAccount (if present) will be set because rootNode is at a higher
            // level than these items and GetNestedNode will find them.
            //
            // However, when calling this constructor from the constructor of Transaction, these items
            // will not get set because root node arrives here as PAYEE and these items are not nested
            // within. May need to revisit, but for now, going to leave it.
            if (rootNode != null)
            {
                Address1 = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(Address1))));
                Address2 = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(Address2))));
                Address3 = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(Address3))));
                City = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(City))));
                Country = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(Country))));
                DaysToPay = GetIntegerValue(GetNestedNode(rootNode, GetNodeName(nameof(DaysToPay))));
                ListId = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(ListId))));
                Name = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(Name))));
                PayAccount = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(PayAccount))));
                Phone = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(Phone))));
                PostalCode = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(PostalCode))));
                State = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(State))));
            }
        }
        #endregion
    }
}
