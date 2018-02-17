using Restless.OfxSharper.Accounts;
using Restless.OfxSharper.Core;
using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents information about a bank account, obtained via ACCTINFOTRNRQ
    /// </summary>
    public class AccountInfo : OfxObjectBase
    {
        private const string BankAccountInfo = "BANKACCTINFO";
        private const string CreditCardAccountInfo = "CCACCTINFO";
        private const string BillPayAccountInfo = "BPACCTINFO";
        private const string InvestmentAccountInfo = "INVACCTINFO";

        /// <summary>
        /// Gets the account.
        /// </summary>
        public AccountBase Account
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the account description.
        /// </summary>
        [NodeInfo("DESC")]
        public string Description
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service status
        /// </summary>
        [NodeInfo("SVCSTATUS")]
        public AccountInfoStatus Status
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a boolean value that indicates if transaction details are supported.
        /// </summary>
        [NodeInfo("SUPTXDL")]
        public bool AreDetailsSupported
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a boolean value that indicates if the account may be used as a transfer source.
        /// </summary>
        [NodeInfo("XFERSRC")]
        public bool IsTransferSource
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a boolean value that indicates if the account may be used as a transfer destination.
        /// </summary>
        [NodeInfo("XFERDEST")]
        public bool IsTransferDest
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a boolean value that indicates if the account can be used as a bill pay source.
        /// </summary>
        public bool IsBillPaySource
        {
            get;
            internal set;
        }

        /// <summary>
        /// This flag is set when account info is BPACCTINFO, and then used internally 
        /// by <see cref="AccountInfoCollection"/> to set the user visible flag <see cref="IsBillPaySource"/>
        /// before removing the BPACCTINFO from the collection. This simplifies things for the consumer
        /// of this service.
        /// </summary>
        internal bool IsBillPaySourceInternal
        {
            get;
            private set;
        }

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountInfo"/> class.
        /// </summary>
        internal AccountInfo(XmlNode rootNode) 
        {
            if (rootNode != null)
            {
                Description = GetNodeValue(rootNode, nameof(Description));
                Status = GetNodeValue(rootNode, nameof(Status)).ToAccountInfoStatus();
                AreDetailsSupported = GetBooleanValue(rootNode, nameof(AreDetailsSupported));
                IsTransferSource = GetBooleanValue(rootNode, nameof(IsTransferSource));
                IsTransferDest = GetBooleanValue(rootNode, nameof(IsTransferDest));
                XmlNode node = null;
                if ((node = GetNestedNode(rootNode, BankAccountInfo)) != null)
                {
                    Account = new BankAccount(node);
                }

                if ((node = GetNestedNode(rootNode, CreditCardAccountInfo)) != null)
                {
                    Account = new CreditCardAccount(node);
                }

                // According to the spec, a BPACCTINFO always (and only) contains BANKACCTFROM, not CCACCTFROM
                if ((node = GetNestedNode(rootNode, BillPayAccountInfo)) != null)
                {
                    Account = new BankAccount(node);
                    IsBillPaySourceInternal = true;
                }

                if ((node = GetNestedNode(rootNode, InvestmentAccountInfo)) != null)
                {
                    Account = new InvestmentAccount(node);
                }
            }
        }
        #endregion
    }
}
