using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ImgurLib
{
    [DataContract]
    internal class TokenResponse
    {
        [DataMember(Name = "access_token")]
        public string AccessToken { get; private set; }

        [DataMember(Name = "refresh_token")]
        public string RefreshToken { get; private set; }

        [DataMember(Name = "expires_in")]
        public int ExpiresIn { get; private set; }

        [DataMember(Name = "token_type")]
        public string TokenType { get; private set; }

        [DataMember(Name = "account_username")]
        public string AccountUsername { get; private set; }

        [DataMember(Name = "scope")]
        public string Scope { get; private set; }

        public TokenResponse() { }

        public static TokenResponse FromBytes(byte[] bytes)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(TokenResponse));
            TokenResponse responseData = (TokenResponse)ser.ReadObject(new MemoryStream(bytes));

            return responseData;
        }
    }
}
