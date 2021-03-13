using Restless.OfxSharper.Core;
using System.Xml;

namespace Restless.OfxSharper.Statement
{
    /// <summary>
    /// Represents a single security id, the SECID aggregate
    /// </summary>
    public class SecurityId : OfxObjectBase
    {
        #region Internal fields
        /// <summary>
        /// Identifies the node that holds the security id aggregate.
        /// </summary>
        internal const string NodeName = "SECID";
        #endregion

        /************************************************************************/

        #region Public properties
        /// <summary>
        /// Gets the unique security id.
        /// </summary>
        [NodeInfo("UNIQUEID", Required = true)]
        public string UniqueId
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the type of the unique security id.
        /// </summary>
        [NodeInfo("UNIQUEIDTYPE", Required = true)]
        public string UniqueIdType
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityId"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal SecurityId(XmlNode rootNode)
        {
            if (rootNode != null)
            {
                UniqueId = GetNodeValue(rootNode, nameof(UniqueId));
                UniqueIdType = GetNodeValue(rootNode, nameof(UniqueIdType));
            }
        }
        #endregion
    }
}
