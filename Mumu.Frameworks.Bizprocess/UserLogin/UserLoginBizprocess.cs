using System;
using log4net;
using System.Reflection;
using Mumu.Frameworks.Entity;
using Mumu.Frameworks.LogicalOperation;

namespace Mumu.Frameworks.Bizprocess
{
    public class UserLoginBizprocess
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static string AddUserLogin(UserLogin login, UserGroup group, PermissionInfo permission, UserRole role)
        {
            try
            {
                //查询
                UserLogin info = UserLoginOperation.GetUserLoginInfoByName(login.loginName);
                if (null == info)
                {
                    //添加用户登录账号信息
                    UserLoginOperation.AddOrUpdateUserLoginInfo(info, EnumAddOrUpdate.Add);
                    //添加用户组信息
                    UserGroupOperation.AddOrUpdateUserGroupInfo(group, EnumAddOrUpdate.Add);
                    //添加用户权限信息
                    PermissionOperation.AddOrUpdatePermission(permission, EnumAddOrUpdate.Add);
                    //添加用户角色信息
                    UserRoleOperation.AddOrUpdateUserRoleInfo(role, EnumAddOrUpdate.Add);
                    return string.Format("添加登录账号【{0}】信息成功！", login.loginName);
                }
                else
                    return string.Format("系统已存在【{0}】登录账号！", info.loginName);
            }
            catch (Exception ex)
            {
                log.Error("AddUserLogin()发生错误,错误信息如下:{0}", ex);
                return string.Format("添加登录账号失败,错误信息如下:{0}", ex.Message);
            }
        }
    }
}
