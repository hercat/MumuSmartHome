using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Data;
using System.Reflection;
using Mumu.Frameworks.Entity;
using Mumu.Frameworks.Utility;
using Mumu.Frameworks.DatabaseInterface;

namespace Mumu.Frameworks.LogicalOperation
{
    public class GroupPermissionOperation
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// 新增或更新用户组权限信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static bool AddOrUpdateGroupPermissionInfo(GroupPermission info, EnumAddOrUpdate mode)
        {
            bool ret = false;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IGroupPermission dp = DataProvider.DbGroupPermissionDP;
                conn = DbConnOperation.CreateMySqlConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                ret = dp.AddOrUpdateGroupPermissionInfo(cmd, info, mode);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                log.Error(string.Format("AddOrUpdateGroupPermissionInfo()出错,错误信息如下:{0}", ex.Message));
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return ret;
        }
        /// <summary>
        /// 根据id删除用户组权限信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteGroupPermissionInfo(Guid id)
        {
            bool ret = false;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IGroupPermission dp = DataProvider.DbGroupPermissionDP;
                conn = DbConnOperation.CreateMySqlConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                ret = dp.DeleteGroupPermissionInfo(cmd, id);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                log.Error(string.Format("DeleteGroupPermissionInfo()出错,错误信息如下:{0}", ex.Message));
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return ret;
        }
        /// <summary>
        /// 根据id获取用户组权限信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static GroupPermission GetGroupPermissionInfoById(Guid id)
        {
            GroupPermission info = null;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IGroupPermission dp = DataProvider.DbGroupPermissionDP;
                conn = DbConnOperation.CreateMySqlConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                info = dp.GetGroupPermissionInfoById(cmd, id);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                log.Error(string.Format("GetGroupPermissionInfoById()出错,错误信息如下:{0}", ex.Message));
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return info;
        }
        /// <summary>
        /// 获取用户组权限列表
        /// </summary>
        /// <param name="gid">用户组编号</param>
        /// <returns></returns>
        public static List<GroupPermission> GetGroupPermissionInfoByGid(Guid gid)
        {
            List<GroupPermission> list = new List<GroupPermission>();
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IGroupPermission dp = DataProvider.DbGroupPermissionDP;
                conn = DbConnOperation.CreateMySqlConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                list = dp.GetGroupPermissionInfoByGid(cmd, gid);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                log.Error(string.Format("GetGroupPermissionInfoByGid()出错,错误信息如下:{0}", ex.Message));
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
