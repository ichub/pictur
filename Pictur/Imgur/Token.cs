using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Pictur
{
    [Serializable()]
    public class Token
    {
        public const string ClientID = "d2dc505559c21ed";
        public const string ClientSecret = "bcbf4fd7a4c4692e421f050996ce24b0328e30d2";

        public static Token Empty { get { return new Token(null, null, -1); } }

        public DateTime ExpiresOn { get; private set; }

        public string AccessToken { get; private set; }
        public string RefreshToken { get; private set; }

        public bool HasExpired
        {
            get
            {
                return DateTime.Now.CompareTo(this.ExpiresOn) >= 0;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return this.Equals(Token.Empty);
            }
        }

        public Token(string accessToken, string refreshToken, int expiresIn)
        {
            if (expiresIn == -1)
            {
                this.ExpiresOn = DateTime.MinValue;
            }
            else
            {
                this.ExpiresOn = DateTime.Now.Add(TimeSpan.FromSeconds(expiresIn));
            }

            this.AccessToken = accessToken;
            this.RefreshToken = refreshToken;
        }

        public Token(SerializationInfo info, StreamingContext ctxt)
        {
            this.ExpiresOn = info.GetDateTime("Expires");
            this.AccessToken = info.GetString("AccessToken");
            this.RefreshToken = info.GetString("RefreshToken");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Expires", this.ExpiresOn);
            info.AddValue("AccessToken", this.AccessToken);
            info.AddValue("RefreshToken", this.RefreshToken);
        }

        public bool Equals(Token obj)
        {
            return obj.AccessToken == this.AccessToken && obj.RefreshToken == this.RefreshToken && obj.ExpiresOn == this.ExpiresOn;
        }
    }
}
