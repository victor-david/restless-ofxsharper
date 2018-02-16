﻿using Restless.OfxSharper.Core;
using System;
using System.Xml;

namespace Restless.OfxSharper.Profile
{
    /// <summary>
    /// Represents the bill pay portion of a financial institution profile.
    /// </summary>
    public class BillPayProfile : ProfileData
    {
        #region Public properties
        /// <summary>
        /// CANADDPAYEE. User can add payees. if false, the user is restricted to payees added to the user’s payee list by the payment system, Boolean
        /// </summary>
        [NodeInfo("CANADDPAYEE")]
        public bool CanAddPayee
        {
            get;
            private set;
        }

        /// <summary>
        /// DIFFFIRSTPMT. Support for specifying a different amount for the first payment generated by a model, Boolean
        /// </summary>
        [NodeInfo("DIFFFIRSTPMT")]
        public bool CanHaveDifferentAmountFirst
        {
            get;
            private set;
        }

        /// <summary>
        /// DIFFLASTPMT. Support for specifying a different amount for the last payment generated by a model, Boolean
        /// </summary>
        [NodeInfo("DIFFLASTPMT")]
        public bool CanHaveDifferentAmountLast
        {
            get;
            private set;
        }

        /// <summary>
        /// CANMODMDLS. Permits modifications to models, that is REQPMTMODRQ, Boolean
        /// </summary>
        [NodeInfo("CANMODMDLS")]
        public bool CanModifyModel
        {
            get;
            private set;
        }

        /// <summary>
        /// CANMODPMTS. Permits modifications to payments, that is PMTMODRQ, Boolean
        /// </summary>
        [NodeInfo("CANMODPMTS")]
        public bool CanModifyPayment
        {
            get;
            private set;
        }

        /// <summary>
        /// PMTBYADDR. The payment provider supports payments to payees identified by billing address, that is, the PAYEE aggregate, Boolean
        /// </summary>
        [NodeInfo("PMTBYADDR")]
        public bool CanPayByAddress
        {
            get;
            private set;
        }

        /// <summary>
        /// XFERDAYSWITH. Number of days before processing date that funds are withdrawn for payment by transfer, N-3
        /// </summary>
        [NodeInfo("XFERDAYSWITH")]
        public int DaysBeforeProcessingTransfer
        {
            get;
            private set;
        }

        /// <summary>
        /// DFLTDAYSTOPAY. Default number of days to pay by check (except by transfer), N-3
        /// </summary>
        [NodeInfo("DFLTDAYSTOPAY")]
        public int DefaultDaysToPay
        {
            get;
            private set;
        }

        /// <summary>
        /// XFERDFLTDAYSTOPAY. Default number of days to pay by transfer, N-3
        /// </summary>
        [NodeInfo("XFERDFLTDAYSTOPAY")]
        public int DefaultDaysToPayTransfer
        {
            get;
            private set;
        }

        /// <summary>
        /// HASEXTDPMT. Supports the EXTDPMT business payment aggregate, Boolean
        /// </summary>
        [NodeInfo("HASEXTDPMT")]
        public bool HasExtendedPayment
        {
            get;
            private set;
        }

        /// <summary>
        /// MODELWND. Model window; the number of days before a recurring transaction is scheduled to be processed that it is instantiated on the system, N-3
        /// </summary>
        [NodeInfo("MODELWND")]
        public int ModelWindow
        {
            get;
            private set;
        }

        /// <summary>
        /// PMTBYPAYEEID. The payment provider supports payments to payees identified by a user-supplied payee ID, Boolean
        /// </summary>
        [NodeInfo("PMTBYPAYEEID")]
        public bool PaymentByPayeeId
        {
            get;
            private set;
        }

        /// <summary>
        /// PMTBYXFER. The payment provider supports payments to payees identified by destination account, Boolean
        /// </summary>
        [NodeInfo("PMTBYXFER")]
        public bool PaymentByTransfer
        {
            get;
            private set;
        }

        /// <summary>
        /// POSTPROCWND. Number of days after a transaction is processed that it is accessible for status inquiries, N-3
        /// </summary>
        [NodeInfo("POSTPROCWND")]
        public int PostProcessWindow
        {
            get;
            private set;
        }

        /// <summary>
        /// PROCDAYSOFF. Days of week that no processing occurs; 0 or more of (MONDAY, TUESDAY, WEDNESDAY, THURSDAY, FRIDAY, SATURDAY, SUNDAY)
        /// PROCDAYSOFF indicate days to exclude when calculating dates that utilize other bill payment bits, such as DAYSWITH and DFLTDAYSTOPAY values.
        /// </summary>
        [NodeInfo("PROCDAYSOFF")]
        public StringList ProcessingDaysOff
        {
            get;
            private set;
        }

        /// <summary>
        /// PROCENDTM. Time of day that day’s processing ends, time
        /// </summary>
        [NodeInfo("PROCENDTM", Required = true)]
        public DateTimeOffset ProcessingEndsTime
        {
            get;
            private set;
        }

        /// <summary>
        /// STSVIAMODS. If server supports communication of server-initiated payment status changes by means of the PMTMODRS message.
        /// </summary>
        [NodeInfo("STSVIAMODS")]
        public bool StatusChangeSuported
        {
            get;
            private set;
        }

        /// <summary>
        /// DAYSWITH. Offset to withdrawal date, such that(DTDUE - DAYSTOPAY) + (DAYSWITH) determines the date on which the funds are withdrawn from the user’s account.
        /// </summary>
        /// <remarks>
        /// If the value of DAYSWITH is -1, then the withdrawal date is the same as the payment date (DTDUE).
        /// </remarks>
        [NodeInfoAttribute("DAYSWITH")]
        public int WithdrawalDaysOffset
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="BillPayProfile"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal BillPayProfile(XmlNode rootNode) : base(rootNode)
        {
            ProcessingDaysOff = new StringList();
            if (rootNode != null)
            {
                CanAddPayee = GetBooleanValue(GetNestedNode(rootNode, GetNodeName(nameof(CanAddPayee))));
                CanHaveDifferentAmountFirst = GetBooleanValue(GetNestedNode(rootNode, GetNodeName(nameof(CanHaveDifferentAmountFirst))));
                CanHaveDifferentAmountLast = GetBooleanValue(GetNestedNode(rootNode, GetNodeName(nameof(CanHaveDifferentAmountLast))));
                CanModifyModel = GetBooleanValue(GetNestedNode(rootNode, GetNodeName(nameof(CanModifyModel))));
                CanModifyPayment = GetBooleanValue(GetNestedNode(rootNode, GetNodeName(nameof(CanModifyPayment))));
                CanPayByAddress = GetBooleanValue(GetNestedNode(rootNode, GetNodeName(nameof(CanPayByAddress))));
                DaysBeforeProcessingTransfer = GetIntegerValue(GetNestedNode(rootNode, GetNodeName(nameof(DaysBeforeProcessingTransfer))));
                DefaultDaysToPay = GetIntegerValue(GetNestedNode(rootNode, GetNodeName(nameof(DefaultDaysToPay))));
                DefaultDaysToPayTransfer = GetIntegerValue(GetNestedNode(rootNode, GetNodeName(nameof(DefaultDaysToPayTransfer))));
                HasExtendedPayment = GetBooleanValue(GetNestedNode(rootNode, GetNodeName(nameof(HasExtendedPayment))));
                ModelWindow = GetIntegerValue(GetNestedNode(rootNode, GetNodeName(nameof(ModelWindow))));
                PaymentByPayeeId = GetBooleanValue(GetNestedNode(rootNode, GetNodeName(nameof(PaymentByPayeeId))));
                PaymentByTransfer = GetBooleanValue(GetNestedNode(rootNode, GetNodeName(nameof(PaymentByTransfer))));
                PostProcessWindow = GetIntegerValue(GetNestedNode(rootNode, GetNodeName(nameof(PostProcessWindow))));
                PopulateList(ProcessingDaysOff, nameof(ProcessingDaysOff), rootNode);
                ProcessingEndsTime = GetDateTimeOffset(GetNestedNode(rootNode, GetNodeName(nameof(ProcessingEndsTime))));
                string nodeValue = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(ProcessingEndsTime))));
                StatusChangeSuported = GetBooleanValue(GetNestedNode(rootNode, GetNodeName(nameof(StatusChangeSuported))));
                WithdrawalDaysOffset = GetIntegerValue(GetNestedNode(rootNode, GetNodeName(nameof(WithdrawalDaysOffset))));
            }
        }
        #endregion
    }
}
