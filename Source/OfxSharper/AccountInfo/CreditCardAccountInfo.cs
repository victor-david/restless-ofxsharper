using Restless.OfxSharper.Core;
using System.Xml;

namespace Restless.OfxSharper.Account
{
    /// <summary>
    /// Represents information about a bank account, obtained via ACCTINFOTRNRQ
    /// and returned as a CCACCTINFO aggregate.
    /// </summary>
    public class CreditCardAccountInfo : BankAccountInfo
    {
        #region Public properties
        /// <summary>
        /// Gets the account associated with this account information
        /// </summary>
        [NodeInfo("CCACCTFROM", Required = true)]
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
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="CreditCardAccountInfo"/> class.
        /// </summary>
        internal CreditCardAccountInfo(XmlNode rootNode) : base(rootNode)
        {
            // rootNode cannot be null. Base class constructor throws if so.
            Account = new CreditCardAccount(GetNestedNode(rootNode, GetNodeName(nameof(Account))));
        }
        #endregion
    }

}
