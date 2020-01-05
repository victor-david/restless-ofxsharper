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
        protected override string MessageSetName1
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
        /// <param name="messageSetVersion">The message set version to use.</param>
        internal OfxSignonMessageSetBuilder(StringBuilder builder, int messageSetVersion) : base(builder, messageSetVersion)
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
            Builder.AppendLine($"<DTCLIENT>{DateTime.Now.ToString("yyyyMMddhhmmss")}");
            Builder.AppendLine($"<USERID>{bank.UserId}");
            Builder.AppendLine($"<USERPASS>{bank.Password}");
            Builder.AppendLine("<GENUSERKEY>N");
            Builder.AppendLine($"<LANGUAGE>{bank.OfxLanguage}");
            Builder.AppendLine("<FI>");
            Builder.AppendLine($"<ORG>{bank.Org}");
            Builder.AppendLine($"<FID>{bank.OfxId}");
            Builder.AppendLine("</FI>");
            Builder.AppendLine($"<APPID>{bank.AppId}");
            Builder.AppendLine($"<APPVER>{bank.AppVersion}");
            if (!string.IsNullOrEmpty(bank.ClientUid))
            {
                Builder.AppendLine($"<CLIENTUID>{bank.ClientUid}");
            }
            Builder.AppendLine("</SONRQ>");
            Builder.AppendLine("</SIGNONMSGSRQV1>");
        }
        #endregion

        /************************************************************************/

        #region Private methods
        #endregion
    }
}
