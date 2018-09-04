using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Mumu.Frameworks.Utility
{
    /// <summary>
    /// 文本消息
    /// <xml>  
    /// <ToUserName>< ![CDATA[toUser] ]></ToUserName>  
    /// <FromUserName>< ![CDATA[fromUser] ]></FromUserName>  
    /// <CreateTime>1348831860</CreateTime>  
    /// <MsgType>< ![CDATA[text] ]></MsgType>  
    /// <Content>< ![CDATA[this is a test] ]></Content>  
    /// <MsgId>1234567890123456</MsgId>  
    /// </xml>
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    public class TextMessage : BaseMessage
    {
        public TextMessage()
        {
            this.MsgType = ResponseMsgType.text.ToString().ToLower();
        }
        public TextMessage(BaseMessage info)
        {
            this.FromUserName = info.FromUserName;
            this.ToUserName = info.ToUserName;
        }
        /// <summary>
        /// 文本消息内容
        /// </summary>
        public string Content { get; set; }
    }
    /// <summary>
    /// 图片消息
    /// <xml> 
    /// <ToUserName>< ![CDATA[toUser] ]></ToUserName> 
    /// <FromUserName>< ![CDATA[fromUser] ]></FromUserName> 
    /// <CreateTime>1348831860</CreateTime> 
    /// <MsgType>< ![CDATA[image] ]></MsgType> 
    /// <PicUrl>< ![CDATA[this is a url] ]></PicUrl> 
    /// <MediaId>< ![CDATA[media_id] ]></MediaId> 
    /// <MsgId>1234567890123456</MsgId> 
    /// </xml>
    /// </summary>
    [XmlRoot(ElementName ="xml")]
    public class ImageMessage : BaseMessage
    {
        public ImageMessage()
        {
            this.MsgType = ResponseMsgType.image.ToString().ToLower();
        }
        public ImageMessage(BaseMessage info)
        {
            this.FromUserName = info.FromUserName;
            this.ToUserName = info.ToUserName;
        }
        /// <summary>
        /// 图片消息媒体id，可以调用多媒体文件下载接口拉取数据
        /// </summary>
        public string MediaId { get; set; }
        /// <summary>
        /// 图片链接（由系统生成）
        /// </summary>
        public string PicUrl { get; set; }
    }
    /// <summary>
    /// 语音消息
    /// <xml>
    /// <ToUserName>< ![CDATA[toUser] ]></ToUserName>
    /// <FromUserName>< ![CDATA[fromUser] ]></FromUserName>
    /// <CreateTime>1357290913</CreateTime>
    /// <MsgType>< ![CDATA[voice] ]></MsgType>
    /// <MediaId>< ![CDATA[media_id] ]></MediaId>
    /// <Format>< ![CDATA[Format] ]></Format>
    /// <Recognition>< ![CDATA[腾讯微信团队] ]></Recognition>
    /// <MsgId>1234567890123456</MsgId>
    /// </xml>
    /// </summary>
    [XmlRoot(ElementName ="xml")]
    public class VoiceMessage : BaseMessage
    {
        public VoiceMessage()
        {
            this.MsgType = ResponseMsgType.voice.ToString().ToLower();
        }
        public VoiceMessage(BaseMessage info)
        {
            this.FromUserName = info.FromUserName;
            this.ToUserName = info.ToUserName;
        }
        /// <summary>
        /// 语音消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId { get; set; }
        /// <summary>
        /// 语音格式，如amr，speex等
        /// </summary>
        public string Format { get; set; }
        /// <summary>
        /// 语音识别结果，UTF8编码
        /// </summary>
        public string Recognition { get; set; }
    }
    /// <summary>
    /// 视频消息
    /// <xml>
    /// <ToUserName>< ![CDATA[toUser] ]></ToUserName>
    /// <FromUserName>< ![CDATA[fromUser] ]></FromUserName>
    /// <CreateTime>1357290913</CreateTime>
    /// <MsgType>< ![CDATA[video] ]></MsgType>
    /// <MediaId>< ![CDATA[media_id] ]></MediaId>
    /// <ThumbMediaId>< ![CDATA[thumb_media_id] ]></ThumbMediaId>
    /// <MsgId>1234567890123456</MsgId>
    /// </xml>
    /// </summary>
    [XmlRoot(ElementName = ("xml"))]
    public class VideoMessage : BaseMessage
    {
        public VideoMessage()
        {
            this.MsgType = ResponseMsgType.video.ToString().ToLower();
        }
        public VideoMessage(BaseMessage info)
        {
            this.FromUserName = info.FromUserName;
            this.ToUserName = info.ToUserName;
        }
        /// <summary>
        /// 视频消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId { get; set; }
        /// <summary>
        /// 视频消息缩略图的媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string ThumbMediaId { get; set; }
    }
    /// <summary>
    /// 小视频信息
    /// <xml>
    /// <ToUserName>< ![CDATA[toUser] ]></ToUserName>
    /// <FromUserName>< ![CDATA[fromUser] ]></FromUserName>
    /// <CreateTime>1357290913</CreateTime>
    /// <MsgType>< ![CDATA[shortvideo] ]></MsgType>
    /// <MediaId>< ![CDATA[media_id] ]></MediaId>
    /// <ThumbMediaId>< ![CDATA[thumb_media_id] ]></ThumbMediaId>
    /// <MsgId>1234567890123456</MsgId>
    /// </xml>
    /// </summary>
    [XmlRoot(ElementName = ("xml"))]
    public class ShortVideoMessage : BaseMessage
    {
        public ShortVideoMessage()
        {
            this.MsgType = ResponseMsgType.shortvideo.ToString().ToLower();
        }
        public ShortVideoMessage(BaseMessage info)
        {
            this.FromUserName = info.FromUserName;
            this.ToUserName = info.ToUserName;
        }
        /// <summary>
        /// 视频消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId { get; set; }
        /// <summary>
        /// 视频消息缩略图的媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string ThumbMediaId { get; set; }
    }
    /// <summary>
    /// 地理位置信息
    /// <xml>
    /// <ToUserName>< ![CDATA[toUser] ]></ToUserName>
    /// <FromUserName>< ![CDATA[fromUser] ]></FromUserName>
    /// <CreateTime>1351776360</CreateTime>
    /// <MsgType>< ![CDATA[location] ]></MsgType>
    /// <Location_X>23.134521</Location_X>
    /// <Location_Y>113.358803</Location_Y>
    /// <Scale>20</Scale>
    /// <Label>< ![CDATA[位置信息] ]></Label>
    /// <MsgId>1234567890123456</MsgId>
    /// </xml>
    /// </summary>
    [XmlRoot(ElementName = ("xml"))]
    public class LocationMessage : BaseMessage
    {
        public LocationMessage()
        {
            this.MsgType = ResponseMsgType.location.ToString().ToLower();
        }
        public LocationMessage(BaseMessage info)
        {
            this.FromUserName = info.FromUserName;
            this.ToUserName = info.ToUserName;
        }
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
    }
    /// <summary>
    /// 链接消息
    /// <xml>
    /// <ToUserName>< ![CDATA[toUser] ]></ToUserName>
    /// <FromUserName>< ![CDATA[fromUser] ]></FromUserName>
    /// <CreateTime>1351776360</CreateTime>
    /// <MsgType>< ![CDATA[link] ]></MsgType>
    /// <Title>< ![CDATA[公众平台官网链接] ]></Title>
    /// <Description>< ![CDATA[公众平台官网链接] ]></Description>
    /// <Url>< ![CDATA[url] ]></Url>
    /// <MsgId>1234567890123456</MsgId>
    /// </xml>
    /// </summary>
    [XmlRoot(ElementName = ("xml"))]
    public class LinkMessage : BaseMessage
    {
        public LinkMessage()
        {
            this.MsgType = ResponseMsgType.link.ToString().ToLower();
        }
        public LinkMessage(BaseMessage info)
        {
            this.FromUserName = info.FromUserName;
            this.ToUserName = info.ToUserName;
        }
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
    }
}
