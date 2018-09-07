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
        /// <summary>
        /// 设置微信模板所属行业信息
        /// {"industry_id1":"1","industry_id2":"4"}
        /// </summary>
        /// <param name="industry"></param>
        public void SetTemplateIndustry(string industry)
        {
            string access_token = GetAccessToken();
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/template/api_set_industry?access_token={0}", access_token);
            HttpHelper.HttpPost(url, industry);
        }
        /// <summary>
        /// 获取微信模板所属行业信息
        /// </summary>
        /// <returns></returns>
        public string GetTemplateIndustry()
        {
            string access_token = GetAccessToken();
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/template/get_industry?access_token={0}", access_token);
            string result = HttpHelper.HttpGet(url);
            return result;
        }
        /// <summary>
        /// 获取微信模板ID        
        /// </summary>
        /// <param name="template_id_short">{"template_id_short":"TM00015"}</param>
        /// <returns></returns>
        public string GetTemplateId(string template_id_short)
        {
            string access_token = GetAccessToken();
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/template/api_add_template?access_token={0}", access_token);
            string result = HttpHelper.HttpPost(url, template_id_short);
            return result;
        }
        /// <summary>
        /// 获取微信模板列表
        /// </summary>
        /// <returns></returns>
        public string GetTemplateList()
        {
            string access_token = GetAccessToken();
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/template/get_all_private_template?access_token={0}", access_token);
            string result = HttpHelper.HttpGet(url);
            return result;
        }
        /// <summary>
        /// 删除微信模板
        /// </summary>
        /// <param name="template_id">{ "template_id" : "Dyvp3-Ff0cnail_CDSzk1fIc6-9lOkxsQE7exTJbwUE"}</param>
        /// <returns></returns>
        public string DeleteTemplate(string template_id)
        {
            string access_token = GetAccessToken();
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/template/del_private_template?access_token={0}", access_token);
            string result = HttpHelper.HttpPost(url, template_id);
            return result;
        }
        /// <summary>
        /// 发送微信模板消息
        /// </summary>
        /// <param name="postData"></param>
        /// <returns></returns>
        public string SendTemplateMessage(string postData)
        {
            string access_token = GetAccessToken();
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}", access_token);
            string result = HttpHelper.HttpPost(url, postData);
            return result;
        }
        /// <summary>
        /// 获取微信服务器IP地址
        /// </summary>
        /// <returns>{"ip_list": ["127.0.0.1","127.0.0.2","101.226.103.0/25"]}</returns>
        public string GetWeixinServerIP()
        {
            string access_token = GetAccessToken();
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/getcallbackip?access_token={0}", access_token);
            string result = HttpHelper.HttpGet(url);
            return result;
        }
        /// <summary>
        /// 客服账号添加
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public string AddCustomServiceAccount(string account)
        {
            string access_token = GetAccessToken();
            string url = string.Format("https://api.weixin.qq.com/customservice/kfaccount/add?access_token={0}", access_token);
            string result = HttpHelper.HttpPost(url, account);
            return result;
        }
        /// <summary>
        /// 客服账号信息修改
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public string ModifierCustomServiceAccount(string account)
        {
            string access_token = GetAccessToken();
            string url = string.Format("https://api.weixin.qq.com/customservice/kfaccount/update?access_token={0}", account);
            string result = HttpHelper.HttpPost(url, account);
            return result;
        }
        /// <summary>
        /// 客服账号信息删除
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns
        /// 
        ///>
        public string DeleteCustomServiceAccount(string account)
        {
            string access_token = GetAccessToken();
            string url = string.Format("https://api.weixin.qq.com/customservice/kfaccount/del?access_token={0}", access_token);
            string result = HttpHelper.HttpPost(url, account);
            return result;
        }
        /// <summary>
        /// 获取所有客服账号信息
        /// </summary>
        /// <returns></returns>
        public string GetAllCustomServiceAccount()
        {
            string access_token = GetAccessToken();
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/customservice/getkflist?access_token={0}", access_token);
            string result = HttpHelper.HttpGet(url);
            return result;
        }
    }
}
