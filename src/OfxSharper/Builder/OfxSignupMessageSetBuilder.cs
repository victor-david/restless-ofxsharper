using System.Text;

namespace Restless.OfxSharper.Builder
{
    /// <summary>
    /// Provides services to build OFX requests for the signup message set, SIGNUPMSGSRQV1.
    /// </summary>
    public class OfxSignupMessageSetBuilder : OfxMessageSetBuilderBase
    {
        #region Protected properties
        /// <summary>
        /// Gets the name of the message set that this builder uses.
        /// </summary>
        protected override string MessageSetName1
        {
            get => $"SIGNUPMSGSRQV{MessageSetVersion}"; 
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="OfxSignupMessageSetBuilder"/> class.
        /// </summary>
        /// <param name="builder">The builder object.</param>
        /// <param name="messageSetVersion">The message set version to use.</param>
        internal OfxSignupMessageSetBuilder(StringBuilder builder, int messageSetVersion) : base(builder, messageSetVersion)
        {
        }
        #endregion

        /************************************************************************/

        #region Public methods
        /// <summary>
        /// Builds an account information request, ACCTINFOTRNRQ
        /// This method must be called from the callback method of <see cref="OfxMessageSetBuilderBase.BuildMessageSet(Action)"/>
        /// </summary>
        public void BuildAccountInfoRequest()
        {
            Builder.AppendLine("<ACCTINFOTRNRQ>");
            BuildTransactionId();
            Builder.AppendLine("<CLTCOOKIE>4");
            Builder.AppendLine("<ACCTINFORQ>");
            Builder.AppendLine("<DTACCTUP>19700101");
            Builder.AppendLine("</ACCTINFORQ>");
            Builder.AppendLine("</ACCTINFOTRNRQ>");
        }
        #endregion

        /************************************************************************/

        #region Private methods
        #endregion
    }
}
