using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Reflection;
using System.Net;
using System.IO;

namespace Mumu.Frameworks.Utility
{
    public class HttpHelper
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static string HttpGet(string url)
        {
            try
            {
                WebClient client = new WebClient();
                client.Credentials = CredentialCache.DefaultCredentials;
                byte[] data = client.DownloadData(url);
                string html = Encoding.UTF8.GetString(data);
                return html;
            }
            catch (Exception ex)
            {
                log.Error(string.Format("HttpGet:{0}", ex));
                return null;
            }
        }
        public static string HttpPost(string url, string postData)
        {
            Stream outStream = null;
            Stream inStream = null;
            StreamReader reader = null;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Encoding encoding = Encoding.UTF8;
            byte[] data = encoding.GetBytes(postData);
            try
            {
                request = WebRequest.Create(url) as HttpWebRequest;
                CookieContainer cookieContainer = new CookieContainer();
                request.CookieContainer = cookieContainer;
                request.AllowAutoRedirect = true;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                outStream = request.GetRequestStream();
                outStream.Write(data, 0, data.Length);
                outStream.Close();
                response = request.GetResponse() as HttpWebResponse;
                inStream = response.GetResponseStream();
                reader = new StreamReader(inStream, encoding);
                string result = reader.ReadToEnd();
                return result;
            }
            catch (Exception ex)
            {
                log.Error("HttpPost:{0}", ex);
                throw new Exception(ex.Message);
            }
        }
        public static int ConvertDateTimeToInt(DateTime time)
        {
            DateTime start = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return (int)(time - start).TotalSeconds;
        }
    }
}
