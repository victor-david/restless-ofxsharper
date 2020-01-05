namespace Restless.OfxSharper.Core
{
    /// <summary>
    /// Defines an interface bank to use with <see cref="OfxRequestBuilder"/>.
    /// </summary>
    public interface IBank
    {
        /// <summary>
        /// Gets or sets the client unique id.
        /// </summary>
        string ClientUid { get; set; }

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

        /// <summary>
        /// Gets or sets the Ofx language.
        /// </summary>
        string OfxLanguage { get; set; }
    }
}
