using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents intra bank transfer information for a financial institution.
    /// </summary>
    public class TransferProfile : OfxObjectBase
    {
        #region Public properties
        /// <summary>
        /// Gets a boolean value that indicates if the financial institution accepts intra bank transfers.
        /// </summary>
        public bool IsSupported
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a boolean value that indicates if the financial institution supports scheduled transfers.
        /// </summary>
        [NodeInfo("CANSCHED")]
        public bool CanSchedule
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a boolean value that indicates if the financial institution supports recurring scheduled transfers.
        /// </summary>
        [NodeInfo("CANRECUR")]
        public bool CanRecur
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a boolean value that indicates if the financial institution supports modification of transfers.
        /// </summary>
        [NodeInfo("CANMODXFERS")]
        public bool CanModifyTransfer
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a boolean value that indicates if the financial institution supports modification of models.
        /// </summary>
        [NodeInfo("CANMODMDLS")]
        public bool CanModifyModel
        {
            get;
            private set;
        }


        /// <summary>
        /// Gets the number of days before processing date that funds are withdrawn, N-3
        /// </summary>
        [NodeInfo("DAYSWITH")]
        public int DaysToWithdraw
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the default number of days to pay, N-3
        /// </summary>
        [NodeInfo("DFLTDAYSTOPAY")]
        public int DefaultDaysToPay
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the number of days before a recurring transaction is scheduled to be processed that it is instantiated on the system
        /// </summary>
        [NodeInfo("MODELWND")]
        public int ModelWindow
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a list of days on which processing doe not occur.
        /// </summary>
        [NodeInfo("PROCDAYSOFF")]
        public List<string> ProcessingDaysOff
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="TransferProfile"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal TransferProfile(XmlNode rootNode)
        {
            ProcessingDaysOff = new List<string>();
            if (rootNode != null)
            {
                IsSupported = true;
                CanSchedule = GetBooleanValue(GetNestedNode(rootNode,GetNodeName(nameof(CanSchedule))));
                CanRecur = GetBooleanValue(GetNestedNode(rootNode, GetNodeName(nameof(CanRecur))));
                CanModifyTransfer = GetBooleanValue(GetNestedNode(rootNode, GetNodeName(nameof(CanModifyTransfer))));
                CanModifyModel = GetBooleanValue(GetNestedNode(rootNode, GetNodeName(nameof(CanModifyModel))));
                DaysToWithdraw = GetIntegerValue(GetNestedNode(rootNode, GetNodeName(nameof(DaysToWithdraw))));
                DefaultDaysToPay = GetIntegerValue(GetNestedNode(rootNode, GetNodeName(nameof(DefaultDaysToPay))));
                ModelWindow = GetIntegerValue(GetNestedNode(rootNode, GetNodeName(nameof(ModelWindow))));
                PopulateList(ProcessingDaysOff, nameof(ProcessingDaysOff), rootNode);
            }
        }
        #endregion
    }
}
