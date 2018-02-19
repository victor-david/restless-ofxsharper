using Restless.OfxSharper.Core;
using System.Xml;

namespace Restless.OfxSharper.Account
{
    /// <summary>
    /// Represents a credit card account.
    /// </summary>
    public class CreditCardAccount : BankAccountBase
    {
        #region Public properties
        /// <summary>
        /// Gets the account type
        /// </summary>
        public override AccountType AccountType => AccountType.CreditCard;
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="CreditCardAccount"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal CreditCardAccount(XmlNode rootNode) : base(rootNode)
        {
            // CreditCardAccount does not need to add any additional properties from the base class.
        }
        #endregion
    }
}
