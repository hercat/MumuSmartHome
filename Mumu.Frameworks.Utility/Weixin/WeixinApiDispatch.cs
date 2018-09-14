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
using Mumu.Frameworks.Utility;

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
            string MsgType = nodeMsgType.InnerText.ToLower();
            switch (MsgType)
            {
                case "text":                   
                    try
                    {
                        RequestText reqText = new RequestText().Parse(postData);
                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat("消息类型:{0}\r\n", reqText.MsgType);
                        sb.AppendFormat("消息内容:{0}\r\n", reqText.Content);
                        WeixinTextMessage text = new WeixinTextMessage()
                        {
                            ToUserName = reqText.FromUserName,
                            FromUserName = reqText.ToUserName,
                            CreateTime = HttpHelper.ConvertDateTimeToInt(DateTime.Now),
                            MsgType = reqText.MsgType,
                            Content = sb.ToString()
                        };
                        responseContent = text.ToXml();
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }
                    break;
                case "image":
                    try
                    {
                        RequestImage reqImage = new RequestImage().Parse(postData);
                        WeixinImageMessage image = new WeixinImageMessage()
                        {
                            ToUserName = reqImage.FromUserName,
                            FromUserName = reqImage.ToUserName,
                            CreateTime = HttpHelper.ConvertDateTimeToInt(DateTime.Now),
                            MsgType = reqImage.MsgType,
                            MediaId = reqImage.MediaId
                        };
                        responseContent = image.ToXml();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "voice":
                    try
                    {
                        RequestVoice reqVoice = new RequestVoice().Parse(postData);
                        WeixinVoiceMessage voice = new WeixinVoiceMessage()
                        {
                            ToUserName = reqVoice.FromUserName,
                            FromUserName = reqVoice.ToUserName,
                            CreateTime = HttpHelper.ConvertDateTimeToInt(DateTime.Now),
                            MsgType = reqVoice.MsgType,
                            MediaId = reqVoice.MediaId
                        };
                        responseContent = voice.ToXml();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "video":
                    try
                    {
                        RequestVideo reqVideo = new RequestVideo().Parse(postData);
                        WeixinVideoMessage video = new WeixinVideoMessage()
                        {
                            ToUserName = reqVideo.FromUserName,
                            FromUserName = reqVideo.ToUserName,
                            CreateTime = HttpHelper.ConvertDateTimeToInt(DateTime.Now),
                            MsgType = reqVideo.MsgType,
                            MediaId = reqVideo.MediaId,
                            Title = reqVideo.MediaId,
                            Description = reqVideo.MediaId
                        };
                        responseContent = video.ToXml();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "shortvideo":
                    RequestShortVideo reqShortVideo = new RequestShortVideo().Parse(postData);
                    
                    break;
                case "location":
                    try
                    {
                        RequestLocation reqLoc = new RequestLocation().Parse(postData);
                        StringBuilder sb2 = new StringBuilder();
                        sb2.AppendFormat("消息类型:{0}\r\n", reqLoc.MsgType);
                        sb2.AppendFormat("纬度:{0}\r\n", reqLoc.Location_X);
                        sb2.AppendFormat("经度:{0}\r\n", reqLoc.Location_Y);
                        sb2.AppendFormat("地图缩放大小:{0}\r\n", reqLoc.Scale);
                        sb2.AppendFormat("地理位置信息:{0}\r\n", reqLoc.Label);
                        WeixinTextMessage location = new WeixinTextMessage()
                        {
                            ToUserName = reqLoc.FromUserName,
                            FromUserName = reqLoc.ToUserName,
                            CreateTime = HttpHelper.ConvertDateTimeToInt(DateTime.Now),
                            MsgType = "text",
                            Content = sb2.ToString()
                        };
                        responseContent = location.ToXml();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "link":
                    try
                    {
                        RequestLink reqlink = new RequestLink().Parse(postData);
                        StringBuilder sb3 = new StringBuilder();
                        sb3.AppendFormat("消息类型:{0}\r\n", reqlink.MsgType);
                        sb3.AppendFormat("消息标题:{0}\r\n", reqlink.Title);
                        sb3.AppendFormat("消息描述:{0}\r\n", reqlink.Description);
                        sb3.AppendFormat("Url:<a href=\"{0}\">链接</a>", reqlink.Url);
                        WeixinTextMessage link = new WeixinTextMessage()
                        {
                            ToUserName = reqlink.FromUserName,
                            FromUserName = reqlink.ToUserName,
                            CreateTime = HttpHelper.ConvertDateTimeToInt(DateTime.Now),
                            MsgType = "text",
                            Content = sb3.ToString()
                        };
                        responseContent = link.ToXml();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "event":
                    string eventName = root.SelectSingleNode("Event").InnerText.ToLower();
                    log.Info("Event:" + eventName);
                    switch (eventName)
                    {
                        case "click":
                            string key = root.SelectSingleNode("EventKey").InnerText;
                            log.Info("事件KEY值:" + key);
                            break;
                        case "subscribe":
                            log.Info(string.Format("FromUserName:{0}关注成功！", FromUserName));
                            string str = "欢迎关注WUWEI测试微信公众号!";
                            responseContent = string.Format("<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>{2}</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[{3}]]></Content></xml>", FromUserName, ToUserName, HttpHelper.ConvertDateTimeToInt(DateTime.Now), str).Trim();
                            break;
                        case "unsubscribe":
                            log.Info(string.Format("FromUserName:{0}取消关注！", FromUserName));                    
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
