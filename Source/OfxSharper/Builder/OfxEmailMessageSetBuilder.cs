using System.Text;

namespace Restless.OfxSharper.Builder
{
    /// <summary>
    /// Provides services to build OFX requests for the email message set, EMAILMSGSV1.
    /// </summary>
    public class OfxEmailMessageSetBuilder : OfxMessageSetBuilderBase
    {
        #region Protected properties
        /// <summary>
        /// Gets the name of the message set that this builder uses.
        /// </summary>
        protected override string MessageSetName
        {
            get => $"EMAILMSGSV{MessageSetVersion}"; 
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="OfxEmailMessageSetBuilder"/> class.
        /// </summary>
        /// <param name="builder">The builder object.</param>
        internal OfxEmailMessageSetBuilder(StringBuilder builder) : base(builder)
        {
        }
        #endregion

        /************************************************************************/

        #region Public methods
        /// <summary>
        /// Build an email synchronization request (non account specific).
        /// This method must be called from the callback method of <see cref="OfxMessageSetBuilderBase.BuildMessageSet(Action)"/>
        /// </summary>
        /// <param name="token">The starting message token, or null for none (server will decide)</param>
        public void BuildSynchronizationRequest(string token)
        {
            Builder.AppendLine("<MAILSYNCRQ>");
            BuildToken(token);
            Builder.AppendLine("<REJECTIFMISSING>N");
            Builder.AppendLine("<INCIMAGES>N");
            Builder.AppendLine("<USEHTML>N");
            Builder.AppendLine("</MAILSYNCRQ>");
        }
        #endregion

        /************************************************************************/

        #region Private methods
        #endregion
    }
}
