using Restless.OfxSharper.Core;
using System;
using System.Text;

namespace Restless.OfxSharper.Builder
{
    /// <summary>
    /// Provides services to build OFX requests for the signup message set, SIGNONMSGSRQV1.
    /// </summary>
    public class OfxSignonMessageSetBuilder : OfxMessageSetBuilderBase
    {
        #region Protected properties
        /// <summary>
        /// Gets the name of the message set that this builder uses.
        /// </summary>
        protected override string MessageSetName
        {
            get => $"SIGNONMSGSRQV{MessageSetVersion}"; 
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="OfxSignonMessageSetBuilder"/> class.
        /// </summary>
        /// <param name="builder">The builder object.</param>
        internal OfxSignonMessageSetBuilder(StringBuilder builder) : base(builder)
        {
        }
        #endregion

        /************************************************************************/

        #region Public methods
        /// <summary>
        /// This method always throws an exception. Use <see cref="BuildMessageSet(IBank)"/> instead.
        /// </summary>
        /// <param name="buildCallback"></param>
        public override void BuildMessageSet(Action buildCallback)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Builds the message set
        /// </summary>
        /// <param name="bank">The bank</param>
        public void BuildMessageSet(IBank bank)
        {
            ValidateNull(bank, nameof(bank));
            Builder.AppendLine("<SIGNONMSGSRQV1>");
            Builder.AppendLine("<SONRQ>");
            Builder.AppendLine(String.Format("<DTCLIENT>{0}", DateTime.Now.ToString("yyyyMMddhhmmss")));
            Builder.AppendLine(String.Format("<USERID>{0}", bank.UserId));
            Builder.AppendLine(String.Format("<USERPASS>{0}", bank.Password));
            Builder.AppendLine("<GENUSERKEY>N");
            Builder.AppendLine(String.Format("<LANGUAGE>{0}", bank.OfxLanguage));
            Builder.AppendLine("<FI>");
            Builder.AppendLine(String.Format("<ORG>{0}", bank.Org));
            Builder.AppendLine(String.Format("<FID>{0}", bank.OfxId));
            Builder.AppendLine("</FI>");
            Builder.AppendLine(String.Format("<APPID>{0}", bank.AppId));
            Builder.AppendLine(String.Format("<APPVER>{0}", bank.AppVersion));
            Builder.AppendLine("</SONRQ>");
            Builder.AppendLine("</SIGNONMSGSRQV1>");
        }
        #endregion

        /************************************************************************/

        #region Private methods
        #endregion
    }
}
