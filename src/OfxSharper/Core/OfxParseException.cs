using System;

namespace Restless.OfxSharper.Core
{
    /// <summary>
    /// Represents an Ofx parsing exception.
    /// </summary>
    [Serializable]
    public class OfxParseException : OfxException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OfxParseException"/> class with a non-specific message.
        /// </summary>
        public OfxParseException() : base("Non specific OfxParseException")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OfxParseException"/> class with the specified message.
        /// </summary>
        /// <param name="message">The message to provide to the exception.</param>
        public OfxParseException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OfxParseException"/> class with the specified message and inner exception
        /// </summary>
        /// <param name="message">The message to provide to the exception.</param>
        /// <param name="inner">The inner exception.</param>
        public OfxParseException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}