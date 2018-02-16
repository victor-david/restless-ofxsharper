using Restless.OfxSharper.Core;
using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents a container that holds information related to investment accounts.
    /// </summary>
    public class InvestmentContainer : OfxObjectBase
    {
        #region Private
        #endregion

        /************************************************************************/

        #region Public properties
        /// <summary>
        /// Gets the list of security positions for this Ofx response.
        /// </summary>
        public SecurityPositionCollection Positions
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the list of security information for this Ofx response.
        /// </summary>
        public SecurityInfoCollection Securities
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="InvestmentContainer"/> class.
        /// </summary>
        /// <param name="xmlDoc">The xml document</param>
        internal InvestmentContainer(XmlDocument xmlDoc)
        {
            Positions = new SecurityPositionCollection(xmlDoc);
            Securities = new SecurityInfoCollection(xmlDoc);
        }
        #endregion
    }
}
