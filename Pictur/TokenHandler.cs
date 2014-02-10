using ImgurLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pictur
{
    class TokenHandler
    {
        private const int updateDelay = 100; // time it takes to retrieve new tokens in miliseconds

        public Tokens CurrentTokens { get; set; }

        public TokenHandler()
        {
            this.CurrentTokens = Tokens.Empty;
        }

        public void UsePin(string pin)
        {
            this.CurrentTokens = Imgur.ExchangePinForTokens(pin, PicturApp.ClientID, PicturApp.ClientSecret);
        }

        public void StartRefreshLoop()
        {
            TimeSpan refreshIn = DateTime.Now.Subtract(this.CurrentTokens.ExpiresOn);

            if (refreshIn.TotalMilliseconds < updateDelay)
            {
                refreshIn = TimeSpan.Zero;
            }

            Timer timer = new Timer(a =>
            {
                lock (this)
                {
                    this.CurrentTokens = Imgur.RefreshTokens(CurrentTokens, PicturApp.ClientID, PicturApp.ClientSecret);
                    this.StartRefreshLoop();
                }
            },
            null,
            refreshIn,
            TimeSpan.Zero);
        }
    }
}
