using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mumu.Frameworks.Utility;

namespace Mumu.Frameworks.Utility
{
    public class WeixinConfig
    {
        private static string _WXURL;
        public static string WXURL
        {
            get
            {
                if (string.IsNullOrEmpty(_WXURL))
                    _WXURL = AppConfigManager.GetAppNodeValue("WeixinClientUrl");
                return _WXURL;
            }
        }

        private static string _WXTOKEN;
        public static string WXTOKEN
        {
            get
            {
                if (string.IsNullOrEmpty(_WXTOKEN))
                    _WXTOKEN = AppConfigManager.GetAppNodeValue("WeixinClientToken");
                return _WXTOKEN;
            }
        }

        private static string _WXAPPID;
        public static string WXAPPID
        {
            get
            {
                if (string.IsNullOrEmpty(_WXAPPID))
                    _WXAPPID = AppConfigManager.GetAppNodeValue("WeixinClientAppId");
                return _WXAPPID;
            }
        }

        private static string _WXAPPSECRET;
        public static string WXAPPSECRET
        {
            get
            {
                if (string.IsNullOrEmpty(_WXAPPSECRET))
                    _WXAPPSECRET = AppConfigManager.GetAppNodeValue("WeixinClientAppSecret");
                return _WXAPPSECRET;
            }
        }

        private static string _WXENCODINGAESKEY;
        public static string WXENCODINGAESKEY
        {
            get
            {
                if (string.IsNullOrEmpty(_WXENCODINGAESKEY))
                    _WXENCODINGAESKEY = AppConfigManager.GetAppNodeValue("WeixinClientEncodingAESKey");
                return _WXENCODINGAESKEY;
            }
        }
    }
}
