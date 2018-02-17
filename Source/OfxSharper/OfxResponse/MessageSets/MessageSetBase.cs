using Restless.OfxSharper.Core;
using System.Xml;

namespace Restless.OfxSharper
{
    ///// <summary>
    ///// Represents the base class for a top level message set response. This class must be inherited.
    ///// </summary>
    //public abstract class MessageSetBase : OfxMessageSetBase1
    //{
    //    #region Private
    //    private XmlDocument xmlDoc;
    //    #endregion

    //    /************************************************************************/

    //    #region Constructor (internal)
    //    /// <summary>
    //    /// Initializes a new instance of the <see cref="MessageSetBase"/> class.
    //    /// </summary>
    //    /// <param name="xmlDoc">The xml document</param>
    //    /// <param name="messageSetVersion">The message set version to use.</param>
    //    internal MessageSetBase(XmlDocument xmlDoc, int messageSetVersion) : base(messageSetVersion)
    //    {
    //        this.xmlDoc = xmlDoc;
    //    }
    //    #endregion

    //    /************************************************************************/

    //    #region Protected methods
    //    /// <summary>
    //    /// Gets the node that corresponds to <see cref="MessageSetName"/>.
    //    /// </summary>
    //    /// <returns></returns>
    //    protected XmlNode GetMessageSetNode()
    //    {
    //        return (xmlDoc != null) ? GetNestedNode(xmlDoc.FirstChild, MessageSetName1) : null;
    //    }

    //    /// <summary>
    //    /// Gets the node that corresponds to <paramref name="nodeName"/>.
    //    /// </summary>
    //    /// <returns></returns>
    //    protected XmlNode GetMessageSetNode(string nodeName)
    //    {
    //        return (xmlDoc != null) ? GetNestedNode(xmlDoc.FirstChild, nodeName) : null;
    //    }
    //    #endregion
    //}

}
