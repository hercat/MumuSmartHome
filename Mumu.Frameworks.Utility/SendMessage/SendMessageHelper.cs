using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using log4net;
using System.Net;
using System.Web;
using System.IO;

namespace Mumu.Frameworks.Utility
{
    public class SendMessageHelper
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #region 单例模式
        private static SendMessageHelper _instance = null;
        private static object locker = new object();
        private SendMessageHelper() { }
        public SendMessageHelper CreateInstance()
        {
            if (null == _instance)
            {
                lock (locker)
                {
                    if(null==_instance)
                    {
                        _instance = new SendMessageHelper();
                    }
                }
            }
            return _instance;
        }
        #endregion

        public string SendMessage(string postUrl, string userId, string userPwd, string name, string mobile, string content, int timeout)
        {
            string returnCode = string.Empty;
            try
            {
                string postStr = "smContent={0}&&mobiles={1}&&userId={2}&userPwd={3}&endSendTime={4}";
                UTF8Encoding encoding = new UTF8Encoding();
                string datetime = DateTime.Now.AddMinutes(timeout).ToString("yyyy-MM-dd HH:mm:ss");
                byte[] postdata = encoding.GetBytes(string.Format(postStr, content, mobile, userId, userPwd, datetime));
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(postUrl);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                request.ContentLength = postdata.Length;
                Stream stream = request.GetRequestStream();
                stream.Write(postdata, 0, postdata.Length);
                stream.Flush();
                stream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("GB2312"));
                    returnCode = reader.ReadToEnd();
                    log.Info(string.Format("发送给【{0}】,手机号:{1},短信内容为:{2},返回信息为:{3}", name, mobile, content, returnCode));
                }
            }
            catch (Exception ex)
            {
                log.Error(string.Format("短信发送失败！SendMessage({0},{1},{2},{3},{4},{5},{6}),异常信息如下:{6}", postUrl, userId, userPwd, name, mobile, content, timeout, ex));
            }
            return returnCode;
        }
    }
}
