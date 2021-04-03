using Restless.OfxSharper.Core;
using Restless.OfxSharper.Resources;
using System;
using System.Text;

namespace Restless.OfxSharper.Builder
{
    /// <summary>
    /// Represents the base class for a builder component defined by its message set. This class must be inherited.
    /// </summary>
    public abstract class OfxMessageSetBuilderBase : OfxMessageSetBase1
    {
        #region Private
        #endregion

        /************************************************************************/

        #region Public fields
        #endregion

        /************************************************************************/

        #region Public properties
        #endregion

        /************************************************************************/

        #region Protected properties
        /// <summary>
        /// From a derived class gets the builder object.
        /// </summary>
        protected StringBuilder Builder
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="OfxMessageSetBuilderBase"/> class.
        /// </summary>
        /// <param name="messageSetVersion">The message set version to use.</param>
        internal OfxMessageSetBuilderBase(StringBuilder builder, int messageSetVersion) : base(messageSetVersion)
        {
            ValidateNull(builder, nameof(builder));
            Builder = builder;
        }
        #endregion

        /************************************************************************/

        #region Public methods
        /// <summary>
        /// Builds the message set.
        /// </summary>
        /// <param name="buildCallback">
        /// Use this callback method to call specific build methods that will build inside the message set.
        /// </param>
        /// <remarks>
        /// If a dervived class requires special handling for the creation of the message set,
        /// it can override this method. Do not call the base class. Call <see cref="StartMessageSet"/>
        /// and <see cref="EndMessageSet"/> with other appropiate build tasks in between.
        /// </remarks>
        public virtual void BuildMessageSet(Action buildCallback)
        {
            ValidateNull(buildCallback, nameof(buildCallback));
            StartMessageSet();
            buildCallback();
            EndMessageSet();
        }
        #endregion

        /************************************************************************/

        #region Protected methods
        /// <summary>
        /// Starts the message set using <see cref="MessageSetName"/>.
        /// </summary>
        protected void StartMessageSet()
        {
            Builder.AppendLine($"<{MessageSetName1}>");
        }

        /// <summary>
        /// Ends the message set using <see cref="MessageSetName"/>.
        /// </summary>
        protected void EndMessageSet()
        {
            Builder.AppendLine($"</{MessageSetName1}>");
        }

        /// <summary>
        /// Validates that <paramref name="account"/> is non null and is one of the specifed types.
        /// </summary>
        /// <param name="types">The types</param>
        protected void ValidateAccount(IAccount account, params AccountType[] types)
        {
            ValidateNull(account, nameof(account));
            foreach (AccountType type in types)
            {
                // If account matches one of the passed types, done.
                if (account.AccountType == type)
                {
                    return;
                }
            }
            // no match. throw exception.
            throw new OfxException(Strings.InvalidOperationAccountType);
        }

        /// <summary>
        /// Builds the TRNUID tag and gives it a unique transaction id
        /// </summary>
        protected void BuildTransactionId()
        {
            Guid transId = Guid.NewGuid();
            Builder.AppendLine($"<TRNUID>{transId}");
        }

        /// <summary>
        /// Builds the TOKEN tag. If <paramref name="token"/> is null or empty string, will set to "0"
        /// </summary>
        /// <param name="token">The token. If null or empty string, will set to "0"</param>
        protected void BuildToken(string token)
        {
            if (String.IsNullOrEmpty(token)) token = "0";
            Builder.AppendLine($"<TOKEN>{token}");
        }


        /// <summary>
        /// Builds an account from aggregate. 
        /// The type of aggregate depends on the type of account.
        /// May be: BANKACCTFROM, CCACCTFROM, or INVACCTFROM.
        /// </summary>
        /// <param name="account">The account.</param>
        protected void BuildAccountFrom(IAccount account)
        {
            ValidateNull(account, nameof(account));
            switch (account.AccountType)
            {
                case AccountType.Bank:
                    BuildBankAccountFrom(account);
                    break;
                case AccountType.CreditCard:
                    BuildCreditCardAccountFrom(account);
                    break;
                case AccountType.Investment:
                    BuildInvestmentAccountFrom(account);
                    break;
                default:
                    throw new OfxException(Strings.InvalidOperationAccountType);
            }
        }

        /// <summary>
        /// Builds an account to aggregate. 
        /// The type of aggregate depends on the type of account.
        /// May be: BANKACCTTO or CCACCTTO.
        /// </summary>
        /// <param name="account">The account.</param>
        protected void BuildAccountTo(IAccount account)
        {
            ValidateNull(account, nameof(account));
            switch (account.AccountType)
            {
                case AccountType.Bank:
                    BuildBankAccountTo(account);
                    break;
                case AccountType.CreditCard:
                    BuildCreditCardAccountTo(account);
                    break;
                default:
                    throw new OfxException(Strings.InvalidOperationAccountType);
            }
        }




        /// <summary>
        /// Builds the INCTRAN aggregate if specified
        /// </summary>
        /// <param name="dateStart">The starting date, or null.</param>
        /// <param name="dateEnd">The ending date, or null.</param>
        /// <param name="includeTrans">true to request that the server include transactions</param>
        protected void BuildIncludeTransactionsIf(DateTime? dateStart, DateTime? dateEnd, bool includeTrans)
        {
            if (!includeTrans)
            {
                dateStart = dateEnd = null;
            }

            Builder.AppendLine("<INCTRAN>");
            BuildDateIf("<DTSTART>", dateStart);
            BuildDateIf("<DTEND>", dateEnd);
            Builder.AppendLine($"<INCLUDE>{BooleanToString(includeTrans)}");
            Builder.AppendLine("</INCTRAN>");
        }

        /// <summary>
        /// Builds a date tag if the date is not null.
        /// </summary>
        /// <param name="tag">The tag to use if date isn't null</param>
        /// <param name="date">The date</param>
        protected void BuildDateIf(string tag, DateTime? date)
        {
            if (date != null)
            {
                Builder.AppendLine(String.Format("{0}{1}", tag, ((DateTime)date).ToDateString()));
            }
        }
        #endregion

        /************************************************************************/

        #region Private methods (Account From aggregate builders)
        /// <summary>
        /// Builds the BANKACCTFROM aggregate.
        /// </summary>
        /// <param name="account">The account.</param>
        private void BuildBankAccountFrom(IAccount account)
        {
            Builder.AppendLine("<BANKACCTFROM>");
            Builder.AppendLine(String.Format("<BANKID>{0}", account.BankId));
            Builder.AppendLine(String.Format("<ACCTID>{0}", account.AccountId));
            Builder.AppendLine(String.Format("<ACCTTYPE>{0}", account.BankAccountType.ToUpperString()));
            Builder.AppendLine("</BANKACCTFROM>");
        }

        /// <summary>
        /// Builds the CCACCTFROM aggregate.
        /// </summary>
        /// <param name="account">The account.</param>
        private void BuildCreditCardAccountFrom(IAccount account)
        {
            Builder.AppendLine("<CCACCTFROM>");
            Builder.AppendLine($"<ACCTID>{account.AccountId}");
            Builder.AppendLine("</CCACCTFROM>");
        }

        /// <summary>
        /// Builds the INVACCTFROM aggregate.
        /// </summary>
        /// <param name="account">The account.</param>
        private void BuildInvestmentAccountFrom(IAccount account)
        {
            Builder.AppendLine("<INVACCTFROM>");
            Builder.AppendLine($"<BROKERID>{account.BankId}");
            Builder.AppendLine($"<ACCTID>{account.AccountId}");
            Builder.AppendLine("</INVACCTFROM>");
        }
        #endregion

        /************************************************************************/

        #region Private methods (Account To aggregate builders)
        /// <summary>
        /// Builds the BANKACCTTO aggregate.
        /// </summary>
        /// <param name="account">The account.</param>
        private void BuildBankAccountTo(IAccount account)
        {
            Builder.AppendLine("<BANKACCTTO>");
            Builder.AppendLine($"<BANKID>{account.BankId}");
            Builder.AppendLine($"<ACCTID>{account.AccountId}");
            Builder.AppendLine($"<ACCTTYPE>{account.BankAccountType.ToUpperString()}");
            Builder.AppendLine("</BANKACCTTO>");
        }

        /// <summary>
        /// Builds the CCACCTTO aggregate.
        /// </summary>
        /// <param name="account">The account.</param>
        private void BuildCreditCardAccountTo(IAccount account)
        {
            Builder.AppendLine("<CCACCTTO>");
            Builder.AppendLine($"<ACCTID>{account.AccountId}");
            Builder.AppendLine("</CCACCTTO>");
        }
        #endregion
    }
}
