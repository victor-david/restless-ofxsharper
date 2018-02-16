using Restless.OfxSharper.Core;
using System;
using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents the base class used for security position. This class must be inherited.
    /// </summary>
    public abstract class SecurityPositionBase : OfxObjectBase
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
        /// Gets the name of the account this security is held in.
        /// </summary>
        [NodeInfo("HELDINACCT", Required = true)]
        public string HeldInAccount
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the ticker of this security
        /// </summary>
        [NodeInfo("POSTYPE", Required = true)]
        public string PositionType
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the number of units for this security.
        /// </summary>
        [NodeInfo("UNITS", Required = true)]
        public Decimal Units
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the current price of this security.
        /// </summary>
        [NodeInfo("UNITPRICE", Required = true)]
        public Decimal UnitPrice
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the current market value of this security.
        /// </summary>
        [NodeInfo("MKTVAL", Required = true)]
        public Decimal MarketValue
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the as of date for the price information contained in this security.
        /// </summary>
        [NodeInfo("DTPRICEASOF", Required = false)]
        public DateTime? DateAsOf
        {
            get;
            private set;
        }

        // TODO Currency
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityPositionBase"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal SecurityPositionBase(XmlNode rootNode)
        {
            if (rootNode != null)
            {
                Id = new SecurityId(GetNestedNode(rootNode, SecurityId.NodeName));
                HeldInAccount = GetNodeValue(rootNode, nameof(HeldInAccount));
                PositionType = GetNodeValue(rootNode, nameof(PositionType));
                Units = GetDecimalValue(rootNode, nameof(Units));
                UnitPrice = GetDecimalValue(rootNode, nameof(UnitPrice));
                MarketValue = GetDecimalValue(rootNode, nameof(MarketValue));
                DateAsOf = GetNullableDateTimeValue(rootNode, nameof(DateAsOf));
            }
        }
        #endregion
    }
}
