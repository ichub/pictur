using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ImgurLib
{
    public static class Extensions
    {
        public static string ToBase64Png(this Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();

                return Convert.ToBase64String(imageBytes);
            }
        }

        public static string MembersToString<T>(T obj)
        {
            StringBuilder result = new StringBuilder();
            Type type = obj.GetType();

            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetField);

            foreach (PropertyInfo property in properties)
            {
                if (property.GetIndexParameters().Length == 0) // if not an indexer
                {
                    result.Append(property.Name);
                    result.Append(": ");
                    result.Append(property.GetValue(obj, null));
                    result.Append("\n");
                }
            }

            return result.ToString();
        }
    }
}
