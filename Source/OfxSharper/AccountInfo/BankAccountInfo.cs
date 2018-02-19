using Restless.OfxSharper.Core;
using System.Xml;

namespace Restless.OfxSharper.Account
{
    /// <summary>
    /// Represents information about a bank account, obtained via ACCTINFOTRNRQ
    /// and returned as a BANKACCTINFO aggregate.
    /// </summary>
    public class BankAccountInfo : AccountInfoBase
    {
        #region Public properties
        /// <summary>
        /// Gets the account associated with this account information
        /// </summary>
        [NodeInfo("BANKACCTFROM")]
        public override AccountBase Account
        {
            get;
        }

        ///// <summary>
        ///// Gets the <see cref="Account"/> property strongly typed.
        ///// </summary>
        //public BankAccount StrongAccount
        //{
        //    get
        //    {
        //        ValidateNull(Account as BankAccount, nameof(StrongAccount));
        //        return Account as BankAccount;
        //    }
        //}

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
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountInfo"/> class.
        /// </summary>
        internal BankAccountInfo(XmlNode rootNode) : base(rootNode)
        {
            // rootNode cannot be null. Base class constructor throws if so.
            Account = new BankAccount(GetNestedNode(rootNode, GetNodeName(nameof(Account))));
            AreDetailsSupported = GetBooleanValue(rootNode, nameof(AreDetailsSupported));
            IsTransferSource = GetBooleanValue(rootNode, nameof(IsTransferSource));
            IsTransferDest = GetBooleanValue(rootNode, nameof(IsTransferDest));
        }
        #endregion
    }
}
