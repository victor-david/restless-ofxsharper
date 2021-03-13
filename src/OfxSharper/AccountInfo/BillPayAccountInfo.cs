using Restless.OfxSharper.Core;
using System.Xml;

namespace Restless.OfxSharper.Account
{
    /// <summary>
    /// Represents information about a bill pay account, obtained via ACCTINFOTRNRQ
    /// and returned as a BPACCTINFO aggregate.
    /// </summary>
    /// <remarks>
    /// <para>
    /// When the OFX server returns account information, it does so in various aggregates:
    /// BANKACCTINFO, CCACCTINFO, INVACCTINFO, and BPACCTINFO.
    /// </para>
    /// <para>
    /// This class represents the data returned in the BPACCTINFO aggregate. It's important to
    /// remember that this aggegate may only contain a BANKACCTFROM aggregate which describes
    /// another account returned via BANKACCTINFO. The presence of this node indicates
    /// that the corresponding bank account may be used as a source for bill pay operations.
    /// </para>
    /// <para>
    /// Objects of this class are created when populating the <see cref="AccountInfoCollection"/> but are not returned
    /// in the collection to the caller. Instead, <see cref="BillPayAccountInfo"/> is used to find the corresponding 
    /// bank account and set the <see cref="BankAccountInfo.IsBillPaySource"/> property.
    /// </para>
    /// </remarks>
    public class BillPayAccountInfo : AccountInfoPrimitive
    {
        #region Public properties
        /// <summary>
        /// Gets the account associated with this account information
        /// </summary>
        [NodeInfo("BANKACCTFROM")]
        public override AccountBase Account
        {
            get;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountInfo"/> class.
        /// </summary>
        internal BillPayAccountInfo(XmlNode rootNode) : base(rootNode)
        {
            // rootNode cannot be null. Base class constructor throws if so.
            Account = new BankAccount(GetNestedNode(rootNode, GetNodeName(nameof(Account))));
        }
        #endregion
    }
}
