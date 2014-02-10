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
    internal class DetailsResponse<T>
    {
        [DataMember(Name = "data")]
        public T Data { get; private set; }

        [DataMember(Name = "success")]
        public bool Success { get; private set; }

        [DataMember(Name = "status")]
        public int Status { get; private set; }

        public static DetailsResponse<T> FromBytes(byte[] bytes)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(DetailsResponse<T>));
            DetailsResponse<T> responseData = (DetailsResponse<T>)ser.ReadObject(new MemoryStream(bytes));

            return responseData;
        }
    }
}
