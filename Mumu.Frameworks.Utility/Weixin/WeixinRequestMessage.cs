using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using log4net;
using System.Reflection;

namespace Mumu.Frameworks.Utility
{
    /// <summary>
    /// 微信请求文本消息
    /// </summary>
    public class RequestText : BaseMessage
    {
        /// <summary>
        /// 文本消息内容
        /// </summary>
        public string Content { get; set; }
        public RequestText Parse(string xml)
        {
            RequestText info = new RequestText();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlElement root = doc.DocumentElement;
            //消息类型
            string MsgType = root.SelectSingleNode("MsgType").InnerText.ToLower();
            //接收方帐号（收到的OpenID）
            string ToUserName = root.SelectSingleNode("ToUserName").InnerText;
            //开发者微信号
            string FromUserName = root.SelectSingleNode("FromUserName").InnerText;
            //消息创建时间 （整型）
            string CreateTime = root.SelectSingleNode("CreateTime").InnerText;
            //消息id，64位整型
            string msgId = root.SelectSingleNode("MsgId").InnerText;
            //文本消息内容
            string content = root.SelectSingleNode("Content").InnerText;
            info.FromUserName = FromUserName;
            info.ToUserName = ToUserName;
            info.MsgType = MsgType;
            info.Content = content;
            info.CreateTime = Convert.ToInt32(CreateTime);
            return info;
        }
    }
    /// <summary>
    /// 微信请求图片消息
    /// </summary>
    public class RequestImage : BaseMessage
    {
        /// <summary>
        /// 图片链接（由系统生成）
        /// </summary>
        public string PicUrl { get; set; }
        /// <summary>
        /// 图片消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId { get; set; }
        public RequestImage Parse(string xml)
        {
            RequestImage info = new RequestImage();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlElement root = doc.DocumentElement;
            string ToUserName = root.SelectSingleNode("ToUserName").InnerText;
            string FromUserName = root.SelectSingleNode("FromUserName").InnerText;
            string CreateTime = root.SelectSingleNode("CreateTime").InnerText;            
            string MsgType = root.SelectSingleNode("MsgType").InnerText;
            string PicUrl = root.SelectSingleNode("PicUrl").InnerText;
            string MediaId = root.SelectSingleNode("MediaId").InnerText;
            info.ToUserName = ToUserName;
            info.FromUserName = FromUserName;
            info.CreateTime = Convert.ToInt32(CreateTime);
            info.MsgType = MsgType;
            info.PicUrl = PicUrl;
            info.MediaId = MediaId;
            return info;
        }
    }
    /// <summary>
    /// 微信请求语音消息
    /// </summary>
    public class RequestVoice : BaseMessage
    {
        /// <summary>
        /// 语音消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId { get; set; }
        /// <summary>
        /// 语音格式，如amr，speex等
        /// </summary>
        public string Format { get; set; }
        public RequestVoice Parse(string xml)
        {
            RequestVoice info = new RequestVoice();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlElement root = doc.DocumentElement;
            string ToUserName = root.SelectSingleNode("ToUserName").InnerText;
            string FromUserName = root.SelectSingleNode("FromUserName").InnerText;
            string CreateTime = root.SelectSingleNode("CreateTime").InnerText;
            string MsgType = root.SelectSingleNode("MsgType").InnerText;
            string MediaId = root.SelectSingleNode("MediaId").InnerText;
            string Format = root.SelectSingleNode("Format").InnerText;
            info.ToUserName = ToUserName;
            info.FromUserName = FromUserName;
            info.CreateTime = Convert.ToInt32(CreateTime);
            info.MsgType = MsgType;
            info.MediaId = MediaId;
            info.Format = Format;
            return info;
        }
    }
    /// <summary>
    /// 微信请求视频消息
    /// </summary>
    public class RequestVideo : BaseMessage
    {
        /// <summary>
        /// 视频消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId { get; set; }
        /// <summary>
        /// 视频消息缩略图的媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string ThumbMediaId { get; set; }
        public RequestVideo Parse(string xml)
        {
            RequestVideo info = new RequestVideo();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlElement root = doc.DocumentElement;
            string ToUserName = root.SelectSingleNode("ToUserName").InnerText;
            string FromUserName = root.SelectSingleNode("FromUserName").InnerText;
            string CreateTime = root.SelectSingleNode("CreateTime").InnerText;
            string MsgType = root.SelectSingleNode("MsgType").InnerText;
            string MediaId = root.SelectSingleNode("MediaId").InnerText;
            string ThumbMediaId = root.SelectSingleNode("ThumbMediaId").InnerText;
            info.ToUserName = ToUserName;
            info.FromUserName = FromUserName;
            info.CreateTime = Convert.ToInt32(CreateTime);
            info.MsgType = MsgType;
            info.MediaId = MediaId;
            info.ThumbMediaId = ThumbMediaId;
            return info;
        }
    }
    /// <summary>
    /// 微信接收小视频消息
    /// </summary>
    public class RequestShortVideo : BaseMessage
    {
        /// <summary>
        /// 视频消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId { get; set; }
        /// <summary>
        /// 视频消息缩略图的媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string ThumbMediaId { get; set; }
        public RequestShortVideo Parse(string xml)
        {
            RequestShortVideo info = new RequestShortVideo();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlElement root = doc.DocumentElement;
            string ToUserName = root.SelectSingleNode("ToUserName").InnerText;
            string FromUserName = root.SelectSingleNode("FromUserName").InnerText;
            string CreateTime = root.SelectSingleNode("CreateTime").InnerText;
            string MsgType = root.SelectSingleNode("MsgType").InnerText;
            string MediaId = root.SelectSingleNode("MediaId").InnerText;
            string ThumbMediaId = root.SelectSingleNode("ThumbMediaId").InnerText;
            info.ToUserName = ToUserName;
            info.FromUserName = FromUserName;
            info.CreateTime = Convert.ToInt32(CreateTime);
            info.MsgType = MsgType;
            info.MediaId = MediaId;
            info.ThumbMediaId = ThumbMediaId;
            return info;
        }
    }
    /// <summary>
    /// 微信请求地理位置消息
    /// </summary>
    public class RequestLocation : BaseMessage
    {
        /// <summary>
        /// 地理位置维度
        /// </summary>
        public string Location_X { get; set; }
        /// <summary>
        /// 地理位置经度
        /// </summary>
        public string Location_Y { get; set; }
        /// <summary>
        /// 地图缩放大小
        /// </summary>
        public string Scale { get; set; }
        /// <summary>
        /// 地理位置信息
        /// </summary>
        public string Label { get; set; }
        public RequestLocation Parse(string xml)
        {
            RequestLocation info = new RequestLocation();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlElement root = doc.DocumentElement;
            string ToUserName = root.SelectSingleNode("ToUserName").InnerText;
            string FromUserName = root.SelectSingleNode("FromUserName").InnerText;
            string CreateTime = root.SelectSingleNode("CreateTime").InnerText;
            string MsgType = root.SelectSingleNode("MsgType").InnerText;
            string Location_X = root.SelectSingleNode("Location_X").InnerText;
            string Location_Y = root.SelectSingleNode("Location_Y").InnerText;
            string Scale = root.SelectSingleNode("Scale").InnerText;
            string Label = root.SelectSingleNode("Label").InnerText;
            info.ToUserName = ToUserName;
            info.FromUserName = FromUserName;
            info.CreateTime = Convert.ToInt32(CreateTime);
            info.MsgType = MsgType;
            info.Location_X = Location_X;
            info.Location_Y = Location_Y;
            info.Scale = Scale;
            info.Label = Label;
            return info;
        }
    }
    /// <summary>
    /// 微信请求链接消息
    /// </summary>
    public class RequestLink : BaseMessage
    {
        /// <summary>
        /// 消息标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 消息描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 消息链接
        /// </summary>
        public string Url { get; set; }
        public RequestLink Parse(string xml)
        {
            RequestLink info = new RequestLink();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlElement root = doc.DocumentElement;
            string ToUserName = root.SelectSingleNode("ToUserName").InnerText;
            string FromUserName = root.SelectSingleNode("FromUserName").InnerText;
            string CreateTime = root.SelectSingleNode("CreateTime").InnerText;
            string MsgType = root.SelectSingleNode("MsgType").InnerText;
            string Title = root.SelectSingleNode("Title").InnerText;
            string Description = root.SelectSingleNode("Description").InnerText;
            string Url = root.SelectSingleNode("Url").InnerText;
            info.ToUserName = ToUserName;
            info.FromUserName = FromUserName;
            info.CreateTime = Convert.ToInt32(CreateTime);
            info.MsgType = MsgType;
            info.Title = Title;
            info.Description = Description;
            info.Url = Url;
            return info;
        }
    }
}
