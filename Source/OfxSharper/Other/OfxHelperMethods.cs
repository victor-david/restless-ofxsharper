using System;
using System.Text;
using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Provides static helper extension methods.
    /// </summary>
    public static class OfxHelperMethods
    {
        /// <summary>
        /// Accepts a string in YYYYMMDD format and returns a DateTime object.
        /// </summary>
        /// <param name="date">Date in YYYYMMDD format</param>
        /// <returns>A DateTime object</returns>
        public static DateTime ToDateObject(this string date)
        {
            try
            {
                if (date.Length < 8)
                {
                    return new DateTime();
                }

                var yyyy = Int32.Parse(date.Substring(0, 4));
                var mm = Int32.Parse(date.Substring(4, 2));
                var dd = Int32.Parse(date.Substring(6, 2));

                return new DateTime(yyyy, mm, dd);
            }
            catch
            {
                throw new OfxParseException("Unable to parse date");
            }
        }

        /// <summary>
        /// Accepts a DateTime object and returns a string: YYYYMMDD
        /// </summary>
        /// <param name="date">The date</param>
        /// <returns>The date as a string in YYYYMMDD format.</returns>
        public static string ToDateString(this DateTime date)
        {
            string year = date.Year.ToString();
            string month = date.Month.ToString("D2");
            string day = date.Day.ToString("D2");
            return String.Format("{0}{1}{2}", year, month, day);
        }

        /// <summary>
        /// Formats an Xml document.
        /// </summary>
        /// <param name="doc">The doc</param>
        /// <returns>A more readable string</returns>
        public static string Prettify(this XmlDocument doc)
        {
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "    ",
                NewLineChars = "\r\n",
                NewLineHandling = NewLineHandling.Replace
            };
            using (XmlWriter writer = XmlWriter.Create(sb, settings))
            {
                doc.Save(writer);
            }
            return sb.ToString();
        }
    }
}