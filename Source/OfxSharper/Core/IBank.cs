using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Defines an interface bank to use with <see cref="OfxRequestBuilder"/>.
    /// </summary>
    public interface IBank
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        string UserId { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// Gets or sets the organization code.
        /// </summary>
        string Org { get; set; }

        /// <summary>
        /// Gets or sets the Ofx id. FID
        /// </summary>
        string OfxId { get; set; }

        /// <summary>
        /// Gets or sets the application id.
        /// </summary>
        string AppId { get; set; }

        /// <summary>
        /// Gets or sets the application version.
        /// </summary>
        string AppVersion { get; set; }
    }
}
