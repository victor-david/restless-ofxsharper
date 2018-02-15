using System;
using System.Text;

namespace Restless.OfxSharper.Builder
{
    /// <summary>
    /// Provides services to build OFX requests for the credit card message set, CREDITCARDMSGSRQV1.
    /// </summary>
    public class OfxCreditCardMessageSetBuilder : OfxMessageSetBuilderBase
    {
        #region Protected properties
        /// <summary>
        /// Gets the name of the message set that this builder uses.
        /// </summary>
        protected override string MessageSetName
        {
            get => $"CREDITCARDMSGSRQV{MessageSetVersion}";
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="OfxCreditCardMessageSetBuilder"/> class.
        /// </summary>
        /// <param name="builder">The builder object.</param>
        internal OfxCreditCardMessageSetBuilder(StringBuilder builder) : base(builder)
        {

        }
        #endregion

        /************************************************************************/

        #region Public methods
        /// <summary>
        /// Build a credit card statement request, CCSTMTTRNRQ.
        /// This method must be called from the callback method of <see cref="OfxMessageSetBuilderBase.BuildMessageSet(Action)"/>
        /// </summary>
        /// <param name="account">The account</param>
        /// <param name="dateStart">The starting date, or null for none (server will decide)</param>
        /// <param name="dateEnd">The ending date, or null for none (server will decide)</param>
        /// <param name="includeTransactions">true to include transactions.</param>
        public void BuildStatementRequest(IAccount account, DateTime? dateStart, DateTime? dateEnd, bool includeTransactions)
        {
            ValidateAccount(account, AccountType.CreditCard);
            Builder.AppendLine("<CCSTMTTRNRQ>");
            BuildTransactionId();
            Builder.AppendLine("<CCSTMTRQ>");
            BuildAccountFrom(account);
            BuildIncludeTransactionsIf(dateStart, dateEnd, includeTransactions);
            Builder.AppendLine("</CCSTMTRQ>");
            Builder.AppendLine("</CCSTMTTRNRQ>");
        }
        
        /// <summary>
        /// Build a credit card closing statement request, CCSTMTENDTRNRQ.
        /// This method must be called from the callback method of <see cref="OfxMessageSetBuilderBase.BuildMessageSet(Action)"/>
        /// </summary>
        /// <param name="account">The account</param>
        /// <param name="dateStart">The starting date, or null for none (server will decide)</param>
        /// <param name="dateEnd">The ending date, or null for none (server will decide)</param>
        public void BuildClosingStatementRequest(IAccount account, DateTime? dateStart, DateTime? dateEnd)
        {
            ValidateAccount(account, AccountType.CreditCard);
            Builder.AppendLine("<CCSTMTENDTRNRQ>");
            BuildTransactionId();
            Builder.AppendLine("<CCSTMTENDRQ>");
            BuildAccountFrom(account);
            BuildDateIf("<DTSTART>", dateStart);
            BuildDateIf("<DTEND>", dateEnd);
            Builder.AppendLine("</CCSTMTENDRQ>");
            Builder.AppendLine("</CCSTMTENDTRNRQ>");
        }
        #endregion
    }
}
