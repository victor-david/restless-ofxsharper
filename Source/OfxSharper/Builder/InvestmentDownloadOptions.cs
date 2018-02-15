using System;

namespace Restless.OfxSharper.Builder
{
    /// <summary>
    /// Represents a set of options that may be applied 
    /// when building an investment account statement request.
    /// </summary>
    public class InvestmentDownloadOptions
    {
        /// <summary>
        /// Gets or sets a boolean value that indicates if transactions are requested.
        /// </summary>
        public bool IncludeTransactions
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the starting date for transactions to be included.
        /// </summary>
        public DateTime? TransactionStart
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ending date for transactions to be included.
        /// </summary>
        public DateTime? TransactionEnd
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a boolean value that indicates if open orders information is requested.
        /// </summary>
        public bool IncludeOpenOrders
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a boolean value that indicates if position data is requested.
        /// </summary>
        public bool IncludePosition
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the date for position data. Leave at null for most current position data.
        /// </summary>
        public DateTime? PositionDate
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets a boolean value that indicates if balance data is requested.
        /// </summary>
        public bool IncludeBalance
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvestmentDownloadOptions"/> class.
        /// </summary>
        public InvestmentDownloadOptions()
        {

        }
    }
}
