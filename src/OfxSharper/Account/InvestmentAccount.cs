using Restless.OfxSharper.Core;
using System.Xml;

namespace Restless.OfxSharper.Account
{
    /// <summary>
    /// Represents an an investment account FROM/TO aggregate. INVACCTFROM or INVACCTTO
    /// </summary>
    public class InvestmentAccount : AccountBase
    {
        #region Public properties
        /// <summary>
        /// Gets the account type.
        /// </summary>
        public override AccountType AccountType => AccountType.Investment;

        /// <summary>
        /// BROKERID. Gets the broker id.
        /// </summary>
        [NodeInfo("BROKERID")]
        public string BrokerId
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
            }
        }
        #endregion
    }
}
