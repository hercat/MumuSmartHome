using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mumu.Frameworks.Utility;
using MumuHomeWechat;
using log4net.Config;
using System.IO;
using System.Text;

namespace MumuHomeWechat
{
    public partial class WeixinMenuInit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            log4netInit();
        }

        protected void btnWeixinMenu_Click(object sender, EventArgs e)
        {            
            WeixinApiManager manager = new WeixinApiManager(WeixinConfig.WXAPPID, WeixinConfig.WXAPPSECRET);
            manager.InitWeixinMenu(GetWeixinMenu());
        }
        private string GetWeixinMenu()
        {
            #region
            //string weixin1 = "";
            //weixin1 += "{\n";
            //weixin1 += "\"button\":[";
            //weixin1 += "{\n";
            //weixin1 += "\"type\":\"click\",\n";
            //weixin1 += "\"name\":\"报修\",\n";
            //weixin1 += "\"key\":\"201\"\n";
            //weixin1 += "},\n";
            //weixin1 += "{\n";
            //weixin1 += "\"type\":\"click\",\n";
            //weixin1 += "\"name\":\"扫一扫\",\n";
            //weixin1 += "\"key\":\"202\"\n";
            //weixin1 += "},\n";
            ////第三个菜单(view类型的)
            //weixin1 += "{\n";
            //weixin1 += "\"name\":\"我\",\n";
            //weixin1 += "\"sub_button\":[\n";
            ////子菜单一
            //weixin1 += "{\n";
            //weixin1 += "\"type\":\"click\",\n";
            //weixin1 += "\"name\":\"我的报修\",\n";
            //weixin1 += "\"key\":\"101\"\n";
            //weixin1 += "},\n";
            ////子菜单三
            //weixin1 += "{\n";
            //weixin1 += "\"type\":\"click\",\n";
            //weixin1 += "\"name\":\"我的信息\",\n";
            //weixin1 += "\"key\":\"103\"\n";
            //weixin1 += "}\n";
            //weixin1 += "]}\n";
            //weixin1 += "]}\n";
            //return weixin1;
            #endregion

            StringBuilder sb = new StringBuilder();
            sb.Append("{\n");
            sb.Append("\"button\":[\n");
            sb.Append("{\n");
            sb.Append("\"type\":\"click\",\n");
            sb.Append("\"name\":\"最新动态\",\n");
            sb.Append("\"key\":\"V101\"\n");
            sb.Append("},\n");
            sb.Append("{\n");
            sb.Append("\"name\":\"目录\",\n");
            sb.Append("\"sub_button\":[\n");
            sb.Append("{\n");
            sb.Append("\"type\":\"click\",\n");
            sb.Append("\"name\":\"2017事件汇总\",\n");
            sb.Append("\"key\":\"V201\"\n");
            sb.Append("},\n");
            sb.Append("{\n");
            sb.Append("\"type\":\"click\",\n");
            sb.Append("\"name\":\"2018事件汇总\",\n");
            sb.Append("\"key\":\"V202\"\n");
            sb.Append("}]\n");
            sb.Append("},\n");
            sb.Append("{\n");
            sb.Append("\"name\":\"我\",\n");
            sb.Append("\"sub_button\":[\n");
            sb.Append("{\n");
            sb.Append("\"type\":\"click\",\n");
            sb.Append("\"name\":\"我的动态\",\n");
            sb.Append("\"key\":\"V301\"\n");
            sb.Append("},\n");
            sb.Append("{\n");
            sb.Append("\"type\":\"click\",\n");
            sb.Append("\"name\":\"我的信息\",\n");
            sb.Append("\"key\":\"V303\"\n");
            sb.Append("}\n");
            sb.Append("]}\n");
            sb.Append("]}\n");
            return sb.ToString();
        }
        private void log4netInit()
        {
            string currentPath = AppDomain.CurrentDomain.BaseDirectory;
            string log4netConfig = string.Format("{0}\\log4net.xml", currentPath);
            XmlConfigurator.ConfigureAndWatch(new FileInfo(log4netConfig));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            WeixinApiManager manager = new WeixinApiManager(WeixinConfig.WXAPPID, WeixinConfig.WXAPPSECRET);
            string ip = manager.GetWeixinServerIP();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            WeixinApiManager manager = new WeixinApiManager(WeixinConfig.WXAPPID, WeixinConfig.WXAPPSECRET);
            string menu = manager.GetWeixinMenu();
        }
    }
}