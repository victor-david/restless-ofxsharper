using System;
using System.Xml;

namespace Restless.OfxSharper.Profile
{
    /// <summary>
    /// Represents basic profile information for a financial institution.
    /// </summary>
    public class ProfileData : ProfileBase
    {
        #region Public properties
        /// <summary>
        /// Gets a boolean value that indicates if the operation is supported.
        /// </summary>
        public bool IsSupported
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the url for this operation, or null if the operation isn't suported.
        /// </summary>
        public string Url
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileData"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal ProfileData(XmlNode rootNode) : base(rootNode)
        {
            IsSupported = false;
            if (rootNode != null)
            {
                XmlNode urlNode = GetNestedNode(rootNode, "URL");
                Url = GetNodeValue(urlNode);
                IsSupported = !String.IsNullOrEmpty(Url) || !String.IsNullOrEmpty(SignOnRealm);
            }
        }
        #endregion
    }
}
