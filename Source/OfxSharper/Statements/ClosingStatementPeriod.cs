using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents the base class for a closing statement period. This class must be inherited.
    /// </summary>
    public abstract class ClosingStatementPeriod : OfxObjectBase
    {
        #region Public properties
        /// <summary>
        /// FITID. Unique identifier for this statement, FITID
        /// </summary>
        [NodeInfo("FITID", Required = true)]
        public string TransactionId
        {
            get;
            private set;
        }

        /// <summary>
        /// DTOPEN. Opening statement date, date
        /// </summary>
        [NodeInfo("DTOPEN", Required = false)]
        public DateTime? OpeningDate
        {
            get;
            private set;
        }

        /// <summary>
        /// DTCLOSE. Closing statement date, date
        /// </summary>
        [NodeInfo("DTCLOSE", Required = true)]
        public DateTime ClosingDate
        {
            get;
            private set;
        }

        /// <summary>
        /// DTNEXT. Closing date of next statement, date
        /// </summary>
        [NodeInfo("DTNEXT", Required = false)]
        public DateTime? NextClosingDate
        {
            get;
            private set;
        }

        /// <summary>
        /// BALOPEN. Opening statement balance, amount
        /// </summary>
        [NodeInfo("BALOPEN", Required = false)]
        public Decimal OpeningBalance
        {
            get;
            private set;
        }

        /// <summary>
        /// BALCLOSE. Closing statement balance, amount
        /// </summary>
        [NodeInfo("BALCLOSE", Required = true)]
        public Decimal ClosingBalance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets CURRENCY or ORIGCURRENCY or the default.
        /// </summary>
        [NodeInfo("CURRENCY")]
        public string Currency
        {
            get;
            private set;
        }

        /// <summary>
        /// DTPOSTSTART. Start date of transaction data for this statement, date. 
        /// A client should be able to use this date in a STMTRQ to request transactions that match this statement.
        /// </summary>
        [NodeInfo("DTPOSTSTART", Required = true)]
        public DateTime PostStart
        {
            get;
            private set;
        }

        /// <summary>
        /// DTPOSTEND End date of transaction data for this statement, date. 
        /// A client should be able to use this date in a STMTRQ to request transactions that match this statement.
        /// </summary>
        [NodeInfo("DTPOSTEND", Required = true)]
        public DateTime PostEnd
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (protected)
        /// <summary>
        /// Initializes a new instance of the <see cref="ClosingStatementPeriod"/> class.
        /// </summary>
        protected ClosingStatementPeriod()
        {
        }
        #endregion

        /************************************************************************/

        #region Protected methods
        /// <summary>
        /// Initializes this instance of the <see cref="ClosingStatementPeriod"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        /// <param name="defaultCurrency">The default currency for the closing statement.</param>
        /// <remarks>
        /// This method exists to satisfy internal architectural requirements. A derived class must override this
        /// method and also call the base method in order to fully initialize the object.
        /// </remarks>
        protected internal virtual void Construct(XmlNode rootNode, string defaultCurrency)
        {
            if (rootNode != null)
            {
                TransactionId = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(TransactionId))));
                OpeningDate = GetNullableDateTimeValue(rootNode, nameof(OpeningDate));
                ClosingDate = GetDateTimeValue(rootNode, nameof(ClosingDate));
                NextClosingDate = GetNullableDateTimeValue(rootNode, nameof(NextClosingDate));
                OpeningBalance = GetDecimalValue(rootNode, nameof(OpeningBalance));
                ClosingBalance = GetDecimalValue(rootNode, nameof(ClosingBalance));
                PostStart = GetDateTimeValue(rootNode, nameof(PostStart));
                PostEnd = GetDateTimeValue(rootNode, nameof(PostEnd));
                Currency = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(Currency))));
                if (String.IsNullOrEmpty(Currency))
                {
                    Currency = GetNodeValue(GetNestedNode(rootNode, "ORIGCURRENCY"));
                    if (String.IsNullOrEmpty(Currency))
                    {
                        Currency = defaultCurrency;
                    }
                }
            }
        }
        #endregion
    }
}
