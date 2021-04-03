using System.Xml;

namespace Restless.OfxSharper.Statement
{
    /// <summary>
    /// Represents security information of type: Mutual Fund.
    /// </summary>
    public class MutualFundSecurityInfo : SecurityInfoBase
    {
        #region Internal fields
        /// <summary>
        /// Gets the node name associated with this security info.
        /// </summary>
        internal const string NodeName = "MFINFO";
        #endregion

        /************************************************************************/

        #region Public properties
        /// <summary>
        /// Gets the security type.
        /// </summary>
        public override SecurityType SecurityType => SecurityType.MutualFund;
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="MutualFundSecurityInfo"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal MutualFundSecurityInfo(XmlNode rootNode) : base(rootNode)
        {
        }
        #endregion
    }
}
