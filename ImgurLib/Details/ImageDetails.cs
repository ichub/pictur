using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ImgurLib
{
    [DataContract]
    public class ImageDetails
    {
        [DataMember(Name = "id")]
        public string Id { get; private set; }

        [DataMember(Name = "title")]
        public string Title { get; private set; }

        [DataMember(Name = "description")]
        public string Description { get; private set; }

        [DataMember(Name = "datetime")]
        public int DateTime { get; private set; }

        [DataMember(Name = "type")]
        public string Type { get; private set; }

        [DataMember(Name = "animated")]
        public bool Animated { get; private set; }

        [DataMember(Name = "width")]
        public int Width { get; private set; }

        [DataMember(Name = "height")]
        public int Height { get; private set; }

        [DataMember(Name = "size")]
        public int Size { get; private set; }

        [DataMember(Name = "views")]
        public int Views { get; private set; }

        [DataMember(Name = "bandwidth")]
        public int Bandwidth { get; private set; }

        [DataMember(Name = "deletehash")]
        public string Deletehash { get; private set; }

        [DataMember(Name = "section")]
        public string Section { get; private set; }

        [DataMember(Name = "link")]
        public string Link { get; private set; }

        public override string ToString()
        {
            return Extensions.MembersToString(this);
        }
    }
}
