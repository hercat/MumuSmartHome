using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using log4net;
using log4net.Config;
using System.Reflection;
using System.IO;

namespace Mumu.Frameworks.Utility
{
    public class WeixinApiDispatch
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// 微信签名验证
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
            //SHA1加密
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
            string ToUserName = root.SelectSingleNode("ToUserName").InnerText;
            string FromUserName = root.SelectSingleNode("FromUserName").InnerText;
            string CreateTime = root.SelectSingleNode("CreateTime").InnerText;            
            string MsgType = nodeMsgType.InnerText.ToLower();
            log.Info("MsgType:" + MsgType);
            switch (MsgType)
            {
                case "text":
                    string Content = root.SelectSingleNode("Content").InnerText;
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("这里是WUWEI微信公众平台测试账号!\r\n");
                    sb.AppendFormat("你发送的文字内容为:{0}\r\n", Content);
                    sb.AppendFormat("你的OPENID:{0}\r\n", FromUserName);
                    //注意被动回复信息时ToUserName和FromUserName与接收时相反否则将回复信息失败！
                    responseContent = string.Format("<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>{2}</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[{3}]]></Content></xml>", FromUserName, ToUserName, HttpHelper.ConvertDateTimeToInt(DateTime.Now),sb.ToString()).Trim();
                    break;
                case "event":
                    string eventName = root.SelectSingleNode("Event").InnerText.ToLower();
                    log.Info("Event:" + eventName);
                    switch (eventName)
                    {
                        case "click":
                            string key = root.SelectSingleNode("EventKey").InnerText;
                            log.Info("click:" + key);
                            break;
                        case "subscribe":
                            log.Info("subscribe:" + FromUserName);
                            string str = "欢迎关注WUWEI测试微信公众号!";
                            responseContent = string.Format("<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>{2}</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[{3}]]></Content></xml>", FromUserName, ToUserName, HttpHelper.ConvertDateTimeToInt(DateTime.Now), str).Trim();
                            break;
                        case "unsubscribe":
                            log.Info(FromUserName + " unsubscribe:");
                            str = "取消关注";
                            //responseContent = string.Format("<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>{2}</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[{3}]]></Content></xml>", FromUserName, ToUserName, HttpHelper.ConvertDateTimeToInt(DateTime.Now), str).Trim();
                            break;
                    }
                    break;
            }
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
