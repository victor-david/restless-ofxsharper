using Restless.OfxSharper.Core;
using System.Xml;

namespace Restless.OfxSharper.Accounts
{
    /// <summary>
    /// Represents an investment account
    /// </summary>
    public class InvestmentAccount : AccountBase
    {
        #region Public properties
        /// <summary>
        /// Gets the account type.
        /// </summary>
        public override AccountType AccountType => AccountType.Investment;

        /// <summary>
        /// INVACCTTYPE. Gets the type of investment account.
        /// </summary>
        [NodeInfo("INVACCTTYPE")]
        public InvestmentAccountType InvestmentAccountType
        {
            get;
            private set;
        }

        /// <summary>
        /// BROKERID. Gets the broker id.
        /// </summary>
        [NodeInfo("BROKERID")]
        public string BrokerId
        {
            get;
            private set;
        }

        /// <summary>
        /// USPRODUCTTYPE. Gets the product type
        /// </summary>
        [NodeInfo("USPRODUCTTYPE")]
        public InvestmentProductType ProductType
        {
            get;
            private set;
        }

        /// <summary>
        /// CHECKING. Gets a boolean value that indicates if this account supports check writing
        /// </summary>
        [NodeInfo("CHECKING")]
        public bool IsChecking
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="InvestmentAccount"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal InvestmentAccount(XmlNode rootNode) : base(rootNode)
        {
            if (rootNode != null)
            {
                BrokerId = GetNodeValue(rootNode, nameof(BrokerId));
                ProductType = GetNodeValue(rootNode, nameof(ProductType)).ToInvestmentProductType();
                InvestmentAccountType = GetNodeValue(rootNode, nameof(InvestmentAccountType)).ToInvestmentAccountType();
                IsChecking = GetBooleanValue(rootNode, nameof(IsChecking));
            }
        }
        #endregion
    }
}
