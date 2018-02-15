using System;
using System.Text;

namespace Restless.OfxSharper.Builder
{
    /// <summary>
    /// Provides services to build OFX requests for the bank message set, BANKMSGSRQV1.
    /// </summary>
    public class OfxBankMessageSetBuilder : OfxMessageSetBuilderBase
    {
        #region Protected properties
        /// <summary>
        /// Gets the name of the message set that this builder uses.
        /// </summary>
        protected override string MessageSetName
        {
            get => $"BANKMSGSRQV{MessageSetVersion}";
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="OfxBankMessageSetBuilder"/> class.
        /// </summary>
        /// <param name="builder">The builder object.</param>
        internal OfxBankMessageSetBuilder(StringBuilder builder) : base(builder)
        {
        }
        #endregion

        /************************************************************************/

        #region Public methods
        /// <summary>
        /// Build a bank statement request, STMTTRNRQ.
        /// This method must be called from the callback method of <see cref="OfxMessageSetBuilderBase.BuildMessageSet(Action)"/>
        /// </summary>
        /// <param name="account">The account</param>
        /// <param name="dateStart">The starting date, or null for none (server will decide)</param>
        /// <param name="dateEnd">The ending date, or null for none (server will decide)</param>
        /// <param name="includeTransactions">true to include transactions.</param>
        public void BuildStatementRequest(IAccount account, DateTime? dateStart, DateTime? dateEnd, bool includeTransactions)
        {
            ValidateAccount(account, AccountType.Bank);
            Builder.AppendLine("<STMTTRNRQ>");
            BuildTransactionId();
            Builder.AppendLine("<STMTRQ>");
            BuildAccountFrom(account);
            BuildIncludeTransactionsIf(dateStart, dateEnd, includeTransactions);
            Builder.AppendLine("</STMTRQ>");
            Builder.AppendLine("</STMTTRNRQ>");
        }


        /// <summary>
        /// Build a bank closing statement request, STMTENDTRNRQ.
        /// This method must be called from the callback method of <see cref="OfxMessageSetBuilderBase.BuildMessageSet(Action)"/>
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="dateStart">The date to start, or null.</param>
        /// <param name="dateEnd">The date to end, or null.</param>
        public void BuildClosingStatementRequest(IAccount account, DateTime? dateStart, DateTime? dateEnd)
        {
            ValidateAccount(account, AccountType.Bank);
            Builder.AppendLine("<STMTENDTRNRQ>");
            BuildTransactionId();
            Builder.AppendLine("<STMTENDRQ>");
            BuildAccountFrom(account);
            BuildDateIf("<DTSTART>", dateStart);
            BuildDateIf("<DTEND>", dateEnd);
            Builder.AppendLine("</STMTENDRQ>");
            Builder.AppendLine("</STMTENDTRNRQ>");
        }

        /// <summary>
        /// Build a bank mail synchronization request, BANKEMAILSYNCRQ.
        /// This method must be called from the callback method of <see cref="OfxMessageSetBuilderBase.BuildMessageSet(Action)"/>
        /// </summary>
        /// <param name="account">The account. Must be type Bank or CreditCard</param>
        /// <param name="token">The starting message token, or null for none (server will decide)</param>
        public void BuildMailSynchronizationRequest(IAccount account, string token)
        {
            ValidateAccount(account, AccountType.Bank, AccountType.CreditCard);
            Builder.AppendLine("<BANKMAILSYNCRQ>");
            BuildToken(token);
            Builder.AppendLine("<REJECTIFMISSING>N");
            Builder.AppendLine("<INCIMAGES>N");
            Builder.AppendLine("<USEHTML>N");
            BuildAccountFrom(account);
            Builder.AppendLine("</BANKMAILSYNCRQ>");
        }

        /// <summary>
        /// Build a intra bank transfer request, INTRATRNRQ.
        /// This method must be called from the callback method of <see cref="OfxMessageSetBuilderBase.BuildMessageSet(Action)"/>
        /// </summary>
        /// <param name="sourceAcct">The source account. Must be type: Bank.</param>
        /// <param name="destAcct">The destination account. Must be type: Bank or CreditCard</param>
        /// <param name="amount">The amount to transfer.</param>
        public void BuildIntraBankTransferRequest(IAccount sourceAcct, IAccount destAcct, Decimal amount)
        {
            ValidateAccount(sourceAcct, AccountType.Bank);
            ValidateAccount(destAcct, AccountType.Bank, AccountType.CreditCard);
            ValidateOfxOperation(amount <= 0, Resources.Strings.InvalidOperationTransferAmount);
            Builder.AppendLine("<INTRATRNRQ>");
            BuildTransactionId();
            Builder.AppendLine("<INTRARQ>");
            Builder.AppendLine("<XFERINFO>");
            BuildAccountFrom(sourceAcct);
            BuildAccountTo(destAcct);
            Builder.AppendLine(String.Format("<TRNAMT>{0}", amount.ToString("N2")));
            Builder.AppendLine("</XFERINFO>");
            Builder.AppendLine("</INTRARQ>");
            Builder.AppendLine("</INTRATRNRQ>");
        }

        /// <summary>
        /// Builds an intra bank syncronization request for the specified account, INTRASYNCRQ.
        /// This method must be called from the callback method of <see cref="OfxMessageSetBuilderBase.BuildMessageSet(Action)"/>
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="token">The starting message token, or null for none (server will decide)</param>
        public void BuildIntraBankTransferSyncRequest(IAccount account, string token)
        {
            ValidateAccount(account, AccountType.Bank);
            Builder.AppendLine("<INTRASYNCRQ>");
            BuildToken(token);
            Builder.AppendLine("<REFRESH>Y");
            Builder.AppendLine("<REJECTIFMISSING>N");
            BuildAccountFrom(account);
            Builder.AppendLine("</INTRASYNCRQ>");
        }
        #endregion
    }
}
