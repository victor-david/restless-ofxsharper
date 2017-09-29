using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Provides mechanisms for building an Ofx request.
    /// </summary>
    public sealed class OfxRequestBuilder : OfxObjectBase
    {
        #region Private
        private StringBuilder builder;
        #endregion

        /************************************************************************/

        #region Public properties    
        /// <summary>
        /// Gets the request text that was generated.
        /// </summary>
        public string RequestText => builder.ToString();
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="OfxRequestBuilder"/> class.
        /// </summary>
        internal OfxRequestBuilder()
        {
            builder = new StringBuilder(1024);
        }
        #endregion

        /************************************************************************/

        #region Public methods
        /// <summary>
        /// Builds an Ofx request. This is the top level method you must call. All other calls
        /// are nested via <paramref name="buildCallback"/>.
        /// </summary>
        /// <param name="buildCallback">Callback method. Use this method to call other build methods</param>
        /// <param name="oldFileId">The old file id, or null to use NONE.</param>
        /// <param name="newFileId">The new file id, or null to use NONE.</param>
        public void BuildOfxRequest(Action buildCallback, string oldFileId = null, string newFileId = null)
        {
            ValidateNull(buildCallback, nameof(buildCallback));
            builder.Clear();
            // Create the header
            if (String.IsNullOrEmpty(oldFileId)) oldFileId = "NONE";
            if (String.IsNullOrEmpty(newFileId)) newFileId = "NONE";
            builder.AppendLine("OFXHEADER:100");
            builder.AppendLine("DATA:OFXSGML");
            builder.AppendLine("VERSION:102");
            builder.AppendLine("SECURITY:NONE");
            builder.AppendLine("ENCODING:USASCII");
            builder.AppendLine("CHARSET:1252");
            builder.AppendLine("COMPRESSION:NONE");
            builder.AppendLine(String.Format("OLDFILEUID:{0}", oldFileId));
            builder.AppendLine(String.Format("NEWFILEUID:{0}", newFileId));
            builder.AppendLine();
            builder.AppendLine("<OFX>");
            buildCallback();
            builder.AppendLine("</OFX>");
        }

        /// <summary>
        /// Builds a signon message set, SIGNONMSGSRQV1.
        /// This method must be called from the callback method of <see cref="BuildOfxRequest(Action, string, string)"/>
        /// </summary>
        /// <param name="bank">The bank</param>
        public void BuildSignOnMessageSet(IBank bank)
        {
            ValidateNull(bank, nameof(bank));
            builder.AppendLine("<SIGNONMSGSRQV1>");
            builder.AppendLine("<SONRQ>");
            builder.AppendLine(String.Format("<DTCLIENT>{0}", DateTime.Now.ToString("yyyyMMddhhmmss")));
            builder.AppendLine(String.Format("<USERID>{0}", bank.UserId));
            builder.AppendLine(String.Format("<USERPASS>{0}", bank.Password));
            builder.AppendLine("<GENUSERKEY>N");
            builder.AppendLine(String.Format("<LANGUAGE>{0}", bank.OfxLanguage));
            builder.AppendLine("<FI>");
            builder.AppendLine(String.Format("<ORG>{0}", bank.Org));
            builder.AppendLine(String.Format("<FID>{0}", bank.OfxId));
            builder.AppendLine("</FI>");
            builder.AppendLine(String.Format("<APPID>{0}", bank.AppId));
            builder.AppendLine(String.Format("<APPVER>{0}", bank.AppVersion));
            builder.AppendLine("</SONRQ>");
            builder.AppendLine("</SIGNONMSGSRQV1>");
        }

        /// <summary>
        /// Builds a profile message set request, PROFMSGSRQV1.
        /// This method must be called from the callback method of <see cref="BuildOfxRequest(Action, string, string)"/>
        /// </summary>
        public void BuildProfileMessageSetRequest()
        {
            Guid transId = Guid.NewGuid();
            builder.AppendLine("<PROFMSGSRQV1>");
            builder.AppendLine("<PROFTRNRQ>");
            builder.AppendLine(String.Format("<TRNUID>{0}", transId));
            builder.AppendLine("<PROFRQ>");
            builder.AppendLine("<CLIENTROUTING>MSGSET");
            builder.AppendLine("<DTPROFUP>19970101");
            builder.AppendLine("</PROFRQ>");
            builder.AppendLine("</PROFTRNRQ>");
            builder.AppendLine("</PROFMSGSRQV1>");
        }

        /// <summary>
        /// Build a bank message set request, BANKMSGSRQV1.
        /// This method must be called from the callback method of <see cref="BuildOfxRequest(Action, string, string)"/>
        /// </summary>
        /// <param name="buildCallback">
        /// Use this callback method to call specific build methods that will build inside the bank message set.
        /// </param>
        public void BuildBankMessageSet(Action buildCallback)
        {
            ValidateNull(buildCallback, nameof(buildCallback));
            builder.AppendLine("<BANKMSGSRQV1>");
            buildCallback();
            builder.AppendLine("</BANKMSGSRQV1>");
        }

        /// <summary>
        /// Build a credit card message set request, CREDITCARDMSGSRQV1.
        /// This method must be called from the callback method of <see cref="BuildOfxRequest(Action, string, string)"/>
        /// </summary>
        /// <param name="buildCallback">
        /// Use this callback method to call specific build methods that will build inside the credit card message set.
        /// </param>
        public void BuildCreditCardMessageSet(Action buildCallback)
        {
            ValidateNull(buildCallback, nameof(buildCallback));
            builder.AppendLine("<CREDITCARDMSGSRQV1>");
            buildCallback();
            builder.AppendLine("</CREDITCARDMSGSRQV1>");
        }

        /// <summary>
        /// Build a bank statement request, STMTTRNRQ.
        /// This method must be called from the callback method of <see cref="BuildBankMessageSet(Action)"/>
        /// </summary>
        /// <param name="account">The account</param>
        /// <param name="dateStart">The starting date, or null for none (server will decide)</param>
        /// <param name="dateEnd">The ending date, or null for none (server will decide)</param>
        /// <param name="includeTransactions">true to include transactions.</param>
        public void BuildBankStatementRequest(IAccount account, DateTime? dateStart, DateTime? dateEnd, bool includeTransactions)
        {
            ValidateNull(account, nameof(account));
            ValidateOfxOperation(account.AccountType != AccountType.Bank, Resources.Strings.InvalidOperationAccountType);
            Guid transId = Guid.NewGuid();
            builder.AppendLine("<STMTTRNRQ>");
            builder.AppendLine(String.Format("<TRNUID>{0}", transId));
            builder.AppendLine("<STMTRQ>");
            BuildBankAccountFrom(account);
            BuildIncludeTransactionsIf(dateStart, dateEnd, includeTransactions);
            builder.AppendLine("</STMTRQ>");
            builder.AppendLine("</STMTTRNRQ>");
        }

        /// <summary>
        /// Build a credit card statement request, CCSTMTTRNRQ.
        /// This method must be called from the callback method of <see cref="BuildCreditCardMessageSet(Action)"/>
        /// </summary>
        /// <param name="account">The account</param>
        /// <param name="dateStart">The starting date, or null for none (server will decide)</param>
        /// <param name="dateEnd">The ending date, or null for none (server will decide)</param>
        /// <param name="includeTransactions">true to include transactions.</param>
        public void BuildCreditCardStatementRequest(IAccount account, DateTime? dateStart, DateTime? dateEnd, bool includeTransactions)
        {
            ValidateNull(account, nameof(account));
            ValidateOfxOperation(account.AccountType != AccountType.CreditCard, Resources.Strings.InvalidOperationAccountType);
            Guid transId = Guid.NewGuid();
            builder.AppendLine("<CCSTMTTRNRQ>");
            builder.AppendLine(String.Format("<TRNUID>{0}", transId));
            builder.AppendLine("<CCSTMTRQ>");
            BuildCreditCardAccountFrom(account);
            BuildIncludeTransactionsIf(dateStart, dateEnd, includeTransactions);
            builder.AppendLine("</CCSTMTRQ>");
            builder.AppendLine("</CCSTMTTRNRQ>");
        }

        /// <summary>
        /// Build a bank closing statement request, STMTENDTRNRQ.
        /// This method must be called from the callback method of <see cref="BuildBankMessageSet(Action)"/>
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="dateStart">The date to start, or null.</param>
        /// <param name="dateEnd">The date to end, or null.</param>
        public void BuildBankClosingStatementRequest(IAccount account, DateTime? dateStart, DateTime? dateEnd)
        {
            ValidateNull(account, nameof(account));
            ValidateOfxOperation(account.AccountType != AccountType.Bank, Resources.Strings.InvalidOperationAccountType);
            Guid transId = Guid.NewGuid();
            builder.AppendLine("<STMTENDTRNRQ>");
            builder.AppendLine(String.Format("<TRNUID>{0}", transId));
            builder.AppendLine("<STMTENDRQ>");
            BuildBankAccountFrom(account);
            BuildDateIf("<DTSTART>", dateStart);
            BuildDateIf("<DTEND>", dateEnd);
            builder.AppendLine("</STMTENDRQ>");
            builder.AppendLine("</STMTENDTRNRQ>");
        }

        /// <summary>
        /// Build a credit card closing statement request, CCSTMTENDTRNRQ.
        /// This method must be called from the callback method of <see cref="BuildCreditCardMessageSet(Action)"/>
        /// </summary>
        /// <param name="account">The account</param>
        /// <param name="dateStart">The starting date, or null for none (server will decide)</param>
        /// <param name="dateEnd">The ending date, or null for none (server will decide)</param>
        public void BuildCreditCardClosingStatementRequest(IAccount account, DateTime? dateStart, DateTime? dateEnd)
        {
            ValidateNull(account, nameof(account));
            ValidateOfxOperation(account.AccountType != AccountType.CreditCard, Resources.Strings.InvalidOperationAccountType);
            Guid transId = Guid.NewGuid();
            builder.AppendLine("<CCSTMTENDTRNRQ>");
            builder.AppendLine(String.Format("<TRNUID>{0}", transId));
            builder.AppendLine("<CCSTMTENDRQ>");
            BuildCreditCardAccountFrom(account);
            BuildDateIf("<DTSTART>", dateStart);
            BuildDateIf("<DTEND>", dateEnd);
            builder.AppendLine("</CCSTMTENDRQ>");
            builder.AppendLine("</CCSTMTENDTRNRQ>");
        }

        /// <summary>
        /// Build a intra bank transfer request.
        /// This method must be called from the callback method of <see cref="BuildBankMessageSet(Action)"/>
        /// </summary>
        /// <param name="sourceAcct">The source account.</param>
        /// <param name="destinationAcct">The destination account.</param>
        /// <param name="amount">The amount to transfer.</param>
        public void BuildIntraBankTransferRequest(IAccount sourceAcct, IAccount destinationAcct, Decimal amount)
        {
            ValidateNull(sourceAcct, nameof(sourceAcct));
            ValidateNull(destinationAcct, nameof(destinationAcct));
            ValidateOfxOperation(sourceAcct.AccountType != AccountType.Bank, Resources.Strings.InvalidOperationTransferSource);
            ValidateOfxOperation(destinationAcct.AccountType == AccountType.Unspecified, Resources.Strings.InvalidOperationTransferSource);
            ValidateOfxOperation(amount <= 0, Resources.Strings.InvalidOperationTransferAmount);
            Guid transId = Guid.NewGuid();
            builder.AppendLine("<INTRATRNRQ>");
            builder.AppendLine(String.Format("<TRNUID>{0}", transId));
            builder.AppendLine("<INTRARQ>");
            builder.AppendLine("<XFERINFO>");

            BuildBankAccountFrom(sourceAcct);

            switch (destinationAcct.AccountType)
            {
                case AccountType.Bank:
                    BuildBankAccountTo(destinationAcct);
                    break;
                case AccountType.CreditCard:
                    BuildCreditCardAccountTo(destinationAcct);
                    break;
                default:
                    throw new OfxException(Resources.Strings.InvalidOperationAccountType);
            }

            builder.AppendLine(String.Format("<TRNAMT>{0}", amount.ToString("N2")));
            builder.AppendLine("</XFERINFO>");
            builder.AppendLine("</INTRARQ>");
            builder.AppendLine("</INTRATRNRQ>");
        }

        /// <summary>
        /// Clears the builder
        /// </summary>
        public void Clear()
        {
            builder.Clear();
        }
        #endregion

        /************************************************************************/

        #region Private methods
        /// <summary>
        /// Builds the BANKACCTFROM aggregate.
        /// </summary>
        /// <param name="account">The account.</param>
        private void BuildBankAccountFrom(IAccount account)
        {
            builder.AppendLine("<BANKACCTFROM>");
            builder.AppendLine(String.Format("<BANKID>{0}", account.BankId));
            builder.AppendLine(String.Format("<ACCTID>{0}", account.AccountId));
            builder.AppendLine(String.Format("<ACCTTYPE>{0}", Enum.GetName(typeof(BankAccountType), account.BankAccountType).ToUpperInvariant()));
            builder.AppendLine("</BANKACCTFROM>");
        }

        /// <summary>
        /// Builds the BANKACCTTO aggregate.
        /// </summary>
        /// <param name="account">The account.</param>
        private void BuildBankAccountTo(IAccount account)
        {
            builder.AppendLine("<BANKACCTTO>");
            builder.AppendLine(String.Format("<BANKID>{0}", account.BankId));
            builder.AppendLine(String.Format("<ACCTID>{0}", account.AccountId));
            builder.AppendLine(String.Format("<ACCTTYPE>{0}", Enum.GetName(typeof(BankAccountType), account.BankAccountType).ToUpperInvariant()));
            builder.AppendLine("</BANKACCTTO>");
        }

        /// <summary>
        /// Builds the CCACCTFROM aggregate.
        /// </summary>
        /// <param name="account">The account.</param>
        private void BuildCreditCardAccountFrom(IAccount account)
        {
            builder.AppendLine("<CCACCTFROM>");
            builder.AppendLine(String.Format("<ACCTID>{0}", account.AccountId));
            builder.AppendLine("</CCACCTFROM>");
        }

        /// <summary>
        /// Builds the CCACCTTO aggregate.
        /// </summary>
        /// <param name="account">The account.</param>
        private void BuildCreditCardAccountTo(IAccount account)
        {
            builder.AppendLine("<CCACCTTO>");
            builder.AppendLine(String.Format("<ACCTID>{0}", account.AccountId));
            builder.AppendLine("</CCACCTTO>");
        }

        /// <summary>
        /// Builds the INCTRAN aggregate if specified
        /// </summary>
        /// <param name="dateStart">The starting date, or null.</param>
        /// <param name="dateEnd">The ending date, or null.</param>
        /// <param name="includeTrans">true to request that the server include transactions</param>
        private void BuildIncludeTransactionsIf(DateTime? dateStart, DateTime? dateEnd, bool includeTrans)
        {
            if (includeTrans)
            {
                builder.AppendLine("<INCTRAN>");
                BuildDateIf("<DTSTART>", dateStart);
                BuildDateIf("<DTEND>", dateEnd);
                builder.AppendLine("<INCLUDE>Y");
                builder.AppendLine("</INCTRAN>");
            }
        }

        /// <summary>
        /// Builds a date tag if the date is not null.
        /// </summary>
        /// <param name="tag">The tag to use if date isn't null</param>
        /// <param name="date">The date</param>
        private void BuildDateIf(string tag, DateTime? date)
        {
            if (date != null)
            {
                builder.AppendLine(String.Format("{0}{1}", tag, ((DateTime)date).ToDateString()));
            }
        }
        #endregion
    }
}
