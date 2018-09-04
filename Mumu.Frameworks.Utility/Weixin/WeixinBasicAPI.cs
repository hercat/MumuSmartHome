using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using log4net;
using System.Reflection;
using System.Web.Security;

namespace Mumu.Frameworks.Utility
{
    public class WeixinBasicAPI
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
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
        /// 生成SHA1验证签名
        /// </summary>
        /// <param name="content"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        private string SHA1Signature(string content, Encoding encode)
        {
            try
            {
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                byte[] bytes_in = encode.GetBytes(content);
                byte[] bytes_out = sha1.ComputeHash(bytes_in);
                sha1.Dispose();
                string result = BitConverter.ToString(bytes_out);
                result = result.Replace("-", "").ToUpper();
                return result;
            }
            catch (Exception ex)
            {
                log.Error(string.Format("SHA1Signature({0},{1})发生错误,错误信息如下:{0}", content, encode, ex));
                throw ex;
            }
        }
    }
}
