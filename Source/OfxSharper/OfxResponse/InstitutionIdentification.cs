using Restless.OfxSharper.Core;
using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents the Financial-Institution-identification aggregate.
    /// </summary>
    /// <remarks>
    /// The client will determine out-of-band whether a FI aggregate should be used and if so, the appropriate values for it.
    /// If the FI aggregate is to be used, then the client should send it in every request, and the server should return it in every response.
    /// </remarks>
    public class InstitutionIdentification : OfxObjectBase
    {
        #region Public properties
        /// <summary>
        /// FID. Financial Institution Id (unique within ORG), A-32
        /// </summary>
        [NodeInfo("FID")]
        public string Fid
        {
            get;
            private set;
        }

        /// <summary>
        /// ORG. Organization defining this FI name space, A-32
        /// </summary>
        [NodeInfo("ORG")]
        public string Org
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="InstitutionIdentification"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal InstitutionIdentification(XmlNode rootNode)
        {
            if (rootNode != null)
            {
                Fid = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(Fid))));
                Org = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(Org))));
            }
        }
        #endregion
    }
}
