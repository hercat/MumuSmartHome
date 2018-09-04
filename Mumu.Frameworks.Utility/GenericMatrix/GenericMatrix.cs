using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;

namespace Mumu.Frameworks.Utility
{
    public class GenericMatrix
    {
        public static T Deserializer<T>(string str)
        {
            try
            {
                var stream = new MemoryStream(Encoding.UTF8.GetBytes(str));
                var serializer = new DataContractJsonSerializer(typeof(T));
                T obj = (T)serializer.ReadObject(stream);
                return obj;
            }
            catch (Exception ex)
            {
                return default(T);
                throw new Exception(ex.Message);
            }
        }

        public static string Serializer<T>(T obj)
        {
            try
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                var stream = new MemoryStream();
                serializer.WriteObject(stream, obj);
                byte[] data = new byte[stream.Length];
                stream.Position = 0;
                stream.Read(data, 0, (int)stream.Length);
                string result = Encoding.UTF8.GetString(data);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
