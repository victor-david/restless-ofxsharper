using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restless.OfxSharper.Core
{
    /// <summary>
    /// Provides a custom attribute that can be applied to a property
    /// to specify the Xml node that is associated with the property
    /// and whether the property is required or not.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class NodeInfoAttribute : Attribute
    {
        /// <summary>
        /// Gets the name of the Xml node that is associated with the property.
        /// </summary>
        public string NodeName
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets a boolean value that indicates if this is a required value.
        /// The default is true.
        /// </summary>
        public bool Required
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeInfoAttribute"/> class.
        /// </summary>
        /// <param name="nodeName">The node name</param>
        public NodeInfoAttribute(string nodeName)
        {
            NodeName = nodeName;
            Required = true;
        }
    }
}
