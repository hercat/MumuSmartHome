using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Mumu.Frameworks.Utility
{
    public class WeixinApiDispatch
    {
        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="token"></param>
        /// <param name="signature"></param>
        /// <param name="timestamp"></param>
        /// <param name="nonce"></param>
        /// <returns></returns>
        public bool CheckSignature(string token, string signature, string timestamp, string nonce)
        {
            string[] array = { token, timestamp, nonce };
            Array.Sort(array);
            string temp = string.Join("", array);
            temp = SHA1Signature(temp, Encoding.UTF8);
            temp = temp.ToLower();
            if (signature == temp)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 任务分配
        /// </summary>
        /// <param name="postData"></param>
        /// <returns></returns>
        public string Dispatch(string postData)
        {
            string responseContent = string.Empty;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(postData);
            XmlElement root = doc.DocumentElement;
            XmlNode nodeMsgType = root.SelectSingleNode("MsgType");
            
            return responseContent;
        }
        /// <summary>
        /// 生成SHA1验证签名
        /// </summary>
        /// <param name="content"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        private string SHA1Signature(string content, Encoding encode)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] bytes_in = encode.GetBytes(content);
            byte[] bytes_out = sha1.ComputeHash(bytes_in);
            sha1.Dispose();
            string result = BitConverter.ToString(bytes_out);
            result = result.Replace("-", "").ToLower();
            return result;
        }
    }
}
