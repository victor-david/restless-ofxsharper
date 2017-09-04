using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents a single closing statement period for a credit card account.
    /// </summary>
    public class CreditCardClosingStatementPeriod : ClosingStatementPeriod
    {
        #region Public properties
        /// <summary>
        /// DTPMTDUE. Payment due date, date
        /// </summary>
        [NodeInfo("DTPMTDUE", Required = false)]
        public DateTime? PaymentDueDate
        {
            get;
            private set;
        }

        /// <summary>
        /// MINPMTDUE. Minimum amount due, amount
        /// </summary>
        [NodeInfo("MINPMTDUE", Required = false)]
        public Decimal MinimumPaymentDue
        {
            get;
            private set;
        }

        /// <summary>
        /// FINCHG. Finance charges, amount
        /// </summary>
        [NodeInfo("FINCHG", Required = false)]
        public Decimal FinanceCharge
        {
            get;
            private set;
        }

        /// <summary>
        /// PAYANDCREDIT. Total of payments and credits, amount
        /// </summary>
        [NodeInfo("PAYANDCREDIT", Required = false)]
        public Decimal TotalPayments
        {
            get;
            private set;
        }

        /// <summary>
        /// PURANDADV. Total of purchases and cash advances, amount
        /// </summary>
        [NodeInfo("PURANDADV", Required = false)]
        public Decimal TotalPurchases
        {
            get;
            private set;
        }

        /// <summary>
        /// DEBADJ. Debit adjustments, amount
        /// </summary>
        [NodeInfo("DEBADJ", Required = false)]
        public Decimal DebitAdjustments
        {
            get;
            private set;
        }

        /// <summary>
        /// CREDITLIMIT. Current credit limit, amount
        /// </summary>
        [NodeInfo("CREDITLIMIT", Required = false)]
        public Decimal CreditLimit
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CreditCardClosingStatementPeriod"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor exists to satisfy internal architectural requirements and is not meant to be used
        /// by user code. This constructor will not initialize the object.
        /// </remarks>
        public CreditCardClosingStatementPeriod()
        {
        }
        #endregion

        /************************************************************************/

        #region Protected methods
        /// <summary>
        /// Initializes this instance of the <see cref="CreditCardClosingStatementPeriod"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        /// <param name="defaultCurrency">The default currency for the closing statement.</param>
        protected internal override void Construct(XmlNode rootNode, string defaultCurrency)
        {
            base.Construct(rootNode, defaultCurrency);
            if (rootNode != null)
            {
                PaymentDueDate = GetNullableDateTimeValue(rootNode, nameof(PaymentDueDate));
                MinimumPaymentDue = GetDecimalValue(rootNode, nameof(MinimumPaymentDue));
                FinanceCharge = GetDecimalValue(rootNode, nameof(FinanceCharge));
                TotalPayments = GetDecimalValue(rootNode, nameof(TotalPayments));
                TotalPurchases = GetDecimalValue(rootNode, nameof(TotalPurchases));
                DebitAdjustments = GetDecimalValue(rootNode, nameof(DebitAdjustments));
                CreditLimit = GetDecimalValue(rootNode, nameof(CreditLimit));
            }
        }
        #endregion
    }
}
