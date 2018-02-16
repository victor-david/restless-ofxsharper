using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents the base class used for security info.
    /// </summary>
    public abstract class SecurityInfoBase : OfxObjectBase
    {
        #region Public properties
        /// <summary>
        /// When implemented in a derived class, gets the type of security.
        /// </summary>
        public abstract SecurityType SecurityType
        {
            get;
        }

        /// <summary>
        /// Gets the id of this security.
        /// </summary>
        [NodeInfo("SECID", Required = true)]
        public SecurityId Id
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the name of this security
        /// </summary>
        [NodeInfo("SECNAME", Required = true)]
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the ticker of this security
        /// </summary>
        [NodeInfo("TICKER", Required = false)]
        public string Ticker
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the financial institution assigned id for this security.
        /// </summary>
        [NodeInfo("FIID", Required = false)]
        public string FinancialId
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the rating assigned to this security.
        /// </summary>
        [NodeInfo("RATING", Required = false)]
        public string Rating
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the current price of this security.
        /// </summary>
        [NodeInfo("UNITPRICE", Required = false)]
        public Decimal? UnitPrice
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the as of date for the information contained in this security.
        /// </summary>
        [NodeInfo("DTASOF", Required = false)]
        public DateTime? DateAsOf
        {
            get;
            private set;
        }

        // TODO Currency

        /// <summary>
        /// Gets an associated memo for this security.
        /// </summary>
        [NodeInfo("MEMO", Required = false)]
        public string Memo
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (protected)
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityInfoBase"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        protected SecurityInfoBase(XmlNode rootNode)
        {
            if (rootNode != null)
            {
                Id = new SecurityId(GetNestedNode(rootNode, SecurityId.SecurityIdNode));
                Name = GetNodeValue(rootNode, nameof(Name));
                Ticker = GetNodeValue(rootNode, nameof(Ticker));
                FinancialId = GetNodeValue(rootNode, nameof(FinancialId));
                Rating = GetNodeValue(rootNode, nameof(Rating));
                UnitPrice = GetDecimalValue(rootNode, nameof(UnitPrice));
                DateAsOf = GetNullableDateTimeValue(rootNode, nameof(DateAsOf));
                Memo = GetNodeValue(rootNode, nameof(Memo));
            }
        }
        #endregion
    }
}
