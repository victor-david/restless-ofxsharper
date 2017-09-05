using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents a list of string values.
    /// </summary>
    public class StringList : List<string>
    {
        /// <summary>
        /// Returns the concatentated strings of the list, separated by ";".
        /// </summary>
        /// <returns>The concatentated strings of the list, separated by ";".</returns>
        public override string ToString()
        {
            return ToString(";");
        }

        /// <summary>
        /// Returns the concatentated strings of the list, separated by the specified delimiter.
        /// </summary>
        /// <param name="delimiter">The desired delimiter.</param>
        /// <returns>The concatentated strings of the list, separated by <paramref name="delimiter"/>.</returns>
        public string ToString(string delimiter)
        {
            StringBuilder builder = new StringBuilder();
            foreach (string str in this)
            {
                builder.Append(str + delimiter);
            }
            // Remove last delimiter.
            if (builder.Length > 0)
            {
                builder.Remove(builder.Length - 1, delimiter.Length);
            }
            return builder.ToString();
        }
    }
}
