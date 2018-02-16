using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents security position information of type: Option.
    /// </summary>
    public class OptionSecurityPosition : SecurityPositionBase
    {
        #region Internal fields
        /// <summary>
        /// Gets the node name associated with this security position.
        /// </summary>
        internal const string NodeName = "POSOPT";
        #endregion

        /************************************************************************/

        #region Public properties
        /// <summary>
        /// Gets the security type.
        /// </summary>
        public override SecurityType SecurityType => SecurityType.Option;
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="OptionSecurityPosition"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal OptionSecurityPosition(XmlNode rootNode) : base(rootNode)
        {
        }
        #endregion
    }
}
