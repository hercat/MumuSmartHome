using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using log4net;
using System.Security.Cryptography;

namespace Mumu.Frameworks.Utility
{
    /// <summary>
    /// Description:加密算法帮助类
    /// Author:WUWEI
    /// Date:2017/07/09
    /// </summary>
    public class EncryptionHelper
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #region 单例模式
        private static EncryptionHelper _instance = null;
        private static object locker = new object();
        private EncryptionHelper() { }
        public static EncryptionHelper CreateInstance()
        {
            if (null == _instance)
            {
                lock (locker)
                {
                    if (null == _instance)
                        _instance = new EncryptionHelper();
                }
            }
            return _instance;
        }
        #endregion
        /// <summary>
        /// 将内容加密为32位十六进制哈希数组（不可逆）
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public string GetMD5Hash(string content)
        {
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
            byte[] data = provider.ComputeHash(Encoding.Default.GetBytes(content));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sb.Append(data[i].ToString("X2"));
            return sb.ToString();
        }
        /// <summary>
        /// MD5加密验证
        /// </summary>
        /// <param name="content"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public bool VerfierMD5Hash(string content, string hash)
        {
            string result = GetMD5Hash(content);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            if (0 == comparer.Compare(result, hash))
                return true;
            else
                return false;
        }
    }
}
