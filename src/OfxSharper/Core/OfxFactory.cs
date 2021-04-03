using Restless.OfxSharper.Builder;
using Restless.OfxSharper.Core;
using Restless.OfxSharper.Profile;
using Sgml;
using System;
using System.IO;
using System.Text;
using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Provides methods to instansiate <see cref="OfxResponse"/>, <see cref="OfxProfileResponse"/> 
    /// and <see cref="OfxRequestBuilder"/> objects.
    /// </summary>
    public static class OfxFactory
    {
        #region Public methods (OfxResponse)
        /// <summary>
        /// Provides methods to create <see cref="OfxResponse"/> objects.
        /// </summary>
        public static class Response
        {
            /// <summary>
            /// Creates a <see cref="OfxResponse"/> object from the specified Ofx response string.
            /// </summary>
            /// <param name="inputStr">The input string.</param>
            /// <param name="messageSetVersion">The message set version to use.</param>
            /// <returns>An OfxResponse object.</returns>
            public static OfxResponse Create(string inputStr, int messageSetVersion)
            {
                OfxHeader header = new OfxHeader(inputStr);
                string xmlStr = SgmlToXml(inputStr.Substring(header.HeaderEnd));
                var doc = new XmlDocument();
                doc.Load(new StringReader(xmlStr));
                OfxResponse ofxResponse = new OfxResponse(header, doc, messageSetVersion);
                return ofxResponse;
            }

            /// <summary>
            /// Creates a <see cref="OfxResponse"/> object from the specified Ofx response string.
            /// Uses <see cref="MessageSetBase.DefaultMessageSetVersion"/>.
            /// </summary>
            /// <param name="inputStr">The input string.</param>
            /// <returns>An OfxResponse object.</returns>
            public static OfxResponse Create(string inputStr)
            {
                return Create(inputStr, OfxMessageSetBase1.DefaultMessageSetVersion);
            }


            /// <summary>
            /// Creates a <see cref="OfxResponse"/> object from the specified file stream.
            /// </summary>
            /// <param name="stream">The file stream.</param>
            /// <param name="messageSetVersion">The message set version to use.</param>
            /// <returns>An OfxResponse object.</returns>
            public static OfxResponse Create(FileStream stream, int messageSetVersion)
            {
                using (var reader = new StreamReader(stream, Encoding.Default))
                {
                    return Create(reader.ReadToEnd(), messageSetVersion);
                }
            }

            /// <summary>
            /// Creates a <see cref="OfxResponse"/> object from the specified file stream.
            /// Uses <see cref="MessageSetBase.DefaultMessageSetVersion"/>.
            /// </summary>
            /// <param name="stream">The file stream.</param>
            /// <param name="messageSetVersion">The message set version to use.</param>
            /// <returns>An OfxResponse object.</returns>
            public static OfxResponse Create(FileStream stream)
            {
                return Create(stream, OfxMessageSetBase1.DefaultMessageSetVersion);
            }
        }
        #endregion

        /************************************************************************/

        #region Public methods (OfxProfileResponse)
        /// <summary>
        /// Provides methods to create <see cref="OfxProfileResponse"/> objects.
        /// </summary>
        public static class ProfileResponse
        {
            /// <summary>
            /// Creates a <see cref="OfxProfileResponse"/> object from the specified Ofx response string.
            /// </summary>
            /// <param name="inputStr">The input string.</param>
            /// <returns>An OfxProfileResponse object.</returns>
            public static OfxProfileResponse Create(string inputStr)
            {
                OfxHeader header = new OfxHeader(inputStr);
                string xmlStr = SgmlToXml(inputStr.Substring(header.HeaderEnd));
                var doc = new XmlDocument();
                doc.Load(new StringReader(xmlStr));
                OfxProfileResponse ofxProfileResponse = new OfxProfileResponse(header, doc);
                return ofxProfileResponse;
            }

            /// <summary>
            /// Creates a <see cref="OfxProfileResponse"/> object from the specified file stream.
            /// </summary>
            /// <param name="stream">The file stream.</param>
            /// <returns>An OfxProfileResponse object.</returns>
            public static OfxProfileResponse Create(FileStream stream)
            {
                using (var reader = new StreamReader(stream, Encoding.Default))
                {
                    return Create(reader.ReadToEnd());
                }
            }
        }
        #endregion

        /************************************************************************/

        #region Public methods (OfxRequestBuilder)
        /// <summary>
        /// Provides methods to create <see cref="OfxRequestBuilder"/> objects.
        /// </summary>
        public static class Builder
        {
            /// <summary>
            /// Creates an <see cref="OfxRequestBuilder"/> object.
            /// </summary>
            /// <param name="messageSetVersion">The message set version to use.</param>
            /// <returns>An OfxRequestBuilder object.</returns>
            public static OfxRequestBuilder Create(int messageSetVersion)
            {
                return new OfxRequestBuilder(messageSetVersion);
            }

            /// <summary>
            /// Creates an <see cref="OfxRequestBuilder"/> object.
            /// </summary>
            /// <returns>An OfxRequestBuilder object.</returns>
            public static OfxRequestBuilder Create()
            {
                return Create(OfxMessageSetBuilderBase.DefaultMessageSetVersion);
            }
        }
        #endregion

        /************************************************************************/

        #region Private methods
        /// <summary>
        /// Converts Sgml to Xml
        /// </summary>
        /// <param name="inputStr">OFX File (SGML Format)</param>
        /// <returns>OFX File in XML format</returns>
        private static string SgmlToXml(string inputStr)
        {
            var reader = new SgmlReader
            {
                InputStream = new StringReader(inputStr),
                DocType = "OFX"
            };

            var sw = new StringWriter();
            var xml = new XmlTextWriter(sw);

            //write output of sgml reader to xml text writer
            while (!reader.EOF)
            {
                xml.WriteNode(reader, true);
            }

            //close xml text writer
            xml.Flush();
            xml.Close();

            var temp = sw.ToString().TrimStart().Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            return String.Join(String.Empty, temp);
        }

        #endregion
    }
}
