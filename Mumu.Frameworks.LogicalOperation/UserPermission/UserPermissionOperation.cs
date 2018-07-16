using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using log4net;
using System.Data;
using Mumu.Frameworks.Entity;
using Mumu.Frameworks.Utility;
using Mumu.Frameworks.DatabaseInterface;

namespace Mumu.Frameworks.LogicalOperation
{
    public class UserPermissionOperation
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// 新增或更新用户权限信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static bool AddOrUpdateUserPermissionInfo(UserPermission info, EnumAddOrUpdate mode)
        {
            bool ret = false;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IUserPermission dp = DataProvider.DbUserPermissionDP;
                conn = DbConnOperation.CreateMySqlConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                ret = dp.AddOrUpdateUserPermissionInfo(cmd, info, mode);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                log.Error(string.Format("AddOrUpdateUserPermissionInfo()出错,错误信息如下:{0}", ex.Message));
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return ret;
        }
        /// <summary>
        /// 根据id删除用户权限信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteUserPermissionInfo(Guid id)
        {
            bool ret = false;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IUserPermission dp = DataProvider.DbUserPermissionDP;
                conn = DbConnOperation.CreateMySqlConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                ret = dp.DeleteUserPermissionInfo(cmd, id);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                log.Error(string.Format("DeleteUserPermissionInfo()出错,错误信息如下:{0}", ex.Message));
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return ret;
        }
        /// <summary>
        /// 根据id获取用户权限信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static UserPermission GetUserPermissionInfoById(Guid id)
        {
            UserPermission info = null;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IUserPermission dp = DataProvider.DbUserPermissionDP;
                conn = DbConnOperation.CreateMySqlConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                info = dp.GetUserPermissionInfoById(cmd, id);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                log.Error(string.Format("GetUserPermissionInfoById()出错,错误信息如下:{0}", ex.Message));
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return info;
        }
        /// <summary>
        /// 根据uid获取用户权限信息列表
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static List<UserPermission> GetUserPermissionInfoByUid(Guid uid)
        {
            List<UserPermission> list = new List<UserPermission>();
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IUserPermission dp = DataProvider.DbUserPermissionDP;
                conn = DbConnOperation.CreateMySqlConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                list = dp.GetUserPermissionInfoByUid(cmd, uid);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                log.Error(string.Format("GetUserPermissionInfoByUid()出错,错误信息如下:{0}", ex.Message));
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return list;
        }
    }
}
