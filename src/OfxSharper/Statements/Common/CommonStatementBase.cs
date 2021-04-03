﻿using Restless.OfxSharper.Core;
using System.Xml;
using System;

namespace Restless.OfxSharper.Statement
{
    /// <summary>
    /// Represents the base class for a statement or a closing statement. This class must be inherited.
    /// </summary>
    public abstract class CommonStatementBase : TransactionMessageBase
    {
        #region Public properties
        /// <summary>
        /// When implemented by a derived class, gets the statement type
        /// </summary>
        public abstract StatementType StatementType
        {
            get;
        }

        /// <summary>
        /// CURRDEF. Default currency for the statement, currsymbol
        /// </summary>
        [NodeInfo("CURDEF", Required = true)]
        public string DefaultCurrency
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (protected)
        /// <summary>
        /// Initializes a new instance of the <see cref="CommonStatementBase"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        protected CommonStatementBase(XmlNode rootNode) : base(rootNode)
        {
            if (rootNode != null)
            {
                DefaultCurrency = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(DefaultCurrency))));
            }
        }
        #endregion

    }
}
