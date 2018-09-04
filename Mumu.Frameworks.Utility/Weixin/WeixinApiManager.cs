using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using log4net;
using System.Web;

namespace Mumu.Frameworks.Utility
{
    public class WeixinApiManager
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private string AppId;
        private string AppSecret;
        public WeixinApiManager(string id, string secret)
        {
            AppId = id;
            AppSecret = secret;
        }
        /// <summary>
        /// 获取微信access_token
        /// </summary>
        /// <returns></returns>
        public string GetAccessToken()
        {
            string access_token_url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", AppId, AppSecret);
            WeixinBasicAPI basicwx = new WeixinBasicAPI(AppId, AppSecret, access_token_url);
            return basicwx.CheckAccessToken();
        }
        /// <summary>
        /// 初始化微信菜单
        /// </summary>
        /// <param name="menuContent"></param>
        /// <returns></returns>
        public string InitWeixinMenu(string menuContent)
        {            
            string access_tiken = GetAccessToken();
            string menu_url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}", access_tiken);
            string result = HttpHelper.HttpPost(menu_url, menuContent);
            return result;
        }
        /// <summary>
        /// 删除微信菜单
        /// </summary>
        /// <returns></returns>
        public string DeleteWeixinMenu()
        {
            string access_token = GetAccessToken();
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/delete?access_token={0}", access_token);
            string result = HttpHelper.HttpGet(url);
            return result;
        }
        /// <summary>
        /// 微信自定义菜单查询
        /// </summary>
        /// <returns></returns>
        public string GetWeixinMenu()
        {
            string access_token = GetAccessToken();
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}", access_token);
            string result = HttpHelper.HttpGet(url);
            return result;
        }

        
    }
}
