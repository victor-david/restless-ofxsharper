using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents security position information of type: Stock.
    /// </summary>
    public class StockSecurityPosition : SecurityPositionBase
    {
        #region Internal fields
        /// <summary>
        /// Gets the node name associated with this security position.
        /// </summary>
        internal const string NodeName = "POSSTOCK";
        #endregion

        /************************************************************************/

        #region Public properties
        /// <summary>
        /// Gets the security type.
        /// </summary>
        public override SecurityType SecurityType => SecurityType.Stock;
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="StockSecurityPosition"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal StockSecurityPosition(XmlNode rootNode) : base(rootNode)
        {
        }
        #endregion
    }
}
