using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mumu.Frameworks.Utility
{   
    /// <summary>
    /// 微信消息基类
    /// </summary>
    public class BaseMessage
    {        
        /// <summary>
        /// 开发者微信号
        /// </summary>
        public string ToUserName { get; set; }
        /// <summary>
        /// 发送方帐号（一个OpenID）
        /// </summary>
        public string FromUserName { get; set; }
        /// <summary>
        /// 消息创建时间 （整型）
        /// </summary>
        public int CreateTime { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public string MsgType { get; set; }
    }
    /// <summary>
    /// 回复微信文本消息
    /// </summary>
    public class WeixinTextMessage : BaseMessage
    {
        public WeixinTextMessage()
        {
            MsgType = EnumWeixinMsgType.text.ToString().ToLower();
            CreateTime = HttpHelper.ConvertDateTimeToInt(DateTime.Now);
        }
        public WeixinTextMessage(BaseMessage info) : this()
        {
            this.FromUserName = info.FromUserName;
            this.ToUserName = info.ToUserName;
        }
        /// <summary>
        /// 文本消息内容
        /// </summary>
        public string Content { get; set; }
        public string ToXml()
        {
            string xml = string.Format("<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1]]></FromUserName><CreateTime>{2}</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[{3}]]></Content></xml>", FromUserName, ToUserName, CreateTime, Content);
            return xml;
        }
    }
    /// <summary>
    /// 回复微信图片消息
    /// </summary>
    public class WeixinImageMessage : BaseMessage
    {
        public WeixinImageMessage()
        {
            MsgType = EnumWeixinMsgType.image.ToString().ToLower();
            CreateTime = HttpHelper.ConvertDateTimeToInt(DateTime.Now);
        }
        public WeixinImageMessage(BaseMessage info) : this()
        {
            this.FromUserName = info.FromUserName;
            this.ToUserName = info.ToUserName;
        }
        /// <summary>
        /// 通过素材管理中的接口上传多媒体文件，得到的id。
        /// </summary>
        public string MediaId { get; set; }
        public string ToXml()
        {
            string xml = string.Format("<xml><ToUserName><![CDATA[toUser]]></ToUserName><FromUserName><![CDATA[fromUser] ]></FromUserName><CreateTime>12345678</CreateTime><MsgType>< ![CDATA[image] ]></MsgType><Image><MediaId>< ![CDATA[media_id]]></MediaId></Image></xml>");
            return xml;
        }
    }
    /// <summary>
    /// 回复微信语音信息    ·
    /// </summary>
    public class WeixinVoiceMessage : BaseMessage
    {
        public WeixinVoiceMessage()
        {
            MsgType = EnumWeixinMsgType.voice.ToString().ToLower();
            CreateTime = HttpHelper.ConvertDateTimeToInt(DateTime.Now);
        }
        public WeixinVoiceMessage(BaseMessage info) : this()
        {
            this.FromUserName = info.FromUserName;
            this.ToUserName = info.ToUserName;
        }
        /// <summary>
        /// 通过素材管理中的接口上传多媒体文件，得到的id
        /// </summary>
        public string MediaId { get; set; }
        public string ToXml()
        {
            string xml = string.Format("<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>{2}</CreateTime><MsgType><![CDATA[voice]]></MsgType><Voice><MediaId><![CDATA[{3}]]></MediaId></Voice></xml>", FromUserName, ToUserName, CreateTime, MediaId);
            return xml;
        }
    }
    /// <summary>
    /// 回复微信视频信息
    /// </summary>
    public class WeixinVideoMessage : BaseMessage
    {
        public WeixinVideoMessage()
        {
            MsgType = EnumWeixinMsgType.video.ToString().ToString();
            CreateTime = HttpHelper.ConvertDateTimeToInt(DateTime.Now);
        }
        public WeixinVideoMessage(BaseMessage info) : this()
        {
            this.FromUserName = info.FromUserName;
            this.ToUserName = info.ToUserName;
        }
        /// <summary>
        /// 通过素材管理中的接口上传多媒体文件，得到的id
        /// </summary>
        public string MediaId { get; set; }
        /// <summary>
        /// 视频消息的标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 视频消息的描述
        /// </summary>
        public string Description { get; set; }
        public string ToXml()
        {
            string xml = string.Format("<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>{2}</CreateTime><MsgType><![CDATA[video]]></MsgType><Video><MediaId><![CDATA[{3}]]></MediaId><Title><![CDATA[{4}]]></Title><Description><![CDATA[{5}]]></Description></Video></xml>", FromUserName, ToUserName, CreateTime, MediaId, Title, Description);
            return xml;
        }
    }
    /// <summary>
    /// 回复微信音乐消息
    /// </summary>

    public class WeixinMusicMessage : BaseMessage
    {
        public WeixinMusicMessage()
        {
            MsgType = EnumWeixinMsgType.music.ToString().ToLower();
            CreateTime = HttpHelper.ConvertDateTimeToInt(DateTime.Now);
        }
        public WeixinMusicMessage(BaseMessage info) : this()
        {
            this.FromUserName = info.FromUserName;
            this.ToUserName = info.ToUserName;
        }
        /// <summary>
        /// 音乐标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 音乐描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 音乐链接
        /// </summary>
        public string MusicURL { get; set; }
        /// <summary>
        /// 高质量音乐链接，WIFI环境优先使用该链接播放音乐
        /// </summary>
        public string HQMusicUrl { get; set; }
        /// <summary>
        /// 缩略图的媒体id，通过素材管理中的接口上传多媒体文件，得到的id
        /// </summary>
        public string ThumbMediaId { get; set; }
        public string ToXml()
        {
            string xml = string.Format("<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>{2}</CreateTime><MsgType><![CDATA[music]]></MsgType><Music><Title><![CDATA[{3}]]></Title><Description><![CDATA[{4}]]></Description><MusicUrl><![CDATA[{5}]]></MusicUrl><HQMusicUrl><![CDATA[{6}]]></HQMusicUrl><ThumbMediaId><![CDATA[{7}]]></ThumbMediaId></Music></xml>", FromUserName, ToUserName, CreateTime, Title, Description, MusicURL, HQMusicUrl, ThumbMediaId);
            return xml;
        }
    }
    /// <summary>
    /// 回复微信图文消息
    /// </summary>
    public class WeixinNewsMessage : BaseMessage
    {
        public WeixinNewsMessage()
        {
            MsgType = EnumWeixinMsgType.news.ToString().ToLower();
            CreateTime = HttpHelper.ConvertDateTimeToInt(DateTime.Now);
        }
        public WeixinNewsMessage(BaseMessage info) : this()
        {
            this.FromUserName = info.FromUserName;
            this.ToUserName = info.ToUserName;
        }
        /// <summary>
        /// 图文消息个数，限制为8条以内
        /// </summary>
        public int ArticleCount { get; set; }
        /// <summary>
        /// 多条图文消息信息，默认第一个item为大图,注意，如果图文数超过8，则将会无响应
        /// </summary>
        public NewsItem Articles { get; set; }
        /// <summary>
        /// 图文消息列表
        /// </summary>
        public List<NewsItem> NewsItems { get; set; }
        public string ToXml()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>{2}</CreateTime><MsgType><![CDATA[news]]></MsgType><ArticleCount>{3}</ArticleCount>", FromUserName, ToUserName, CreateTime, NewsItems.Count);
            sb.Append("<Articles>");
            foreach (NewsItem item in NewsItems)
            {
                sb.AppendFormat("<item><Title><![CDATA[{0}]]></Title><Description><![CDATA[{1}]]></Description><PicUrl><![CDATA[{2}]]></PicUrl><Url><![CDATA[{3}]]></Url></item>", item.Title, item.Description, item.PicUrl, item.Url);
            }
            sb.Append("</Articles></xml>");
            return sb.ToString();
        }
    }
    public class NewsItem
    {
        /// <summary>
        /// 图文消息标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 图文消息描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 图片链接，支持JPG、PNG格式，较好的效果为大图360*200，小图200*200
        /// </summary>
        public string PicUrl { get; set; }
        /// <summary>
        /// 点击图文消息跳转链接
        /// </summary>
        public string Url { get; set; }
    }   
    enum EnumWeixinMsgType
    {
        text,   //文本消息
        image,  //图片信息
        voice,  //语音消息
        video,  //视频信息
        music,  //音乐信息
        news    //图文信息
    }
}
