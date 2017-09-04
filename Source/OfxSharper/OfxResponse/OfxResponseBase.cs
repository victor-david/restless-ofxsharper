using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents the base class for Ofx response documents. This class must be inherited.
    /// </summary>
    public abstract class OfxResponseBase : OfxObjectBase
    {
        #region Public properties
        /// <summary>
        /// Gets the Ofx header.
        /// </summary>
        public OfxHeader Header
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the sign on response.
        /// </summary>
        [NodeInfo("SIGNONMSGSRSV1")]
        public SignOnResponse SignOnResponse
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="OfxResponseBase"/> class.
        /// </summary>
        /// <param name="header">The Ofx header object.</param>
        /// <param name="xmlDoc">The Xml document</param>
        protected OfxResponseBase(OfxHeader header, XmlDocument xmlDoc)
        {
            ValidateNull(header, "OfxDocumentBase.Header");
            ValidateNull(xmlDoc, "OfxDocumentBase.XmlDoc");
            Header = header;
            SignOnResponse = new SignOnResponse(GetNestedNode(xmlDoc.FirstChild, GetNodeName(nameof(SignOnResponse))));
        }
        #endregion
    }
}
