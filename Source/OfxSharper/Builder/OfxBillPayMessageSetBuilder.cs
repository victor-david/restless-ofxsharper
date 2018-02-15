using System.Text;

namespace Restless.OfxSharper.Builder
{
    /// <summary>
    /// Provides services to build OFX requests for the bill pay message set, BILLPAYMSGSRQV1.
    /// </summary>
    public class OfxBillPayMessageSetBuilder : OfxMessageSetBuilderBase
    {
        #region Protected properties
        /// <summary>
        /// Gets the name of the message set that this builder uses.
        /// </summary>
        protected override string MessageSetName
        {
            get => $"BILLPAYMSGSRQV{MessageSetVersion}"; 
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="OfxBillPayMessageSetBuilder"/> class.
        /// </summary>
        /// <param name="builder">The builder object.</param>
        internal OfxBillPayMessageSetBuilder(StringBuilder builder) : base(builder)
        {
        }
        #endregion

        /************************************************************************/

        #region Public methods
        /// <summary>
        /// Build a payee list request, PAYEESYNCRQ
        /// This method must be called from the callback method of <see cref="OfxMessageSetBuilderBase.BuildMessageSet(Action)"/>
        /// </summary>
        public void BuildPayeeListRequest()
        {
            Builder.AppendLine("<PAYEESYNCRQ>");
            Builder.AppendLine("<REFRESH>Y");
            Builder.AppendLine("<REJECTIFMISSING>N");
            Builder.AppendLine("</PAYEESYNCRQ>");
        }
        #endregion

        /************************************************************************/

        #region Private methods
        #endregion
    }
}
