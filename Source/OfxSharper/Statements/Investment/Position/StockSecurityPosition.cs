using System.Xml;

namespace Restless.OfxSharper.Statement
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
        /// <param name="owner">The statement that owns this position.</param>
        internal StockSecurityPosition(XmlNode rootNode, CommonStatementBase owner) : base(rootNode, owner)
        {
        }
        #endregion
    }
}
