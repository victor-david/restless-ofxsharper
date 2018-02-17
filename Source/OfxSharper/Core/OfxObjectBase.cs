using System;
using System.Globalization;
using System.Xml;

namespace Restless.OfxSharper.Core
{
    /// <summary>
    /// Represents the base class for derived classes that are involved in parsing
    /// or other Ofx operations.This class must be inherited.
    /// </summary>
    public abstract class OfxObjectBase
    {
        #region Constructor (protected)
        /// <summary>
        /// Initializes a new instance of the <see cref="OfxObjectBase"/> class.
        /// </summary>
        protected OfxObjectBase()
        {
        }
        #endregion

        /************************************************************************/

        #region Protected methods
        /// <summary>
        /// Throws an ArgumentNullException if the specified item is null, or
        /// if <paramref name="item"/> is string and is empty.
        /// </summary>
        /// <param name="item">The item</param>
        /// <param name="message">The message</param>
        protected void ValidateNull(object item, string message)
        {
            if (item is string)
            {
                if (String.IsNullOrWhiteSpace((string)item))
                {
                    throw new ArgumentNullException(message);
                }
            }
            if (item == null)
            {
                throw new ArgumentNullException(message);
            }
        }

        /// <summary>
        /// Throws an <see cref="OfxException"/> if the specified condition is true.
        /// </summary>
        /// <param name="condition">The condition</param>
        /// <param name="message">The message to use if an exception is thrown.</param>
        protected void ValidateOfxOperation(bool condition, string message)
        {
            if (condition)
            {
                throw new OfxException(message);
            }
        }

        /// <summary>
        /// Throws an <see cref="OfxParseException"/> if the specified condition is true.
        /// </summary>
        /// <param name="condition">The condition</param>
        /// <param name="message">The message to use if an exception is thrown.</param>
        protected void ValidateOfxParseOperation(bool condition, string message)
        {
            if (condition)
            {
                throw new OfxParseException(message);
            }
        }

        /// <summary>
        /// Gets a boolean value that indicates if the specified node is non null nad has the specified name
        /// </summary>
        /// <param name="node">The node to check</param>
        /// <param name="name">The name to check</param>
        /// <returns>true if <paramref name="node"/> is not null and has <paramref name="name"/>; otherwise, false.</returns>
        protected bool NodeExists(XmlNode node, string name)
        {
            if (node != null && !String.IsNullOrEmpty(name))
            {
                return node.Name == name;
            }
            return false;
        }

        /// <summary>
        /// Gets the specified node.
        /// </summary>
        /// <param name="searchNode">Node to begin search.</param>
        /// <param name="name">Name of the nested node.</param>
        /// <returns>The nested node, or null if not found.</returns>
        protected XmlNode GetNestedNode(XmlNode searchNode, string name)
        {
            if (searchNode != null && !String.IsNullOrEmpty(name))
            {
                if (searchNode.Name == name)
                {
                    return searchNode;
                }
                foreach (XmlNode node in searchNode.ChildNodes)
                {
                    XmlNode retNode = GetNestedNode(node, name);
                    if (retNode != null)
                    {
                        return retNode;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the specified node.
        /// </summary>
        /// <param name="searchNodes">The nodes collection to search.</param>
        /// <param name="name">Name of the nested node.</param>
        /// <returns>The nested node, or null if not found.</returns>
        protected XmlNode GetNestedNode(XmlNodeList searchNodes, string name)
        {
            if (searchNodes != null)
            {
                foreach (XmlNode node in searchNodes)
                {
                    XmlNode retNode = GetNestedNode(node, name);
                    if (retNode != null)
                    {
                        return retNode;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the value of the first child of the specified node.
        /// </summary>
        /// <param name="node">The node</param>
        /// <returns>The node value, trimmed.</returns>
        protected string GetNodeValue(XmlNode node)
        {
            if (node != null && node.FirstChild != null && !String.IsNullOrEmpty(node.FirstChild.Value))
            {
                return node.FirstChild.Value.Trim();
            }
            return String.Empty;
        }

        /// <summary>
        /// Gets a string value using the specified root node and the specified property name.
        /// The property must be decorated with a <see cref="NodeInfoAttribute"/>.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for the property.</param>
        /// <param name="propertyName">The name of the property</param>
        /// <returns>A string</returns>
        protected string GetNodeValue(XmlNode rootNode, string propertyName)
        {
            return GetNodeValue(GetNestedNode(rootNode, GetNodeName(propertyName)));
        }

        /// <summary>
        /// Gets a boolean value from the specified node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>The boolean value, true if the node is Y; otherwise, false.</returns>
        protected bool GetBooleanValue(XmlNode node)
        {
            return GetNodeValue(node).ToUpperInvariant() == "Y";
        }

        /// <summary>
        /// Gets a boolean value using the specified root node and the specified property name.
        /// The property must be decorated with a <see cref="NodeInfoAttribute"/>.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for the property.</param>
        /// <param name="propertyName">The name of the property</param>
        /// <returns>A boolean</returns>
        protected bool GetBooleanValue(XmlNode rootNode, string propertyName)
        {
            return GetBooleanValue(GetNestedNode(rootNode, GetNodeName(propertyName)));
        }

        /// <summary>
        /// Gets an integer value from the specified node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>The integer value, or zero if the value can't be parsed.</returns>
        protected int GetIntegerValue(XmlNode node)
        {
            if (int.TryParse(GetNodeValue(node), out int result))
            {
                return result;
            }
            return 0;
        }

        /// <summary>
        /// Gets an integern value using the specified root node and the specified property name.
        /// The property must be decorated with a <see cref="NodeInfoAttribute"/>.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for the property.</param>
        /// <param name="propertyName">The name of the property</param>
        /// <returns>An integer</returns>
        protected int GetIntegerValue(XmlNode rootNode, string propertyName)
        {
            return GetIntegerValue(GetNestedNode(rootNode, GetNodeName(propertyName)));
        }

        /// <summary>
        /// Gets a DateTime value from the specified node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>A DateTime.</returns>
        protected DateTime GetDateTimeValue(XmlNode node)
        {
            return GetNodeValue(node).ToDateObject();
        }

        /// <summary>
        /// Gets a DateTime value using the specified root node and the specified property name.
        /// The property must be decorated with a <see cref="NodeInfoAttribute"/>.
        /// This method woll locate the nested node.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for the property.</param>
        /// <param name="propertyName">The name of the property</param>
        /// <returns>A DateTime</returns>
        protected DateTime GetDateTimeValue(XmlNode rootNode, string propertyName)
        {
            NodeInfoAttribute attrib = GetNodeInfoAttribute(propertyName);
            if (attrib.Required)
            {
                return GetDateTimeValue(GetNestedNode(rootNode, attrib.NodeName));
            }
            throw new OfxParseException("Do not use this method when property marked as not required");
        }

        /// <summary>
        /// Gets a nullable DateTime from the specified node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>The DateTime, or null if it doesn't exist.</returns>
        protected DateTime? GetNullableDateTimeValue(XmlNode node)
        {
            string val = GetNodeValue(node);
            if (!String.IsNullOrEmpty(val))
            {
                return val.ToDateObject();
            }
            return null;
        }

        /// <summary>
        /// Gets an optional DateTime value using the specified root node and the specified property name.
        /// The property must be decorated with a <see cref="NodeInfoAttribute"/>. 
        /// This method woll locate the nested node.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for the property.</param>
        /// <param name="propertyName">The name of the property</param>
        /// <returns>A DateTime, or null</returns>
        protected DateTime? GetNullableDateTimeValue(XmlNode rootNode, string propertyName)
        {
            NodeInfoAttribute attrib = GetNodeInfoAttribute(propertyName);
            if (!attrib.Required)
            {
                return GetNullableDateTimeValue(GetNestedNode(rootNode, attrib.NodeName));
            }
            // this can happen if the property isn't decorated with Required = false.
            throw new OfxParseException("Do not use this method when property marked as required");
        }


        /// <summary>
        /// Gets s DateTimeOffset from the specified node.
        /// </summary>
        /// <param name="node">The node</param>
        /// <returns>A DateTimeOffset</returns>
        /// <remarks>
        /// Time values arrive in the form of 235959[-5:EST]. 
        /// This method extracts the time portion and the offset portion and
        /// assigns them to the return result. The date portion of the return result
        /// has no significance.
        /// </remarks>
        protected DateTimeOffset GetDateTimeOffset(XmlNode node)
        {
            DateTimeOffset result = new DateTimeOffset();
            string val = GetNodeValue(node);
            if (val.Length >= 6)
            {
                // 235959[-5:EST]
                // 165959[-5:EST]
                if (Int32.TryParse(val.Substring(0, 2), out int h) &&
                    Int32.TryParse(val.Substring(2, 2), out int m) &&
                    Int32.TryParse(val.Substring(4, 2), out int s))
                {
                    result = result.AddHours(h).AddMinutes(m).AddSeconds(s);
                }
                int i1 = val.IndexOf("[");
                int i2 = val.IndexOf(":");
                if (i1 != -1 && i2 != -1 && i2 > i1)
                {
                    if (Int32.TryParse(val.Substring(i1+1, i2-i1-1), out int offset))
                    {
                        result = new DateTimeOffset(result.DateTime, new TimeSpan(offset, 0, 0));
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Gets a Decimal value from the specified node.
        /// </summary>
        /// <param name="node">The node</param>
        /// <returns>A decimal value</returns>
        protected Decimal GetDecimalValue(XmlNode node)
        {
            string val = GetNodeValue(node);
            if (!String.IsNullOrEmpty(val))
            {
                try
                {
                    return Convert.ToDecimal(val, CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    throw new OfxParseException("Decimal value not in correct format");
                }
            }
            return 0;
        }

        /// <summary>
        /// Gets a Decimal value using the specified root node and the specified property name.
        /// The property must be decorated with a <see cref="NodeInfoAttribute"/>.
        /// This method will locate the nested node.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for the property.</param>
        /// <param name="propertyName">The name of the property</param>
        /// <returns>A Decimal value.</returns>
        protected Decimal GetDecimalValue(XmlNode rootNode, string propertyName)
        {
            NodeInfoAttribute attrib = GetNodeInfoAttribute(propertyName);
            return GetDecimalValue(GetNestedNode(rootNode, attrib.NodeName));
        }

        /// <summary>
        /// Gets the node name as defined on the specified property by <see cref="NodeInfoAttribute"/>.
        /// </summary>
        /// <param name="propertyName">The property name</param>
        /// <returns>The node name associated with the property.</returns>
        protected string GetNodeName(string propertyName)
        {
            return GetNodeInfoAttribute(propertyName).NodeName;
        }


        /// <summary>
        /// Populates the specified string list
        /// </summary>
        /// <param name="list">The list</param>
        /// <param name="propertyName">The property name. Used to find the node name that's specified in the property attribute.</param>
        /// <param name="rootNode">The root node to start with.</param>
        protected void PopulateList(StringList list, string propertyName, XmlNode rootNode)
        {
            string nodeName = GetNodeName(propertyName);
            XmlNode node = GetNestedNode(rootNode, nodeName);
            while (node != null)
            {
                list.Add(GetNodeValue(node));
                node = GetNestedNode(node.ChildNodes, nodeName);
            }
        }

        /// <summary>
        /// Provided a boolean value, returns "Y" or "N".
        /// </summary>
        /// <param name="value">The boolean value.</param>
        /// <returns>the string "Y" or "N".</returns>
        protected string BooleanToString(bool value)
        {
            return (value) ? "Y" : "N";
        }
        #endregion

        /************************************************************************/

        #region Private methods
        private NodeInfoAttribute GetNodeInfoAttribute(string propertyName)
        {
            var propInfo = GetType().GetProperty(propertyName);
            if (propInfo != null)
            {
                if (Attribute.IsDefined(propInfo, typeof(NodeInfoAttribute)))
                {
                    var attrib = Attribute.GetCustomAttribute(propInfo, typeof(NodeInfoAttribute)) as NodeInfoAttribute;
                    return attrib;
                }
            }
            throw new Exception("Attribute not defined.");
        }
        #endregion

    }
}
