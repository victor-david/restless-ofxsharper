using Restless.OfxSharper.Core;
using System.Xml;

namespace Restless.OfxSharper.Profile
{
    /// <summary>
    /// Represents the investment portion of a financial institution profile.
    /// </summary>
    public class InvestmentProfile : ProfileData
    {
        #region Public properties
        /// <summary>
        /// BALDNLD. Indicates if download of investment balances is supported.
        /// </summary>
        [NodeInfo("BALDNLD")]
        public bool IsBalanceDownloadSupported
        {
            get;
            private set;
        }

        /// <summary>
        /// CANEMAIL. Whether the FI supports investment e-mail.
        /// </summary>
        [NodeInfo("CANEMAIL")]
        public bool IsEmailSupported
        {
            get;
            private set;
        }

        /// <summary>
        /// OODNLD. Indicates if download of investment open orders is supported.
        /// </summary>
        [NodeInfo("OODNLD")]
        public bool IsOpenOrderDownloadSupported
        {
            get;
            private set;
        }

        /// <summary>
        /// POSDNLD. Indicates if download of investment positions is supported.
        /// </summary>
        [NodeInfo("POSDNLD")]
        public bool IsPositionDownloadSupported
        {
            get;
            private set;
        }

        /// <summary>
        /// TRANDNLD. Indicates of download of investment transactions is supported.
        /// </summary>
        [NodeInfo("TRANDNLD")]
        public bool IsTransDownloadSupported
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="InvestmentProfile"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal InvestmentProfile(XmlNode rootNode) : base(rootNode)
        {
            if (rootNode != null)
            {
                IsBalanceDownloadSupported = GetBooleanValue(GetNestedNode(rootNode, GetNodeName(nameof(IsBalanceDownloadSupported))));
                IsEmailSupported = GetBooleanValue(GetNestedNode(rootNode, GetNodeName(nameof(IsEmailSupported))));
                IsOpenOrderDownloadSupported = GetBooleanValue(GetNestedNode(rootNode, GetNodeName(nameof(IsOpenOrderDownloadSupported))));
                IsPositionDownloadSupported = GetBooleanValue(GetNestedNode(rootNode, GetNodeName(nameof(IsPositionDownloadSupported))));
                IsTransDownloadSupported = GetBooleanValue(GetNestedNode(rootNode, GetNodeName(nameof(IsTransDownloadSupported))));
            }
        }
        #endregion
    }
}
