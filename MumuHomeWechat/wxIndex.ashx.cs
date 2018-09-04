using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Configuration;
using log4net;
using System.Reflection;
using Mumu.Frameworks.Utility;

namespace MumuHomeWechat
{
    /// <summary>
    /// wxIndex 的摘要说明
    /// </summary>
    public class wxIndex : IHttpHandler
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public void ProcessRequest(HttpContext context)
        {
            //微信平台入口验证处理
            WechatEnterPointer(context);
        }
        /// <summary>
        /// 微信公众平台验证入口
        /// </summary>
        /// <param name="context"></param>
        private void WechatEnterPointer(HttpContext context)
        {
            string postString = string.Empty;
            //POST方式
            if (HttpContext.Current.Request.HttpMethod.ToUpper() == "POST")
            {
                using (Stream stream = HttpContext.Current.Request.InputStream)
                {
                    byte[] postBytes = new byte[stream.Length];
                    stream.Read(postBytes, 0, (Int32)stream.Length);
                    postString = Encoding.Default.GetString(postBytes);
                }
                //处理用户微信请求
                Execute(postString);
            }
            else
            {
                //微信接入验证
                WechatAuth();
            }
        }
        /// <summary>
        /// 处理请求
        /// </summary>
        private void Execute(string postString)
        {
            //string echostr = HttpContext.Current.Request["echostr"];
            //string signature = HttpContext.Current.Request["signature"];
            //string timestamp = HttpContext.Current.Request["timestamp"];
            //string nonce = HttpContext.Current.Request["nonce"];

            //string token = WeixinConfig.WXTOKEN;
            //string appid = WeixinConfig.WXAPPID;
            //string encodingAesKey = WeixinConfig.WXENCODINGAESKEY;

            string response = new WeixinApiDispatch().Dispatch(postString);
            HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;
            HttpContext.Current.Response.Write(response);
        }
        /// <summary>
        /// 服务器与微信服务器验证操作
        /// </summary>
        private void WechatAuth()
        {
            //配置文件中获取微信公众平台Token
            string token = WeixinConfig.WXTOKEN;
            if (string.IsNullOrEmpty(token))
                return;
            string echostr = HttpContext.Current.Request.QueryString["echostr"];        //随机字符串
            string signature = HttpContext.Current.Request.QueryString["signature"];    //微信加密签名
            string timestamp = HttpContext.Current.Request.QueryString["timestamp"];    //时间戳
            string nonce = HttpContext.Current.Request.QueryString["nonce"];            //随机数
            if (new WeixinApiDispatch().CheckSignature(token, signature, timestamp, nonce))
            {
                //微信验证成功后，返回给微信平台的随机字符串
                if (!string.IsNullOrEmpty(echostr))
                {
                    log.Info("WechatAuth:" + echostr);
                    HttpContext.Current.Response.Write(echostr);
                    HttpContext.Current.Response.End();
                }
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}