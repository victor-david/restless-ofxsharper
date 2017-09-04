using System;
using System.Collections.Generic;
using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents an Ofx response
    /// </summary>
    public class OfxResponse : OfxResponseBase
    {
        #region Public properties
        /// <summary>
        /// Gets the statements for this Ofx response
        /// </summary>
        public StatementCollection Statements
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="OfxResponse"/> class.
        /// </summary>
        /// <param name="header">The header object</param>
        /// <param name="xmlDoc">The Xml document</param>
        internal OfxResponse(OfxHeader header, XmlDocument xmlDoc) : base (header, xmlDoc)
        {
            Statements = new StatementCollection(xmlDoc);
        }
        #endregion

        /************************************************************************/

        #region Private methods
        #endregion
    }
}