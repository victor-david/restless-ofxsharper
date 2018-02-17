using Restless.OfxSharper.Core;
using System;
using System.Xml;

namespace Restless.OfxSharper.Statement
{
    /// <summary>
    /// Represents a single closing statement for a bank account.
    /// </summary>
    public class BankClosingStatementPeriod : ClosingStatementPeriod
    {
        #region Public properties
        /// <summary>
        /// BALMIN. Minimum balance in statement period, amount
        /// </summary>
        [NodeInfo("BALMIN")]
        public Decimal MinimumBalance
        {
            get;
            private set;
        }

        /// <summary>
        /// DEPANDCREDIT. Total of deposits and credits, including interest, amount
        /// </summary>
        [NodeInfo("DEPANDCREDIT")]
        public Decimal TotalDepositsAndCredits
        {
            get;
            private set;
        }

        /// <summary>
        /// CHKANDDEB. Total of checks and debits, including fees, amount
        /// </summary>
        [NodeInfo("CHKANDDEB")]
        public Decimal TotalChecksAndDebits
        {
            get;
            private set;
        }

        /// <summary>
        /// TOTALFEES. Total of all fees, amount
        /// </summary>
        [NodeInfo("TOTALFEES")]
        public Decimal TotalFees
        {
            get;
            private set;
        }

        /// <summary>
        /// TOTALINT. Total of all interest, amount
        /// </summary>
        [NodeInfo("TOTALINT")]
        public Decimal TotalInterest
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="BankClosingStatementPeriod"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor exists to satisfy internal architectural requirements and is not meant to be used
        /// by user code. This constructor will not initialize the object.
        /// </remarks>
        public BankClosingStatementPeriod()
        {
        }
        #endregion

        /************************************************************************/

        #region Protected methods
        /// <summary>
        /// Initializes this instance of the <see cref="BankClosingStatementPeriod"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        /// <param name="defaultCurrency">The default currency for the closing statement.</param>
        protected internal override void Construct(XmlNode rootNode, string defaultCurrency)
        {
            base.Construct(rootNode, defaultCurrency);
            if (rootNode != null)
            {
                MinimumBalance = GetDecimalValue(rootNode, nameof(MinimumBalance));
                TotalDepositsAndCredits =GetDecimalValue(rootNode, nameof(TotalDepositsAndCredits));
                TotalChecksAndDebits = GetDecimalValue(rootNode, nameof(TotalChecksAndDebits));
                TotalFees = GetDecimalValue(rootNode, nameof(TotalFees));
                TotalInterest = GetDecimalValue(rootNode, nameof(TotalInterest));
            }
        }
        #endregion
    }
}
