using Restless.OfxSharper.Core;
using System;
using System.Text;

namespace Restless.OfxSharper.Builder
{
    /// <summary>
    /// Provides services to build OFX requests for the investment message set, INVSTMTMSGSRQV1.
    /// </summary>
    public class OfxInvestmentMessageSetBuilder : OfxMessageSetBuilderBase
    {
        #region Protected properties
        /// <summary>
        /// Gets the name of the message set that this builder uses.
        /// </summary>
        protected override string MessageSetName1
        {
            get => $"INVSTMTMSGSRQV{MessageSetVersion}"; 
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="OfxInvestmentMessageSetBuilder"/> class.
        /// </summary>
        /// <param name="builder">The builder object.</param>
        /// <param name="messageSetVersion">The message set version to use.</param>
        internal OfxInvestmentMessageSetBuilder(StringBuilder builder, int messageSetVersion) : base(builder, messageSetVersion)
        {
        }
        #endregion

        /************************************************************************/

        #region Public methods
        /// <summary>
        /// Build an investmentstatement request, INVSTMTTRNRQ.
        /// This method must be called from the callback method of <see cref="OfxMessageSetBuilderBase.BuildMessageSet(Action)"/>
        /// </summary>
        /// <param name="account">The account</param>
        /// <param name="options">Options for the request.</param>
        public void BuildStatementRequest(IAccount account, InvestmentDownloadOptions options)
        {
            ValidateAccount(account, AccountType.Investment);
            ValidateNull(options, nameof(options));
            Builder.AppendLine("<INVSTMTTRNRQ>");
            BuildTransactionId();
            Builder.AppendLine("<INVSTMTRQ>");
            BuildAccountFrom(account);
            BuildIncludeTransactionsIf(options.TransactionStart, options.TransactionEnd, options.IncludeTransactions);
            Builder.AppendLine($"<INCOO>{BooleanToString(options.IncludeOpenOrders)}");
            BuildIncludePositionIf(options.PositionDate, options.IncludePosition);
            Builder.AppendLine($"<INCBAL>{BooleanToString(options.IncludeBalance)}");
            Builder.AppendLine("</INVSTMTRQ>");
            Builder.AppendLine("</INVSTMTTRNRQ>");
        }
        #endregion

        /************************************************************************/

        #region Private methods
        /// <summary>
        /// Builds the INCTRAN aggregate if specified
        /// </summary>
        /// <param name="dateStart">The starting date, or null.</param>
        /// <param name="dateEnd">The ending date, or null.</param>
        /// <param name="includePos">true to request that the server include transactions</param>
        private void BuildIncludePositionIf(DateTime? date, bool includePos)
        {
            if (!includePos)
            {
                date = null;
            }

            Builder.AppendLine("<INCPOS>");
            BuildDateIf("<DTASOF>", date);
            Builder.AppendLine($"<INCLUDE>{BooleanToString(includePos)}");
            Builder.AppendLine("</INCPOS>");
        }
        #endregion
    }
}
