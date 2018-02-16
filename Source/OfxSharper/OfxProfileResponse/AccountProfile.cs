using Restless.OfxSharper.Core;
using System.Xml;

namespace Restless.OfxSharper.Profile
{
    /// <summary>
    /// Extends <see cref="ProfileData"/> to provide data that represents an account profile.
    /// </summary>
    public class AccountProfile : ProfileData
    {
        #region Public properties
        /// <summary>
        /// CLOSINGAVAIL. Gets a boolean value that indicates if closing statement information is available.
        /// </summary>
        [NodeInfo("CLOSINGAVAIL", Required = true)]
        public bool IsClosingAvailable
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountProfile"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal AccountProfile(XmlNode rootNode) : base(rootNode)
        {
            if (rootNode != null)
            {
                IsClosingAvailable = GetBooleanValue(GetNestedNode(rootNode, GetNodeName(nameof(IsClosingAvailable))));
            }
        }
        #endregion
    }
}
