using System;

namespace Restless.OfxSharper.Core
{
    /// <summary>
    /// Represents the base class for builders and responses that can define their message set by name and by version. This class must be inherited.
    /// </summary>
    public abstract class OfxMessageSetBase1 : OfxObjectBase
    {
        #region Private
        private int messageSetVersion;
        #endregion

        /************************************************************************/

        #region Public fields
        /// <summary>
        /// Gets the minimum message set version supported.
        /// </summary>
        public const int MinMessageSetVersion = 1;

        /// <summary>
        /// Gets the maximum message set version supported.
        /// </summary>
        public const int MaxMessageSetVersion = 2;

        /// <summary>
        /// Gets the default message set version.
        /// </summary>
        public const int DefaultMessageSetVersion = 1;

        #endregion

        /************************************************************************/

        #region Public properties
        /// <summary>
        /// Version to use for the message set. Default is <see cref="DefaultMessageSetVersion"/>.
        /// </summary>
        /// <remarks>
        /// The value for this property is clamped between <see cref="MinMessageSetVersion"/> and <see cref="MaxMessageSetVersion"/>.
        /// </remarks>
        public int MessageSetVersion
        {
            get => messageSetVersion;
            private set => messageSetVersion = Math.Min(Math.Max(value, MinMessageSetVersion), MaxMessageSetVersion);
        }
        #endregion

        /************************************************************************/

        #region Protected properties
        /// <summary>
        /// When implemented in a derived class, gets the message set name.
        /// Do not hard code the message set version in the name.
        /// Ex: get=> $"BANKMSGSRQV{MessageSetVersion}";
        /// </summary>
        /// <remarks>
        /// When this property is implemented in a derived class, it must return
        /// the message set name with the specified version attached. Example:
        /// <code>
        /// protected override string MessageSetName
        /// {
        ///    get => $"BANKMSGSRQV{MessageSetVersion}";
        /// }
        /// </code>
        /// </remarks>
        protected abstract string MessageSetName1
        {
            get;
        }

        #endregion

        /************************************************************************/

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="OfxMessageSetBuilderBase"/> class.
        /// </summary>
        /// <param name="messageSetVersion">The message set version to use.</param>
        internal OfxMessageSetBase1(int messageSetVersion)
        {
            MessageSetVersion = messageSetVersion;
        }
        #endregion

        /************************************************************************/

        #region Public methods
        #endregion

        /************************************************************************/

        #region Protected methods
        #endregion

        /************************************************************************/

        #region Private methods
        #endregion
    }
}
