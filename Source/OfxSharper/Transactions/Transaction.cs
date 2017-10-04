using System;
using System.Globalization;
using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents a single transaction.
    /// </summary>
    public class Transaction : OfxObjectBase
    {
        #region Public properties
        /// <summary>
        /// TRNTYPE Transaction type, see section 11.4.2.3.1.1 for possible values
        /// </summary>
        [NodeInfo("TRNTYPE")]
        public OfxTransactionType TransType
        {
            get;
            private set;
        }

        /// <summary>
        /// DTPOSTED. Date transaction was posted to account, datetime.
        /// </summary>
        [NodeInfo("DTPOSTED")]
        public DateTime DatePosted
        {
            get;
            private set;
        }

        /// <summary>
        /// DTUSER Date user initiated transaction, if known, datetime.
        /// </summary>
        [NodeInfo("DTUSER", Required = false)]
        public DateTime? DateInitiated
        {
            get;
            private set;
        }

        /// <summary>
        /// DTAVAIL Date funds are available, datetime.
        /// </summary>
        [NodeInfo("DTAVAIL", Required = false)]
        public DateTime? DateAvailable
        {
            get;
            private set;
        }

        /// <summary>
        /// TRNAMT. Gets the amount of the transaction.
        /// </summary>
        [NodeInfo("TRNAMT")]
        public Decimal Amount
        {
            get;
            private set;
        }

        /// <summary>
        /// FITID. Transaction Id issued by financial institution. Used to detect duplicate downloads, FITID
        /// </summary>
        [NodeInfo("FITID", Required = true)]
        public string TransactionId
        {
            get;
            private set;
        }

        /// <summary>
        /// CORRECTFITID. If present, the FITID of a previously sent transaction that is corrected by this record.
        /// This transaction replaces or deletes the transaction that it corrects, based on the value of CORRECTACTION, FITID.
        /// </summary>
        [NodeInfo("CORRECTFITID", Required = false)]
        public string CorrectedTransactionId
        {
            get;
            private set;
        }

        /// <summary>
        /// CORRECTACTION. Actions can be REPLACE or DELETE. REPLACE replaces the transaction referenced by CORRECTFITID; DELETE deletes it.
        /// Gets the action needed to correct <see cref="CorrectedTransactionId"/>
        /// </summary>
        [NodeInfo("CORRECTACTION")]
        public TransactionCorrectionAction CorrectionAction
        {
            get;
            private set;
        }

        /// <summary>
        /// SRVRTID. Server assigned transaction Id; used for transactions initiated by client, such as payment or funds transfer.
        /// </summary>
        [NodeInfo("SRVRTID")]
        public string ServerTransactionId
        {
            get;
            private set;
        }

        /// <summary>
        /// CHECKNUM Check (or other reference) number, A-12
        /// </summary>
        [NodeInfo("CHECKNUM")]
        public string CheckNumber
        {
            get;
            private set;
        }

        /// <summary>
        /// REFNUM. Reference number that uniquely identifies the transaction.Can be used in addition to or instead of CHECKNUM, A-32
        /// </summary>
        [NodeInfo("REFNUM")]
        public string ReferenceNumber
        {
            get;
            private set;
        }

        /// <summary>
        /// SIC. Standard Industrial Code, N-6
        /// </summary>
        [NodeInfo("SIC")]
        public string Sic
        {
            get;
            private set;
        }

        /// <summary>
        /// PAYEEID. Payee identifier if available, A-12 
        /// </summary>
        [NodeInfo("PAYEEID")]
        public string PayeeId
        {
            get;
            private set;
        }

        /// <summary>
        /// NAME Name of payee or description of transaction, A-32
        /// NOTE: Provide NAME or PAYEE, not both
        /// </summary>
        [NodeInfo("NAME")]
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// MEMO. Extra information (not in NAME), A-255
        /// </summary>
        [NodeInfo("MEMO")]
        public string Memo
        {
            get;
            private set;
        }

        /// <summary>
        /// PAYEE. NOTE: Provide NAME or PAYEE, not both
        /// </summary>
        [NodeInfo("PAYEE")]
        public Payee Payee
        {
            get;
            private set;
        }

        /// <summary>
        /// BANKACCTTO or CCACCTTO. If this was a transfer to an account and the account information is available, see section 11.3.1
        /// </summary>
        public AccountBase ToAccount
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets CURRENCY or ORIGCURRENCY or the default.
        /// </summary>
        [NodeInfo("CURRENCY")]
        public string Currency
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets a boolean value that may be used by downstream processing.
        /// </summary>
        public bool IsFlagged
        {
            get;
            set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        /// <param name="defaultCurrency">The currency</param>
        internal Transaction(XmlNode rootNode, string defaultCurrency)
        {
            TransType = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(TransType)))).ToOfxTransactionType();
            DatePosted = GetDateTimeValue(rootNode, nameof(DatePosted));
            DateInitiated = GetNullableDateTimeValue(rootNode, nameof(DateInitiated));
            DateAvailable = GetNullableDateTimeValue(rootNode, nameof(DateAvailable));
            Amount = GetDecimalValue(GetNestedNode(rootNode, GetNodeName(nameof(Amount))));

            TransactionId = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(TransactionId))));
            ValidateOfxParseOperation(String.IsNullOrEmpty(TransactionId), "Cannot retreive transaction id");

            CorrectedTransactionId = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(CorrectedTransactionId))));
            CorrectionAction = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(CorrectionAction)))).ToTransactionCorrectionAction();
            ServerTransactionId = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(ServerTransactionId))));

            CheckNumber = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(CheckNumber))));
            // the check number may come in left-padded with zeros. Take out left padding.
            while (CheckNumber.StartsWith("0") && CheckNumber.Length > 0)
            {
                CheckNumber = CheckNumber.Remove(0, 1);
            }

            ReferenceNumber = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(ReferenceNumber))));
            Sic = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(Sic))));
            PayeeId = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(PayeeId))));

            Name = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(Name))));
            Memo = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(Memo))));

            // This is not strictly spec. Some ofx responses don't have Name b/c they have a Payee
            if (String.IsNullOrEmpty(Name))
            {
                Name = Memo;
            }

            // Get the payee if it exists.
            XmlNode payeeNode = GetNestedNode(rootNode, GetNodeName(nameof(Payee)));
            if (payeeNode != null)
            {
                Payee = new Payee(payeeNode);
            }

            Currency = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(Currency))));
            if (String.IsNullOrEmpty(Currency))
            {
                Currency = GetNodeValue(GetNestedNode(rootNode, "ORIGCURRENCY"));
                if (String.IsNullOrEmpty(Currency))
                {
                    Currency = defaultCurrency;
                }
            }

            XmlNode bankToNode = GetNestedNode(rootNode, "BANKACCTTO");
            XmlNode ccToNode = GetNestedNode(rootNode, "CCACCTTO");

            if (bankToNode != null)
            {
                ToAccount = new BankAccount(bankToNode);
            }
            else if (ccToNode != null)
            {
                ToAccount = new CreditCardAccount(ccToNode);
            }
        }
        #endregion

        /************************************************************************/

        #region Private methods
        #endregion
    }
}