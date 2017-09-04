using System;
using System.Globalization;
using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents a single balance node.
    /// </summary>
    public class Balance : OfxObjectBase
    {
        #region Public properties
        /// <summary>
        /// Gets a boolean value that indicates if the balance is supported.
        /// If this property is false, do not use the other properties.
        /// </summary>
        public bool IsSupported
        {
            get;
            private set;
        }
        /// <summary>
        /// Gets the amount
        /// </summary>
        [NodeInfo("BALAMT")]
        public Decimal Amount
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the ledger balance date.
        /// </summary>
        [NodeInfo("DTASOF")]
        public DateTime Date
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="Balance"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal Balance(XmlNode rootNode)
        {
            IsSupported = false;
            if (rootNode != null)
            {
                Amount = GetDecimalValue(GetNestedNode(rootNode, GetNodeName(nameof(Amount))));
                Date = GetDateTimeValue(GetNestedNode(rootNode, GetNodeName(nameof(Date))));
                IsSupported = true;
            }
        }
        #endregion
    }
}