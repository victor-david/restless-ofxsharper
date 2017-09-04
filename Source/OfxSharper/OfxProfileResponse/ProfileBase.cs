using System;
using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents the base class for profile information for a financial institution.
    /// </summary>
    public abstract class ProfileBase : OfxObjectBase
    {
        #region Public properties
        /// <summary>
        /// Gets the signon realm, or null if the operation isn't supported.
        /// </summary>
        public string SignOnRealm
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileBase"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal ProfileBase(XmlNode rootNode)
        {
            if (rootNode != null)
            {
                XmlNode realmNode = GetNestedNode(rootNode, "SIGNONREALM");
                SignOnRealm = GetNodeValue(realmNode);
            }
        }
        #endregion
    }
}
