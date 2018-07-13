using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mumu.Frameworks.Entity;
using Mumu.Frameworks.DatabaseInterface;
using Mumu.Frameworks.Utility;
using System.Reflection;
using log4net;

namespace Mumu.Frameworks.LogicalOperation
{
    /// <summary>
    /// Description:应用程序数据提供者配置类
    /// Author:WUWEI
    /// Date:2018/07/08
    /// </summary>
    public class DataProvider
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #region 数据库连接数据提供对象
        private static IDbConn _dbConnDP;
        public static IDbConn DbConnDP
        {
            get
            {
                if (_dbConnDP == null)
                {
                    string dpname = "DbConnDP";
                    string dllname, assname;
                    if (!AppConfigManager.GetDataProvider(dpname, out dllname, out assname))
                    {
                        log.Error(string.Format("AppConfigManager数据提供对象字典中未能找到{0}配置信息！", dpname));
                    }
                    _dbConnDP = (IDbConn)Assembly.Load(assname).CreateInstance(dllname);
                }
                return _dbConnDP;
            }
        }
        #endregion

        #region 用户组数据提供对象
        private static IGroup _dbGroupDP;
        public static IGroup DbGroupDP
        {
            get
            {
                if (_dbGroupDP == null)
                {
                    string dpname = "DbGroupDP";
                    string dllname, assname;
                    if (!AppConfigManager.GetDataProvider(dpname, out dllname, out assname))
                    {
                        log.Error(string.Format("AppConfigManager数据提供对象字典中未能找到{0}配置信息！", dpname));
                    }
                    _dbGroupDP = (IGroup)Assembly.Load(assname).CreateInstance(dllname);
                }
                return _dbGroupDP;
            }
        }
        #endregion

        #region 权限数据提供对象
        private static IPermission _dbPermissionDP;
        public static IPermission DbPermissionDP
        {
            get
            {
                if (_dbPermissionDP == null)
                {
                    string dpname = "DbPermissionDP";
                    string dllname, assname;
                    if (!AppConfigManager.GetDataProvider(dpname, out dllname, out assname))
                    {
                        log.Error(string.Format("AppConfigManager数据提供对象字典中未能找到{0}配置信息！", dpname));
                    }
                    _dbPermissionDP = (IPermission)Assembly.Load(assname).CreateInstance(dllname);
                }
                return _dbPermissionDP;
            }
        }
        #endregion

    }
}
