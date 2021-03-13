using Restless.OfxSharper.Core;
using System.Xml;

namespace Restless.OfxSharper.Profile
{
    /// <summary>
    /// Represents the signon info portion of a financial institution profile.
    /// </summary>
    public class SignonInfoProfile : ProfileBase
    {
        #region Public properties
        /// <summary>
        /// AUTHTOKENFIRST. True if server requires clients to send AUTHTOKEN as part of the first signon, Boolean
        /// </summary>
        [NodeInfo("AUTHTOKENFIRST")]
        public bool AuthTokenFirstRequired
        {
            get;
            private set;
        }

        /// <summary>
        /// AUTHTOKENINFOURL. Url where AUTHTOKEN information is provided by the institution operating the OFX server. Required if server supports AUTHTOKEN, A-255
        /// </summary>
        [NodeInfo("AUTHTOKENINFOURL")]
        public string AuthTokenInfoUrl
        {
            get;
            private set;
        }

        /// <summary>
        /// AUTHTOKENLABEL Text label for the AUTHTOKEN. Required if server supports AUTHTOKEN, A-64
        /// </summary>
        [NodeInfo("AUTHTOKENLABEL")]
        public string AuthTokenLabel
        {
            get;
            private set;
        }

        /// <summary>
        /// CASESEN. True if password is case-sensitive, Boolean
        /// </summary>
        [NodeInfo("CASESEN")]
        public bool CaseSensitive
        {
            get;
            private set;
        }

        /// <summary>
        /// CHGPINFIRST. True if server requires clients to change USERPASS as part of first signon.
        /// However, if MFACHALLENGEFIRST is also Y, this pin change request should be sent immediately after the session
        /// containing MFACHALLENGE authentication.Boolean
        /// </summary>
        [NodeInfo("CHGPINFIRST")]
        public bool ChangePinFirst
        {
            get;
            private set;
        }

        /// <summary>
        /// CHARTYPE. Type of characters allowed in password; one of ALPHAONLY, NUMERICONLY, ALPHAORNUMERIC, or ALPHAANDNUMERIC.
        /// </summary>
        [NodeInfo("CHARTYPE")]
        public string CharacterType
        {
            get;
            private set;
        }

        /// <summary>
        /// CLIENTUIDREQ. True if the server requires a CLIENTUID, Boolean
        /// </summary>
        [NodeInfo("CLIENTUIDREQ")]
        public bool ClientUidRequired
        {
            get;
            private set;
        }

        /// <summary>
        /// MAX. Maximum number of password characters, N-2
        /// </summary>
        [NodeInfo("MAX")]
        public int Maximum
        {
            get;
            private set;
        }

        /// <summary>
        /// MIN. Minimum number of password characters, N-2
        /// </summary>
        [NodeInfo("MIN")]
        public int Minimum
        {
            get;
            private set;
        }

        /// <summary>
        /// MFACHALLENGEFIRST. True if the client is required to send MFACHALLENGERQ as part of the first signon, 
        /// before sending any other requests.Boolean
        /// </summary>
        [NodeInfo("MFACHALLENGEFIRST")]
        public bool MultifactorChallengeFirst
        {
            get;
            private set;
        }

        /// <summary>
        /// MFACHALLENGESUPT. True if the server supports MFACHALLENGE functionality, Boolean
        /// </summary>
        [NodeInfo("MFACHALLENGESUPT")]
        public bool MultiFactorChallengeSupported
        {
            get;
            private set;
        }

        /// <summary>
        /// PINCH. True if server supports USERPASSPIN-change requests, Boolean.
        /// </summary>
        [NodeInfo("PINCH")]
        public bool PinChange
        {
            get;
            private set;
        }

        /// <summary>
        /// SPACES. True if spaces are allowed, Boolean.
        /// </summary>
        [NodeInfo("SPACES")]
        public bool SpacesAllowed
        {
            get;
            private set;
        }

        /// <summary>
        /// SPECIAL. Trueif special characters are allowed, Boolean.
        /// </summary>
        [NodeInfo("SPECIAL")]
        public bool SpecialAllowed
        {
            get;
            private set;
        }

        /// <summary>
        /// USERCRED1LABEL. Text prompt for user credential.  If it is present, a third credential (USERCRED1) is required in addition to USERID and USERPASS.A-64
        /// </summary>
        [NodeInfo("USERCRED1LABEL")]
        public string UserCredentialLabel1
        {
            get;
            private set;
        }

        /// <summary>
        /// USERCRED2LABEL. Text prompt for user credential. If it is present, a fourth credential (USERCRED2) is required in addition
        /// to USERID, USERPASS and USERCRED1.If present, USERCRED1LABEL must also be present.A-64
        /// </summary>
        [NodeInfo("USERCRED2LABEL")]
        public string UserCredentialLabel2
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="SignonInfoProfile"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal SignonInfoProfile(XmlNode rootNode) : base(rootNode)
        {
            if (rootNode != null)
            {
                AuthTokenFirstRequired = GetBooleanValue(GetNestedNode(rootNode,GetNodeName(nameof(AuthTokenFirstRequired))));
                AuthTokenInfoUrl = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(AuthTokenInfoUrl))));
                AuthTokenLabel = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(AuthTokenLabel))));
                CaseSensitive = GetBooleanValue(GetNestedNode(rootNode, GetNodeName(nameof(CaseSensitive))));
                ChangePinFirst = GetBooleanValue(GetNestedNode(rootNode, GetNodeName(nameof(ChangePinFirst))));
                CharacterType = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(CharacterType))));
                ClientUidRequired = GetBooleanValue(GetNestedNode(rootNode, GetNodeName(nameof(ClientUidRequired))));
                Maximum = GetIntegerValue(GetNestedNode(rootNode, GetNodeName(nameof(Maximum))));
                Minimum = GetIntegerValue(GetNestedNode(rootNode, GetNodeName(nameof(Minimum))));
                MultifactorChallengeFirst = GetBooleanValue(GetNestedNode(rootNode, GetNodeName(nameof(MultifactorChallengeFirst))));
                MultiFactorChallengeSupported = GetBooleanValue(GetNestedNode(rootNode, GetNodeName(nameof(MultiFactorChallengeSupported))));
                PinChange = GetBooleanValue(GetNestedNode(rootNode, GetNodeName(nameof(PinChange))));
                SpecialAllowed = GetBooleanValue(GetNestedNode(rootNode, GetNodeName(nameof(SpecialAllowed))));
                SpacesAllowed = GetBooleanValue(GetNestedNode(rootNode, GetNodeName(nameof(SpacesAllowed))));
                UserCredentialLabel1 = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(UserCredentialLabel1))));
                UserCredentialLabel2 = GetNodeValue(GetNestedNode(rootNode, GetNodeName(nameof(UserCredentialLabel2))));
            }
        }
        #endregion
    }
}
