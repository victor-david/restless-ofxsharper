using System;
using System.Runtime.Serialization;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents an Ofx exception.
    /// </summary>
    [Serializable]
    public class OfxException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OfxException"/> class with a non-specific message.
        /// </summary>
        public OfxException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OfxException"/> class with the specified message.
        /// </summary>
        /// <param name="message">The message to provide to the exception.</param>
        public OfxException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OfxException"/> class with the specified message and inner exception
        /// </summary>
        /// <param name="message">The message to provide to the exception.</param>
        /// <param name="inner">The inner exception.</param>
        public OfxException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}