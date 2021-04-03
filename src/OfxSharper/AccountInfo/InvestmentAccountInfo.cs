using Restless.OfxSharper.Core;
using System.Xml;

namespace Restless.OfxSharper.Account
{
    /// <summary>
    /// Represents information about an investment account, obtained via ACCTINFOTRNRQ
    /// and returned as a INVACCTINFO aggregate.
    /// </summary>
    public class InvestmentAccountInfo : AccountInfoBase
    { 
        #region Public properties
        /// <summary>
        /// Gets the account associated with this account information
        /// </summary>
        [NodeInfo("INVACCTFROM", Required = true)]
        public override AccountBase Account
        {
            get;
        }

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
        /// Initializes a new instance of the <see cref="InvestmentAccountInfo"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal InvestmentAccountInfo(XmlNode rootNode) : base(rootNode)
        {
            // rootNode cannot be null. Base class constructor throws if so.
            Account = new InvestmentAccount(GetNestedNode(rootNode, GetNodeName(nameof(Account))));
            ProductType = GetNodeValue(rootNode, nameof(ProductType)).ToInvestmentProductType();
            InvestmentAccountType = GetNodeValue(rootNode, nameof(InvestmentAccountType)).ToInvestmentAccountType();
            IsChecking = GetBooleanValue(rootNode, nameof(IsChecking));
        }
        #endregion
    }
}
