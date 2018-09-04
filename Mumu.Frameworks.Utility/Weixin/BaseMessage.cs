using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WHC.OrderWater.Commons;

namespace Mumu.Frameworks.Utility
{
    [XmlRoot(ElementName="xml")]
    public class BaseMessage
    {
        /// <summary>
        /// 接受者微信号
        /// </summary>
        public string ToUserName { get; set; }
        /// <summary>
        /// 发送者微信号
        /// </summary>
        public string FromUserName { get; set; }
        /// <summary>
        /// 消息创建时间（整型）
        /// </summary>
        public long CreateTime { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public string MsgType { get; set; }
        /// <summary>
        /// 消息id，64位整型
        /// </summary>
        public long MsgId { get; set; }
        public BaseMessage()
        {
            this.CreateTime = DateTime.Now.ToFileTimeUtc();
        }
        public virtual string ToXml()
        {
            this.CreateTime = DateTime.Now.ToFileTimeUtc();
            return XmlHelper.WeixinSerializer(this);
        }
    }
    public enum ResponseMsgType
    {
        text,//文本消息
        image,//图片消息
        voice,//语音消息
        video,//视频消息
        shortvideo,//小视频消息
        location,//地理位置消息
        link,//连接消息
    }
}
