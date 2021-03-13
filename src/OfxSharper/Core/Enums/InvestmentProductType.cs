using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restless.OfxSharper.Core
{
    /// <summary>
    /// Describes the investment product types returned in the USPRODUCTTYPE tag.
    /// </summary>
    public enum InvestmentProductType
    {
        /// <summary>
        /// Product type is unknown.
        /// </summary>
        Unknown,
        /// <summary>
        /// 401K. A 401(K) account
        /// </summary>
        K401,
        /// <summary>
        /// 403B. A 403(B) account
        /// </summary>
        B403,
        /// <summary>
        /// An IRA account
        /// </summary>
        IRA,
        /// <summary>
        /// Keogh (Money Purchase/Profit Sharing)
        /// </summary>
        KEOGH,
        /// <summary>
        /// Other account type
        /// </summary>
        OTHER,
        /// <summary>
        /// Salary Reduction Simplified Employer Pension plan
        /// </summary>
        SARSEP,
        /// <summary>
        /// Savings Incentive Match Plan for employees
        /// </summary>
        SIMPLE,
        /// <summary>
        /// Regular account
        /// </summary>
        NORMAL,
        /// <summary>
        /// Tax Deferred Annuity
        /// </summary>
        TDA,
        /// <summary>
        /// Trust (including UTMA)
        /// </summary>
        TRUST,
        /// <summary>
        /// Custodial account
        /// </summary>
        UGMA
    }

    /// <summary>
    /// Provides extension methods for converting <see cref="InvestmentProductType"/>.
    /// </summary>
    public static class InvestmentProductTypeExtension
    {
        internal static InvestmentProductType ToInvestmentProductType(this string str)
        {
            switch (str.ToUpperInvariant())
            {
                // these first two need special handling b/c the strings
                // come in starting with a digit, and can't start an enum id with a digit.
                case "401K":
                    return InvestmentProductType.K401;
                case "403B":
                    return InvestmentProductType.B403;
                default:
                    if (Enum.TryParse(str, true, out InvestmentProductType result))
                    {
                        return result;
                    }
                    return InvestmentProductType.Unknown;
            }
        }

        /// <summary>
        /// Returns an upper case string for the specified type.
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>A string</returns>
        public static string ToUpperString(this InvestmentProductType type)
        {
            switch (type)
            {
                case InvestmentProductType.K401:
                    return "401K";
                case InvestmentProductType.B403:
                    return "403B";
                default:
                    return Enum.GetName(typeof(InvestmentProductType), type).ToUpperInvariant();
            }
        }
    }
}
