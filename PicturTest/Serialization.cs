using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pictur;
using System.Text;

namespace PicturTest
{
    [TestClass]
    public class Serialization
    {
        [TestMethod]
        public void TokenResponseTest()
        {
            string testResponse = "{ \"access_token\": \"testAccessToken\", \"refresh_token\": \"testRefreshToken\",\"expires_in\": 3600,\"token_type\": \"testTokenType\",\"account_username\": \"testUsername\",\"scope\": \"testScope\"}";

            byte[] bytes = Encoding.ASCII.GetBytes(testResponse);
            TokenResponse response = TokenResponse.FromBytes(bytes);

            Assert.AreEqual(response.AccessToken, "testAccessToken");
            Assert.AreEqual(response.RefreshToken, "testRefreshToken");
            Assert.AreEqual(response.ExpiresIn, 3600);
            Assert.AreEqual(response.TokenType, "testTokenType");
            Assert.AreEqual(response.AccountUsername, "testUsername");
            Assert.AreEqual(response.Scope, "testScope");
        }

        [TestMethod]
        public void DetailsResponseTest()
        {
            string data = "{\"id\":\"SbBGk\",\"title\":null,\"description\":null,\"datetime\":1341533193,\"type\":\"image/jpeg\",\"animated\":false,\"width\":2559,\"height\":1439,\"size\":521916,\"views\":1,\"bandwidth\":521916,\"deletehash\":\"eYZd3NNJHsbreD1\",\"section\":null,\"link\":\"http://i.imgur.com/SbBGk.jpg\"}";
            string testResponse = "{\"data\":" + data + ",\"success\":true,\"status\":200}";

            byte[] bytes = Encoding.ASCII.GetBytes(testResponse);
            DetailsResponse<ImageDetails> response = DetailsResponse<ImageDetails>.FromBytes(bytes);

            Assert.AreEqual(response.Success, true);
            Assert.AreEqual(response.Status, 200);
            Assert.AreEqual(response.Data.Id, "SbBGk");
            Assert.AreEqual(response.Data.Title, null);
            Assert.AreEqual(response.Data.Description, null);
            Assert.AreEqual(response.Data.DateTime, 1341533193);
            Assert.AreEqual(response.Data.Type, "image/jpeg");
            Assert.AreEqual(response.Data.Animated, false);
            Assert.AreEqual(response.Data.Width, 2559);
            Assert.AreEqual(response.Data.Height, 1439);
            Assert.AreEqual(response.Data.Size, 521916);
            Assert.AreEqual(response.Data.Bandwidth, 521916);
            Assert.AreEqual(response.Data.Deletehash, "eYZd3NNJHsbreD1");
            Assert.AreEqual(response.Data.Section, null);
            Assert.AreEqual(response.Data.Link, "http://i.imgur.com/SbBGk.jpg");
        }
    }
}
