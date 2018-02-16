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
        /// Creates a <see cref="OfxResponse"/> object from the specified Ofx response string.
        /// </summary>
        /// <param name="inputStr">The input string.</param>
        /// <returns>An OfxResponse object.</returns>
        public static OfxResponse CreateResponse(string inputStr)
        {
            OfxHeader header = new OfxHeader(inputStr);
            string xmlStr = SgmlToXml(inputStr.Substring(header.HeaderEnd));
            var doc = new XmlDocument();
            doc.Load(new StringReader(xmlStr));
            OfxResponse ofxResponse = new OfxResponse(header, doc);
            return ofxResponse;
        }

        /// <summary>
        /// Creates a <see cref="OfxResponse"/> object from the specified file stream.
        /// </summary>
        /// <param name="stream">The file stream.</param>
        /// <returns>An OfxResponse object.</returns>
        public static OfxResponse CreateResponse(FileStream stream)
        {
            using (var reader = new StreamReader(stream, Encoding.Default))
            {
                return CreateResponse(reader.ReadToEnd());
            }
        }
        #endregion

        /************************************************************************/

        #region Public methods (OfxProfileResponse)
        /// <summary>
        /// Creates a <see cref="OfxProfileResponse"/> object from the specified Ofx response string.
        /// </summary>
        /// <param name="inputStr">The input string.</param>
        /// <returns>An OfxProfileResponse object.</returns>
        public static OfxProfileResponse CreateProfileResponse(string inputStr)
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
        public static OfxProfileResponse CreateProfileResponse(FileStream stream)
        {
            using (var reader = new StreamReader(stream, Encoding.Default))
            {
                return CreateProfileResponse(reader.ReadToEnd());
            }
        }
        #endregion

        /************************************************************************/

        #region Public methods (OfxRequestBuilder)
        /// <summary>
        /// Creates an <see cref="OfxRequestBuilder"/> object.
        /// </summary>
        /// <returns>An OfxRequestBuilder object.</returns>
        public static OfxRequestBuilder CreateBuilder()
        {
            return new OfxRequestBuilder();
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
