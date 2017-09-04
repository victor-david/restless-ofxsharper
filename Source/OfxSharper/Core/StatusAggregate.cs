using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents the status aggregate.
    /// </summary>
    /// <remarks>
    /// <para>
    /// To provide as much feedback as possible to clients and their users, OFX defines a STATUS aggregate. 
    /// The most important element is the code that identifies the error. Each response defines the codes it uses. 
    /// Codes 0 through 2999 have common meanings in all OFX transactions. Codes from 3000 and up have meanings specific to each transaction.
    /// </para>
    /// <para>
    /// The last 10 error codes in each assigned range of 1000 is reserved for server-specific status codes.
    /// For example, of the general status codes, 2990¬-2999 are reserved for status codes defined by the server.Of the banking status codes, 
    /// codes 10990-10999 are reserved for the server. If a client receives a server-specific status code that it does not know, 
    /// it will handle it as a general error 2000.
    /// </para>
    /// </remarks>
    public class StatusAggregate : OfxObjectBase
    {
        #region Public properties
        /// <summary>
        /// Gets the status code
        /// </summary>
        [NodeInfo("CODE")]
        public int Code
        {
            get;
            private set;
        }

        /// <summary>
        /// MESSAGE. A textual explanation from the FI. Note that clients will generally have messages 
        /// of their own for each error ID. Use this tag only to provide more details or for the general errors. A-255
        /// </summary>
        [NodeInfo("MESSAGE")]
        public string Message
        {
            get;
            private set;
        }

        /// <summary>
        /// SEVERITY. 
        /// INFO = Informational only.
        /// WARN = Some problem with the request occurred but a valid response still present.
        /// ERROR = A problem severe enough that response could not be made.
        /// </summary>
        [NodeInfo("SEVERITY")]
        public string Severity
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="StatusAggregate"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal StatusAggregate(XmlNode rootNode)
        {
            if (rootNode != null)
            {
                Code = GetIntegerValue(GetNestedNode(rootNode, GetNodeName(nameof(Code))));
                Message = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(Message))));
                Severity = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(Severity))));
            }
        }
        #endregion
    }
}
