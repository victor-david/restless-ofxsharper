using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restless.OfxSharper.Core
{
    /// <summary>
    /// Provides enumerated value that specify the source of a transaction's currency.
    /// </summary>
    public enum CurrencySource
    {
        /// <summary>
        /// Source is the default currency, CURDEF.
        /// </summary>
        DefaultCurrency,
        /// <summary>
        /// Source is an overriding (not default) currency, CURRENCY.
        /// </summary>
        Currency,
        /// <summary>
        /// Source is expressed as original currency, ORIGCURRENCY.
        /// </summary>
        OriginalCurrency,
        
    }
}
