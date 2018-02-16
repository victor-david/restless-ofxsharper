using System;

namespace Restless.OfxSharper.Core
{
    /// <summary>
    /// Represents the OFX header.
    /// </summary>
    public class OfxHeader : OfxObjectBase
    {
        #region Public properties
        /// <summary>
        /// Gets the Ofx header, 100
        /// </summary>
        [NodeInfo("OFXHEADER:")]
        public string Header
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the Data header.
        /// </summary>
        [NodeInfo("DATA:")]
        public string Data
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the version header.
        /// </summary>
        [NodeInfo("VERSION:")]
        public string Version
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the security header.
        /// </summary>
        [NodeInfo("SECURITY:")]
        public string Security
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the encoding header.
        /// </summary>
        [NodeInfo("ENCODING:")]
        public string Encoding
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the charset header.
        /// </summary>
        [NodeInfo("CHARSET:")]
        public string Charset
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the compression header.
        /// </summary>
        [NodeInfo("COMPRESSION:")]
        public string Compression
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the old file uid header.
        /// </summary>
        [NodeInfo("OLDFILEUID:")]
        public string OldFileUid
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the new file uid header.
        /// </summary>
        [NodeInfo("NEWFILEUID:")]
        public string NewFileUid
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the index where the header ends. Used internally in subsequent processing.
        /// </summary>
        internal int HeaderEnd
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="OfxHeader"/> class.
        /// </summary>
        /// <param name="inputStr"></param>
        internal OfxHeader(string inputStr)
        {
            ValidateNull(inputStr, "OfxHeader.InputStr");
            // "<" marks the opening OFX tag
            HeaderEnd = inputStr.IndexOf("<");
            ValidateOfxParseOperation(HeaderEnd == -1, "Invalid input string");

            string headerStr = inputStr.Substring(0, HeaderEnd).Trim();
            string[] headers = headerStr.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            ValidateOfxParseOperation(headers.Length < 9, "Invalid header");
            Header = headers[0].Substring(GetNodeName(nameof(Header)).Length);
            Data = headers[1].Substring(GetNodeName(nameof(Data)).Length);
            Version = headers[2].Substring(GetNodeName(nameof(Version)).Length);
            Security = headers[3].Substring(GetNodeName(nameof(Security)).Length);
            Encoding = headers[4].Substring(GetNodeName(nameof(Encoding)).Length);
            Charset = headers[5].Substring(GetNodeName(nameof(Charset)).Length);
            Compression = headers[6].Substring(GetNodeName(nameof(Compression)).Length);
            OldFileUid = headers[7].Substring(GetNodeName(nameof(OldFileUid)).Length);
            NewFileUid = headers[8].Substring(GetNodeName(nameof(NewFileUid)).Length);
            ValidateHeader();
        }
        #endregion

        /************************************************************************/

        #region Private methods
        private void ValidateHeader()
        {
            ValidateOfxParseOperation(Header != "100", "Incorrect header format");
            ValidateOfxParseOperation(Data != "OFXSGML", String.Format("Data type {0} not supported - OFXSGML required", Data));
            ValidateOfxParseOperation(Version != "102" && Version != "103", String.Format("Ofx version {0} not supported", Version));
            ValidateOfxParseOperation(Security != "NONE", "Ofx security not supported");
            ValidateOfxParseOperation(Encoding != "USASCII", String.Format("Encoding {0} not supported", Encoding));
            ValidateOfxParseOperation(Charset != "1252", String.Format("Charset {0} not supported", Charset));
            ValidateOfxParseOperation(Compression != "NONE", "Compression not supported");
        }
        #endregion
    }
}
