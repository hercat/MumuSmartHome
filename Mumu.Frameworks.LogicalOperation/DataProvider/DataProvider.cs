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

        #region 角色数据提供对象
        private static IRole _dbRoleDP;
        public static IRole DbRoleDP
        {
            get
            {
                if (_dbRoleDP == null)
                {
                    string dpname = "DbRoleDP";
                    string dllname, assname;
                    if (!AppConfigManager.GetDataProvider(dpname, out dllname, out assname))
                    {
                        log.Error(string.Format("AppConfigManager数据提供对象字典中未能找到{0}配置信息！", dpname));
                    }
                    _dbRoleDP = (IRole)Assembly.Load(assname).CreateInstance(dllname);
                }
                return _dbRoleDP;
            }
        }
        #endregion

        #region 用户登录数据提供对象
        private static IUserLogin _dbUserLoginDP;
        public static IUserLogin DbUserLoginDP
        {
            get
            {
                if (_dbUserLoginDP == null)
                {
                    string dpname = "DbUserLoginDP";
                    string dllname, assname;
                    if (!AppConfigManager.GetDataProvider(dpname, out dllname, out assname))
                    {
                        log.Error(string.Format("AppConfigManager数据提供对象字典中未能找到{0}配置信息！", dpname));
                    }
                    _dbUserLoginDP = (IUserLogin)Assembly.Load(assname).CreateInstance(dllname);
                }
                return _dbUserLoginDP;
            }
        }
        #endregion

        #region 用户组权限数据提供对象
        private static IGroupPermission _dbGroupPermissionDP;
        public static IGroupPermission DbGroupPermissionDP
        {
            get
            {
                if (_dbGroupPermissionDP == null)
                {
                    string dpname = "DbGroupPermissionDP";
                    string dllname, assname;
                    if (!AppConfigManager.GetDataProvider(dpname, out dllname, out assname))
                    {
                        log.Error(string.Format("AppConfigManager数据提供对象字典中未能找到{0}配置信息！", dpname));
                    }
                    _dbGroupPermissionDP = (IGroupPermission)Assembly.Load(assname).CreateInstance(dllname);
                }
                return _dbGroupPermissionDP;
            }
        }
        #endregion

        #region 角色权限数据提供对象
        private static IRolePermission _dbRolePermissionDP;
        public static IRolePermission DbRolePermissionDP
        {
            get
            {
                if (_dbRolePermissionDP == null)
                {
                    string dpname = "DbRolePermissionDP";
                    string dllname, assname;
                    if (!AppConfigManager.GetDataProvider(dpname, out dllname, out assname))
                    {
                        log.Error(string.Format("AppConfigManager数据提供对象字典中未能找到{0}配置信息！", dpname));
                    }
                    _dbRolePermissionDP = (IRolePermission)Assembly.Load(assname).CreateInstance(dllname);
                }
                return _dbRolePermissionDP;
            }
        }
        #endregion

        #region 用户分组数据提供对象
        private static IUserGroup _dbUserGroupDP;
        public static IUserGroup DbUserGroupDP
        {
            get
            {
                if (_dbUserGroupDP == null)
                {
                    string dpname = "DbUserGroupDP";
                    string dllname, assname;
                    if (!AppConfigManager.GetDataProvider(dpname, out dllname, out assname))
                    {
                        log.Error(string.Format("AppConfigManager数据提供对象字典中未能找到{0}配置信息！", dpname));
                    }
                    _dbUserGroupDP = (IUserGroup)Assembly.Load(assname).CreateInstance(dllname);
                }
                return _dbUserGroupDP;
            }
        }
        #endregion

        #region 用户权限数提供对象
        private static IUserPermission _dbUserPermissionDP;
        public static IUserPermission DbUserPermissionDP
        {
            get
            {
                if (_dbUserPermissionDP == null)
                {
                    string dpname = "DbUserPermissionDP";
                    string assname, dllname;
                    if (!AppConfigManager.GetDataProvider(dpname, out dllname, out assname))
                    {
                        log.Error(string.Format("AppConfigManager数据提供对象字典中未能找到{0}配置信息！", dpname));
                    }
                    _dbUserPermissionDP = (IUserPermission)Assembly.Load(assname).CreateInstance(dllname);
                }
                return _dbUserPermissionDP;
            }
        }
        #endregion`

        #region 用户角色数据提供对象
        private static IUserRole _dbUserRoleDP;
        public static IUserRole DbUserRoleDP
        {
            get
            {
                if (_dbUserRoleDP == null)
                {
                    string dpname = "DbUserRoleDP";
                    string assname, dllname;
                    if (!AppConfigManager.GetDataProvider(dpname, out dllname, out assname))
                    {
                        log.Error(string.Format("AppConfigManager数据提供对象字典中未能找到{0}配置信息！", dpname));
                    }
                    _dbUserRoleDP = (IUserRole)Assembly.Load(assname).CreateInstance(dllname);
                }
                return _dbUserRoleDP;
            }
        }
        #endregion


    }
}
