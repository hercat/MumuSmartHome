using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using log4net;
using System.Reflection;
using System.Xml.Serialization;

namespace Mumu.Frameworks.Utility
{
    public class WeixinMessageParse
    {
        /// <summary>
        /// 微信发送消息解析
        /// </summary>
        /// <param name="recvXml"></param>
        /// <returns></returns>
        public static BaseMessage WeixinRecvMessageParse(string recvXml)
        {
            BaseMessage info = new BaseMessage();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(recvXml);
            XmlElement root = doc.DocumentElement;
            //解析消息类型
            string MsgType = root.SelectSingleNode("MsgType").InnerText.ToLower();
            //解析接收方帐号（收到的OpenID）
            string ToUserName = root.SelectSingleNode("ToUserName").InnerText;
            //解析开发者微信号
            string FromUserName = root.SelectSingleNode("FromUserName").InnerText;
            string CreateTime = root.SelectSingleNode("CreateTime").InnerText;
            info.FromUserName = FromUserName;
            info.ToUserName = ToUserName;
            info.MsgType = MsgType;
            info.CreateTime = Convert.ToInt32(CreateTime);
            return info;
        }        
    }
}
