using Restless.OfxSharper.Statement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Restless.OfxSharper.Core
{
    public class CurrencyAggregate : OfxObjectBase
    {
        #region Private
        private const string CurrencyNodeName = "CURRENCY";
        private const string OrigCurrencyNodeName = "ORIGCURRENCY";
        #endregion

        /************************************************************************/

        #region Public properties
        /// <summary>
        /// Gets the source of the currency.
        /// </summary>
        public CurrencySource Source
        {
            get;
            private set;
        }

        /// <summary>
        /// gets the ISO-4217 three-letter currency identifier.
        /// </summary>
        [NodeInfo("CURSYM", Required = false)]
        public string Symbol
        {
            get;
            private set;
        }

        /// <summary>
        /// Ratio of the default currency to <see cref="Symbol"/> currency, in decimal form.
        /// </summary>
        [NodeInfo("CURRATE", Required = false)]
        public Decimal CurrentRate
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyAggregate"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        /// <param name="owner">The statement that owns the currency aggregate.</param>
        internal CurrencyAggregate(XmlNode rootNode, CommonStatementBase owner)
        {
            // Null values here indicate programmer error.
            ValidateNull(rootNode, nameof(rootNode));
            ValidateNull(owner, nameof(owner));

            CurrentRate = 1;
            Symbol = owner.DefaultCurrency;
            Source = CurrencySource.DefaultCurrency;

            var currencyNode = GetNestedNode(rootNode, CurrencyNodeName);
            if (currencyNode == null)
            {
                currencyNode = GetNestedNode(rootNode, OrigCurrencyNodeName);
            }

            if (currencyNode != null)
            {
                Source = currencyNode.Name == CurrencyNodeName ? CurrencySource.Currency : CurrencySource.OriginalCurrency;
                Symbol = GetNodeValue(currencyNode, nameof(Symbol));
                CurrentRate = GetDecimalValue(currencyNode, nameof(CurrentRate));
            }
        }
        #endregion

        /************************************************************************/

        #region Public methods
        public override string ToString()
        {
            return $"CurrencyAggregate--Symbol:{Symbol} Rate:{CurrentRate} Source:{Source}";
        }
        #endregion
    }
}
