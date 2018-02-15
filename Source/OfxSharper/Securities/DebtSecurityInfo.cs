using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents security information of type: Debt.
    /// </summary>
    public class DebtSecurityInfo : SecurityInfoBase
    {
        #region Internal fields
        /// <summary>
        /// Gets the node name associated with this security info.
        /// </summary>
        internal const string NodeName = "DEBTINFO";
        #endregion

        /************************************************************************/

        #region Public properties
        /// <summary>
        /// Gets the security type.
        /// </summary>
        public override SecurityType SecurityType => SecurityType.Debt;
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="DebtSecurityInfo"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal DebtSecurityInfo(XmlNode rootNode) : base(rootNode)
        {
        }
        #endregion
    }
}
