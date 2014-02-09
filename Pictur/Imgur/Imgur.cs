using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Pictur
{
    public class Imgur
    {
        public TokenHandler Tokens { get; private set; }

        private static readonly string authPinUrl = "https://api.imgur.com/oauth2/authorize?client_id={0}&response_type=pin";
        private static readonly string registerUrl = String.Format(authPinUrl, Token.ClientID);

        public Imgur()
        {
            this.Tokens = new TokenHandler(this);

            if (this.Tokens.Current.Equals(Token.Empty))
            {
                RegisterForm form = new RegisterForm(this);
                form.ShowDialog();
            }
            else if (this.Tokens.Current.HasExpired)
            {
                this.Tokens.QueueRefresh();
            }
        }

        public void RegisterUser()
        {
            Process.Start(registerUrl);
        }

        public ImageDetails UploadImage(Image image)
        {
            string base64 = image.ToBase64();

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Authorization", "Bearer " + Tokens.Current.AccessToken);

                NameValueCollection data = new NameValueCollection();

                data["image"] = base64;
                data["type"] = "base64";

                byte[] bytes = client.UploadValues("https://api.imgur.com/3/image/", "POST", data);

                return DetailsResponse<ImageDetails>.FromBytes(bytes).Data;
            }
        }

        public void RefreshTokens(string pin)
        {
            this.Tokens.UpdateCredentials(ExchangePinForTokens(pin));

            this.Tokens.QueueRefresh();
        }

        public void RefreshTokens()
        {
            this.Tokens.UpdateCredentials(GetNewTokens());

            this.Tokens.QueueRefresh();
        }

        private TokenResponse ExchangePinForTokens(string pin)
        {
            using (WebClient client = new WebClient())
            {
                NameValueCollection data = new NameValueCollection();

                data["client_id"] = Token.ClientID;
                data["client_secret"] = Token.ClientSecret;
                data["grant_type"] = "pin";
                data["pin"] = pin;

                byte[] bytes = client.UploadValues("https://api.imgur.com/oauth2/token", "POST", data);

                return TokenResponse.FromBytes(bytes);
            }
        }

        private TokenResponse GetNewTokens()
        {
            using (WebClient client = new WebClient())
            {
                NameValueCollection data = new NameValueCollection();

                data["client_id"] = Token.ClientID;
                data["client_secret"] = Token.ClientSecret;
                data["refresh_token"] = Tokens.Current.RefreshToken;
                data["grant_type"] = "refresh_token";

                byte[] bytes = client.UploadValues("https://api.imgur.com/oauth2/token", "POST", data);

                return TokenResponse.FromBytes(bytes);
            }
        }
    }
}
