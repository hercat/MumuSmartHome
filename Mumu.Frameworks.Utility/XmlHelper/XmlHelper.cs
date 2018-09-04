using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using log4net;
using System.Reflection;
using System.IO;
using System.Xml.Serialization;

namespace Mumu.Frameworks.Utility
{
    public class XmlHelper
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// 微信消息对象序列化为Xml
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string WeixinSerializer(object obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializer xml = new XmlSerializer(obj.GetType());
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add(string.Empty, string.Empty);//去除命名空间
                xml.Serialize(stream, obj, ns);
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream))
                {
                    string str = reader.ReadToEnd();
                    int start = str.IndexOf("?>\r\n");
                    str = str.Substring(start + 4, str.Length - start - 4);
                    return str;
                }
            }
        }        
        /// <summary>
        /// 对象序列化为Xml（泛型）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Serializer<T>(T obj) where T : class
        {
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                serializer.Serialize(stream, obj, ns);
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream))
                {
                    string xml = reader.ReadToEnd();
                    return xml;
                }
            }
        }
        /// <summary>
        /// xml反序列化为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string xml) where T : class
        {
            using (StringReader reader = new StringReader(xml))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                var obj = serializer.Deserialize(reader);
                if (obj is T)
                    return (T)obj;
                return default(T);
            }
        }
    }
}
