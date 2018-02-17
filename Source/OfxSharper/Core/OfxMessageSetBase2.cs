using System;

namespace Restless.OfxSharper.Core
{
    /// <summary>
    /// Represents the base class for builders and responses that can define their message set by name and by version. 
    /// This class extends <see cref="OfxMessageSetBase1"/> to provide an additional message set definition.
    /// This class must be inherited.
    /// </summary>
    public abstract class OfxMessageSetBase2 : OfxMessageSetBase1
    {
        #region Private
        #endregion

        /************************************************************************/

        #region Public properties
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
        /// protected override string MessageSetName2
        /// {
        ///    get => $"BANKMSGSRQV{MessageSetVersion}";
        /// }
        /// </code>
        /// </remarks>
        protected abstract string MessageSetName2
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
        internal OfxMessageSetBase2(int messageSetVersion) : base(messageSetVersion)
        {
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
