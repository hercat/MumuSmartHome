using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using log4net;
using System.Reflection;
using System.Web.Security;
using System.Web;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace Mumu.Frameworks.Utility
{
    public class WeixinBasicAPI
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private string Id;
        private string Secret;
        private string Access_Token;    //access_token文件名
        private string Access_tokenUrl;

        public WeixinBasicAPI(string id, string secret, string atUrl)
        {
            this.Id = id;
            this.Secret = secret;
            this.Access_Token = "AT" + id;
            this.Access_tokenUrl = atUrl;
        }
        /// <summary>
        /// 获取并存储微信access_token到服务器
        /// </summary>
        /// <returns></returns>
        public string CheckAccessToken()
        {
            try
            {
                string access_token = string.Empty;
                string path = HttpContext.Current.Server.MapPath(@"/Weixin/") + Access_Token;
                if (!Directory.Exists(HttpContext.Current.Server.MapPath(@"/Weixin")))
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(@"/Weixin"));
                if (!Directory.Exists(path))
                {
                    AccessToken at = GenericMatrix.Deserializer<AccessToken>(HttpHelper.HttpGet(Access_tokenUrl));
                    access_token = at.access_token;
                    if (!string.IsNullOrEmpty(access_token))
                    {
                        //获取access_token后设置expire_time超时时间
                        at.expire_time = HttpHelper.ConvertDateTimeToInt(DateTime.Now) + 7000;
                        at.access_token = access_token;
                        string json = GenericMatrix.Serializer<AccessToken>(at);
                        StreamWriterMethod(json, path);
                    }                    
                }
                else
                {
                    FileStream fs = new FileStream(path, FileMode.Open);
                    var serializer = new DataContractJsonSerializer(typeof(AccessToken));
                    AccessToken readAT = (AccessToken)serializer.ReadObject(fs);
                    fs.Close();
                    //如果服务器当前access_token的expire_time小于当前时间则再次获取并更新access_token信息
                    if (readAT.expire_time < HttpHelper.ConvertDateTimeToInt(DateTime.Now))
                    {
                        AccessToken at = GenericMatrix.Deserializer<AccessToken>(HttpHelper.HttpGet(Access_tokenUrl));
                        access_token = at.access_token;
                        if (!string.IsNullOrEmpty(access_token))
                        {
                            at.expire_time = HttpHelper.ConvertDateTimeToInt(DateTime.Now) + 7000;
                            at.access_token = access_token;
                            string json = GenericMatrix.Serializer<AccessToken>(at);
                            StreamWriterMethod(json, path);
                        }
                    }
                }
                log.Info("CheckAccessToken:" + access_token);
                return access_token;
            }
            catch (Exception ex)
            {
                log.Error(string.Format("CheckAccessToken Error:{0}", ex));
                return string.Empty;
            }
        }
        /// <summary>
        /// 写入access_token方法
        /// </summary>
        /// <param name="str"></param>
        /// <param name="path"></param>
        private void StreamWriterMethod(string str, string path)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(str);
                sw.Close();
            }
            catch (Exception ex)
            {
                log.Error(string.Format("StreamWriterMethod Error:{0}", ex));
            }
        }
    }
    /// <summary>
    /// 创建Json类，保存文件access_token.json
    /// </summary>
    [DataContract]
    public class AccessToken
    {
        [DataMember(Order = 0)]
        public string access_token { get; set; }
        [DataMember(Order = 1)]
        public long expire_time { get; set; }
    }
    /// <summary>
    /// 微信公众平台错误信息json类
    /// </summary>
    [DataContract]
    public class ErrorMsg
    {
        [DataMember(Order = 0)]
        public string errcode { get; set; }
        [DataMember(Order = 1)]
        public string errmsg { get; set; }
    }
    /// <summary>
    /// 语言枚举
    /// </summary>
    public enum Language
    {
        /// <summary>
        /// 简体中文
        /// </summary>
        zh_CN,
        /// <summary>
        /// 繁体中文
        /// </summary>
        zh_TW,
        /// <summary>
        /// 英文
        /// </summary>
        en
    }
}
