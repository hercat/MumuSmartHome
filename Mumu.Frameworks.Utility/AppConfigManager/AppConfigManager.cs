using System;
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
                    _dicDataProvider.Add("DbGroupDP", "Mumu.Frameworks.Dal.GroupDal");
                    _dicDataProvider.Add("DbPermissionDP", "Mumu.Frameworks.Dal.PermissionDal");
                    _dicDataProvider.Add("DbRoleDP", "Mumu.Frameworks.Dal.RoleDal");
                    _dicDataProvider.Add("DbUserLoginDP", "Mumu.Frameworks.Dal.UserLoginDal");
                    _dicDataProvider.Add("DbGroupPermissionDP", "Mumu.Frameworks.Dal.GroupPermissionDal");
                    _dicDataProvider.Add("DbRolePermissionDP", "Mumu.Frameworks.Dal.RolePermissionDal");
                    _dicDataProvider.Add("DbUserGroupDP", "Mumu.Frameworks.Dal.UserGroupDal");
                    _dicDataProvider.Add("DbUserPermissionDP", "Mumu.Frameworks.Dal.UserPermissionDal");
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
