using System;
using System.Text;

namespace Restless.OfxSharper.Builder
{
    /// <summary>
    /// Provides services to build OFX requests for the bank profile message set, PROFMSGSRQV1.
    /// </summary>
    public class OfxProfileMessageSetBuilder : OfxMessageSetBuilderBase
    {
        #region Protected properties
        /// <summary>
        /// Gets the name of the message set that this builder uses.
        /// </summary>
        protected override string MessageSetName
        {
            get => $"PROFMSGSRQV{MessageSetVersion}";
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="OfxProfileMessageSetBuilder"/> class.
        /// </summary>
        /// <param name="builder">The builder object.</param>
        internal OfxProfileMessageSetBuilder(StringBuilder builder) : base(builder)
        {
        }
        #endregion

        /************************************************************************/

        #region Public methods
        /// <summary>
        /// Builds the message set.
        /// </summary>
        /// <param name="buildCallback">The build callback. This parameter is not used.</param>
        /// <remarks>
        /// This method does not use <paramref name="buildCallback"/>. It calls overload <see cref="BuildMessageSet"/> instead.
        /// </remarks>
        public override void BuildMessageSet(Action buildCallback)
        {
            BuildMessageSet();
        }

        /// <summary>
        /// Builds the message set.
        /// </summary>
        public void BuildMessageSet()
        {
            StartMessageSet();
            Builder.AppendLine("<PROFTRNRQ>");
            BuildTransactionId();
            Builder.AppendLine("<PROFRQ>");
            Builder.AppendLine("<CLIENTROUTING>MSGSET");
            Builder.AppendLine("<DTPROFUP>19970101");
            Builder.AppendLine("</PROFRQ>");
            Builder.AppendLine("</PROFTRNRQ>");
            EndMessageSet();
        }
        #endregion
    }
}
