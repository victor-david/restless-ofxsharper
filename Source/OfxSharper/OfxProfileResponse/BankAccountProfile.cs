using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Extends <see cref="AccountProfile"/> to provide data that represents a bank account profile.
    /// </summary>
    public class BankAccountProfile : AccountProfile
    {
        #region Public properties
        /// <summary>
        /// Gets the profile information regarding intra bank transfers.
        /// </summary>
        [NodeInfo("XFERPROF")]
        public IntraBankTransferProfile Transfer
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountProfile"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal BankAccountProfile(XmlNode rootNode) : base(rootNode)
        {
            Transfer = new IntraBankTransferProfile(GetNestedNode(rootNode, GetNodeName(nameof(Transfer))));
        }
        #endregion
    }
}
