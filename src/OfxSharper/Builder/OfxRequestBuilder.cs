using Restless.OfxSharper.Core;
using System;
using System.Text;

namespace Restless.OfxSharper.Builder
{
    /// <summary>
    /// Provides mechanisms for building an Ofx request.
    /// </summary>
    /// <remarks>
    /// <para>
    /// 2.4.5.2 Message Set Ordering. Message sets must appear in the following order:
    /// </para>
    /// <list type="bullet">
    /// <item><description>Signon</description></item>
    /// <item><description>Signup</description></item>
    /// <item><description>Banking</description></item>
    /// <item><description>Credit card statements</description></item>
    /// <item><description>Investment statements</description></item>
    /// <item><description>Interbank funds transfers</description></item>
    /// <item><description>Wire funds transfers</description></item>
    /// <item><description>Payments</description></item>
    /// <item><description>General e-mail</description></item>
    /// <item><description>Investment security list</description></item>
    /// <item><description>FI Profile</description></item>
    /// </list>
    /// </remarks>
    public sealed class OfxRequestBuilder : OfxObjectBase
    {
        #region Private
        private StringBuilder builder;
        #endregion

        /************************************************************************/

        #region Public properties    
        /// <summary>
        /// Gets the request text that was generated.
        /// </summary>
        public string RequestText => builder.ToString();

        /// <summary>
        /// Gets the builder object that handles the bank message set.
        /// </summary>
        public OfxBankMessageSetBuilder Bank
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the builder object that handles the bill pay message set.
        /// </summary>
        public OfxBillPayMessageSetBuilder BillPay
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the builder object that handles the credit card message set.
        /// </summary>
        public OfxCreditCardMessageSetBuilder CreditCard
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the builder object that handles the email message set.
        /// </summary>
        public OfxEmailMessageSetBuilder Email
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the builder object that handles the investment message set.
        /// </summary>
        public OfxInvestmentMessageSetBuilder Investment
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the builder object that handles the profile message set.
        /// </summary>
        public OfxProfileMessageSetBuilder Profile
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the builder object that handles the signon message set.
        /// </summary>
        public OfxSignonMessageSetBuilder Signon
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the builder object that handles the signup message set.
        /// </summary>
        public OfxSignupMessageSetBuilder Signup
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="OfxRequestBuilder"/> class.
        /// </summary>
        internal OfxRequestBuilder(int messageSetVersion)
        {
            builder = new StringBuilder(1024);
            Bank = new OfxBankMessageSetBuilder(builder, messageSetVersion);
            BillPay = new OfxBillPayMessageSetBuilder(builder, messageSetVersion);
            CreditCard = new OfxCreditCardMessageSetBuilder(builder, messageSetVersion);
            Email = new OfxEmailMessageSetBuilder(builder, messageSetVersion);
            Investment = new OfxInvestmentMessageSetBuilder(builder, messageSetVersion);
            Profile = new OfxProfileMessageSetBuilder(builder, messageSetVersion);
            Signon = new OfxSignonMessageSetBuilder(builder, messageSetVersion);
            Signup = new OfxSignupMessageSetBuilder(builder, messageSetVersion);
        }
        #endregion

        /************************************************************************/

        #region Public methods (main entry method)
        /// <summary>
        /// Builds an Ofx request. This is the top level method you must call. All other calls
        /// are nested via <paramref name="buildCallback"/>.
        /// </summary>
        /// <param name="buildCallback">Callback method. Use this method to call other build methods</param>
        /// <param name="oldFileId">The old file id, or null to use NONE.</param>
        /// <param name="newFileId">The new file id, or null to use NONE.</param>
        public void BuildOfxRequest(Action buildCallback, string oldFileId = null, string newFileId = null, long ofxVersion = 102)
        {
            ValidateNull(buildCallback, nameof(buildCallback));
            builder.Clear();
            // Create the header
            if (string.IsNullOrEmpty(oldFileId)) oldFileId = "NONE";
            if (string.IsNullOrEmpty(newFileId)) newFileId = "NONE";
            builder.AppendLine("OFXHEADER:100");
            builder.AppendLine("DATA:OFXSGML");
            builder.AppendLine($"VERSION:{ofxVersion}");
            builder.AppendLine("SECURITY:NONE");
            builder.AppendLine("ENCODING:USASCII");
            builder.AppendLine("CHARSET:1252");
            builder.AppendLine("COMPRESSION:NONE");
            builder.AppendLine($"OLDFILEUID:{oldFileId}");
            builder.AppendLine($"NEWFILEUID:{newFileId}");
            builder.AppendLine();
            builder.AppendLine("<OFX>");
            buildCallback();
            builder.AppendLine("</OFX>");
        }
        #endregion

        /************************************************************************/

        #region Public methods (other)
        /// <summary>
        /// Clears the builder
        /// </summary>
        public void Clear()
        {
            builder.Clear();
        }
        #endregion
    }
}
