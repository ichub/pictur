using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgurLib
{
    public struct Tokens
    {
        public static Tokens Empty { get { return new Tokens(); } }

        public DateTime ExpiresOn { get; private set; }

        public string AccessToken { get; private set; }
        public string RefreshToken { get; private set; }

        public bool IsExpired
        {
            get
            {
                return DateTime.Now.CompareTo(this.ExpiresOn) >= 0;
            }
        }

        public Tokens(string accessToken, string refreshToken, int expiresIn)
            : this()
        {
            this.AccessToken = accessToken;
            this.RefreshToken = refreshToken;

            this.ExpiresOn = DateTime.Now.AddSeconds(expiresIn);
        }

        public override string ToString()
        {
            return Extensions.MembersToString(this);
        }
    }
}
