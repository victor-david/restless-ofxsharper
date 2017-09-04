using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Provides enumerated values for the type associated with <see cref="StatementBase"/>.
    /// </summary>
    public enum StatementType
    {
        /// <summary>
        /// The statement type is unspecified.
        /// </summary>
        Unspecified = 0,
        /// <summary>
        /// A bank statement.
        /// </summary>
        Bank = 1,
        /// <summary>
        /// A credit card statement.
        /// </summary>
        CreditCard = 2
    }
}
