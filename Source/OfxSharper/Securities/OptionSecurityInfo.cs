using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents security information of type: Option.
    /// </summary>
    public class OptionSecurityInfo : SecurityInfoBase
    {
        #region Internal fields
        /// <summary>
        /// Gets the node name associated with this security info.
        /// </summary>
        internal const string NodeName = "OPTINFO";
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
        /// Initializes a new instance of the <see cref="OptionSecurityInfo"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal OptionSecurityInfo(XmlNode rootNode) : base(rootNode)
        {
        }
        #endregion
    }
}
