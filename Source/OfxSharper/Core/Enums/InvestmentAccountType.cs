using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restless.OfxSharper.Core
{
    /// <summary>
    /// Describes the investment account types returned in the INVACCTTYPE tag.
    /// </summary>
    public enum InvestmentAccountType
    {
        /// <summary>
        /// The investment account type is unknown.
        /// </summary>
        Unknown,
        /// <summary>
        /// Individual account.
        /// </summary>
        Individual,
        /// <summary>
        /// Joint account.
        /// </summary>
        Joint,
        /// <summary>
        /// Trust account.
        /// </summary>
        Trust,
        /// <summary>
        /// Corporate account.
        /// </summary>
        Corporate

    }

    internal static class InvestmentAccountTypeExtension
    {
        internal static InvestmentAccountType ToInvestmentAccountType(this string str)
        {
            if (Enum.TryParse(str, true, out InvestmentAccountType result))
            {
                return result;
            }
            return InvestmentAccountType.Unknown;
        }
    }
}
