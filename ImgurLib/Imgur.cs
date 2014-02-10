using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ImgurLib
{
    public static class Imgur
    {
        public static ImageDetails UploadImage(Tokens tokens, Image image)
        {
            string base64 = image.ToBase64Png();

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Authorization", "Bearer " + tokens.AccessToken);

                NameValueCollection data = new NameValueCollection();

                data["image"] = base64;
                data["type"] = "base64";

                byte[] bytes = client.UploadValues("https://api.imgur.com/3/image/", "POST", data);

                return DetailsResponse<ImageDetails>.FromBytes(bytes).Data;
            }
        }

        public static Tokens ExchangePinForTokens(string pin, string clientID, string clientSecret)
        {
            using (WebClient client = new WebClient())
            {
                NameValueCollection data = new NameValueCollection();

                data["client_id"] = clientID;
                data["client_secret"] = clientSecret;
                data["grant_type"] = "pin";
                data["pin"] = pin;

                byte[] bytes = client.UploadValues("https://api.imgur.com/oauth2/token", "POST", data);

                TokenResponse response = TokenResponse.FromBytes(bytes);

                return new Tokens(response.AccessToken, response.RefreshToken, response.ExpiresIn);
            }
        }

        public static Tokens RefreshTokens(Tokens tokens, string clientID, string clientSecret)
        {
            using (WebClient client = new WebClient())
            {
                NameValueCollection data = new NameValueCollection();

                data["client_id"] = clientID;
                data["client_secret"] = clientSecret;
                data["refresh_token"] = tokens.RefreshToken;
                data["grant_type"] = "refresh_token";

                byte[] bytes = client.UploadValues("https://api.imgur.com/oauth2/token", "POST", data);

                TokenResponse response = TokenResponse.FromBytes(bytes);

                return new Tokens(response.AccessToken, response.RefreshToken, response.ExpiresIn);
            }
        }
    }
}
