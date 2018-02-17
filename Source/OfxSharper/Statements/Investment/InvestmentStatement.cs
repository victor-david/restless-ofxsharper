using Restless.OfxSharper.Core;
using System;
using System.Xml;

namespace Restless.OfxSharper.Statement
{
    /// <summary>
    /// Represents a statement for a single investment account
    /// </summary>
    public class InvestmentStatement : CommonStatementBase
    {
        #region Internal fields
        internal const string TransactionNodeName = "INVSTMTTRNRS";
        #endregion

        /************************************************************************/

        #region Public properties
        /// <summary>
        /// Gets the statement type. Always returns <see cref="StatementType.Investment"/>.
        /// </summary>
        public override StatementType StatementType => StatementType.Investment;

        /// <summary>
        /// DTASOF. As of date & time for the statement download.
        /// </summary>
        [NodeInfo("DTASOF", Required = true)]
        public DateTime DateAsOf
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the list of security positions for this statement.
        /// </summary>
        [NodeInfo("INVPOSLIST", Required = false)]
        public SecurityPositionCollection Positions
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the total market value of <see cref="Positions"/>.
        /// </summary>
        public Decimal TotalMarketValue
        {
            get => GetTotalMarketValue();
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="InvestmentStatement"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal InvestmentStatement(XmlNode rootNode) : base(rootNode)
        {
            Positions = new SecurityPositionCollection(GetNestedNode(rootNode, GetNodeName(nameof(Positions))));
            if (rootNode != null)
            {
                DateAsOf = GetDateTimeValue(rootNode, nameof(DateAsOf));
            }
        }
        #endregion

        /************************************************************************/

        #region Private methods
        private Decimal GetTotalMarketValue()
        {
            Decimal total = 0;
            foreach (var pos in Positions)
            {
                total += pos.MarketValue;
            }
            return total;
        }
        #endregion
    }
}
