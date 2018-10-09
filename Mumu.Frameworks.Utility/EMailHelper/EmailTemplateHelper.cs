using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Reflection;
using log4net;

namespace Mumu.Frameworks.Utility
{
    /// <summary>
    /// Description:
    /// Author:WUWEI
    /// Date:2018/09/30
    /// </summary>
    public class EmailTemplateHelper
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static string GetTemplateFromFile(string templatePath, NameValueCollection values, string startPrefix, string endPrefix)
        {
            StreamReader reader = null;
            string template = string.Empty;
            try
            {
                reader = new StreamReader(templatePath);
                template = reader.ReadToEnd();
                reader.Close();
                if (null != values)
                {
                    foreach (string key in values.AllKeys)
                    {
                        template = template.Replace(string.Format("{0}{1}{2}", startPrefix, key, endPrefix), values[key].ToString());
                    } 
                }
            }
            catch (Exception ex)
            {
                log.Error(string.Format("GetTemplateFromFile()发生错误,错误信息如下:{0}", ex));
            }
            finally
            {
                if (null != reader)
                    reader.Close();
            }
            return template;
        }
        /// <summary>
        /// 构造模板信息
        /// </summary>
        /// <param name="templatePath"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string ConstructTemplate(string templatePath, NameValueCollection values)
        {
            return GetTemplateFromFile(templatePath, values, "[$", "]");
        }
    }
}
