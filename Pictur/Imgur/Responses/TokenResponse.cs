using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Pictur
{
    [Serializable]
    [DataContract]
    public class TokenResponse
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

        public TokenResponse(SerializationInfo info, StreamingContext ctxt)
        {
            this.AccessToken = info.GetString("access_token");
            this.RefreshToken = info.GetString("refresh_token");
            this.ExpiresIn = info.GetInt32("expires_in");
            this.TokenType = info.GetString("token_type");
            this.AccountUsername = info.GetString("account_username");
            this.Scope = info.GetString("scope");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("access_token", this.AccessToken);
            info.AddValue("refresh_token", this.RefreshToken);
            info.AddValue("expires_in", this.ExpiresIn);
            info.AddValue("token_type", this.TokenType);
            info.AddValue("account_username", this.AccountUsername);
            info.AddValue("scope", this.Scope);
        }

        public static TokenResponse FromBytes(byte[] bytes)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(TokenResponse));
            TokenResponse responseData = (TokenResponse)ser.ReadObject(new MemoryStream(bytes));

            return responseData;
        }
    }
}
