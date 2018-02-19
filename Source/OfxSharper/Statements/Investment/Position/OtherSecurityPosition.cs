using System.Xml;

namespace Restless.OfxSharper.Statement
{
    /// <summary>
    /// Represents security position information of type: Other.
    /// </summary>
    public class OtherSecurityPosition : SecurityPositionBase
    {
        #region Internal fields
        /// <summary>
        /// Gets the node name associated with this security position.
        /// </summary>
        internal const string NodeName = "POSOTHER";
        #endregion

        /************************************************************************/

        #region Public properties
        /// <summary>
        /// Gets the security type.
        /// </summary>
        public override SecurityType SecurityType => SecurityType.Other;
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="OtherSecurityPosition"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        /// <param name="owner">The statement that owns this position.</param>
        internal OtherSecurityPosition(XmlNode rootNode, CommonStatementBase owner) : base(rootNode, owner)
        {
        }
        #endregion
    }
}
