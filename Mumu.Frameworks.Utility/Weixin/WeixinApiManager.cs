using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumu.Frameworks.Utility
{
    public class WeixinApiManager
    {
        private string AppId;
        private string AppSecret;
        public WeixinApiManager(string id, string secret)
        {
            AppId = id;
            AppSecret = secret;
        }
        //public string GetAccessToken()
        //{
        //    string access_token = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", AppId, AppSecret);
        //}
    }
}
