﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Reflection;

namespace Mumu.Frameworks.Utility
{
    /// <summary>
    /// Description:应用配置管理帮助类
    /// Author:WUWEI
    /// Date:2018/07/08
    /// </summary>
    public class AppConfigManager
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static IDictionary<string, string> _dicDataProvider;
        public static IDictionary<string, string> DicDataProvider
        {
            get
            {
                if (_dicDataProvider == null || _dicDataProvider.Count == 0)
                {
                    _dicDataProvider = new Dictionary<string, string>();
                    _dicDataProvider.Add("DbConnDP", "Mumu.Frameworks.Dal.DbConnDal");
                }
                return _dicDataProvider;
            }
        }

        public static bool GetDataProvider(string dpname, out string dllname, out string assname)
        {
            dllname = DicDataProvider[dpname];
            assname = dllname.Substring(0, dllname.LastIndexOf("."));
            return true;
        }
    }
}