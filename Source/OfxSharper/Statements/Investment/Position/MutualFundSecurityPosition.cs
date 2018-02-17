using System.Xml;

namespace Restless.OfxSharper.Statement
{
    /// <summary>
    /// Represents security position information of type: Mutual Fund.
    /// </summary>
    public class MutualFundSecurityPosition : SecurityPositionBase
    {
        #region Internal fields
        /// <summary>
        /// Gets the node name associated with this security position.
        /// </summary>
        internal const string NodeName = "POSMF";
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
        /// Initializes a new instance of the <see cref="MutualFundSecurityPosition"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal MutualFundSecurityPosition(XmlNode rootNode) : base(rootNode)
        {
        }
        #endregion
    }
}
