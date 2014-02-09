using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pictur
{
    public class TokenHandler
    {
        private Imgur imgur;
        private Token current;

        public Token Current
        {
            get { return current; }
            private set 
            {
                current = value;

                if (Program.Debugging)
                {
                    Debug.WriteLine("");
                    Debug.WriteLine("Access Token: " + current.AccessToken);
                    Debug.WriteLine("Refresh Token: " + current.RefreshToken);
                    Debug.WriteLine("Expires In: " + current.ExpiresOn);
                    Debug.WriteLine("Is Empty: " + current.IsEmpty);
                }
            }
        }


        private const string userFile = "user.bin";

        private static readonly string saveLocation;
        private static readonly string saveFileLocation;

        static TokenHandler()
        {
            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            saveLocation = Path.Combine(appdata, "Pictur");
            saveFileLocation = Path.Combine(saveLocation, userFile);
        }

        public TokenHandler(Imgur imgur)
        {
            this.imgur = imgur;

            if (!this.DeserializeCredentials())
            {
                this.Current = Token.Empty;
            }
        }

        public void QueueRefresh()
        {
            TimeSpan difference = this.Current.ExpiresOn - DateTime.Now;

            if (difference.TotalSeconds < 0)
            {
                difference = TimeSpan.Zero;
            }

            if (this.current.RefreshToken == String.Empty)
            {
                throw new Exception("cannot refresh with an invalid token");
            }

            Thread refreshThread = new Thread(() =>
                {
                    Timer timer = new Timer(state =>
                        {
                            lock (this)
                            {
                                this.imgur.RefreshTokens();
                            }
                        },
                        null,
                        difference,
                        difference);
                });

            refreshThread.Start();
        }

        public void UpdateCredentials(TokenResponse data)
        {
            this.Current = new Token(data.AccessToken, data.RefreshToken, data.ExpiresIn);
            this.SerializeCredentials();
        }

        private void SerializeCredentials()
        {
            if (!Directory.Exists(saveLocation))
            {
                Directory.CreateDirectory(saveLocation);
            }

            BinaryFormatter formatter = new BinaryFormatter();

            Stream stream = new FileStream(saveFileLocation, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this.Current);

            stream.Close();
        }

        private bool DeserializeCredentials()
        {
            if (Directory.Exists(saveLocation) && File.Exists(saveFileLocation))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                FileStream stream = new FileStream(saveFileLocation, FileMode.Open);

                try
                {
                    this.Current = (Token)formatter.Deserialize(stream);

                    stream.Close();

                    return true;
                }
                catch
                {
                    stream.Close();
                }

            }

            return false;
        }

    }
}
