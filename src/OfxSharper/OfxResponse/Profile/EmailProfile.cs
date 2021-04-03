using Restless.OfxSharper.Core;
using System.Xml;

namespace Restless.OfxSharper.Profile
{
    /// <summary>
    /// Represents the email portion of a financial institution profile.
    /// </summary>
    public class EmailProfile : ProfileData
    {
        #region Public properties
        /// <summary>
        /// GETMIMESUP. True if server supports get MIME message, Boolean
        /// </summary>
        [NodeInfo("GETMIMESUP")]
        public bool IsMimeSupported
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailProfile"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal EmailProfile(XmlNode rootNode) : base(rootNode)
        {
            if (rootNode != null)
            {
                // IsSupported was already set by the base class based
                // on the presence of the node and the url. We'll confirm
                // the support by setting based on the MAILSUP node. 
                // We don't carry an attribute on IsSupported.
                IsSupported = GetBooleanValue(GetNestedNode(rootNode, "MAILSUP"));
                IsMimeSupported = GetBooleanValue(GetNestedNode(rootNode, GetNodeName(nameof(IsMimeSupported))));
            }
        }
        #endregion
    }
}
