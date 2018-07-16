using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using log4net;
using System.Reflection;
using Mumu.Frameworks.Entity;
using Mumu.Frameworks.Utility;
using Mumu.Frameworks.DatabaseInterface;

namespace Mumu.Frameworks.LogicalOperation
{
    public class RolePermissionOperation
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// 新增或更新角色权限信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static bool AddOrUpdateRolePermissionInfo(RolePermission info, EnumAddOrUpdate mode)
        {
            bool ret = false;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IRolePermission dp = DataProvider.DbRolePermissionDP;
                conn = DbConnOperation.CreateMySqlConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                ret = dp.AddOrUpdateRolePermissionInfo(cmd, info, mode);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                log.Error(string.Format("AddOrUpdateRolePermissionInfo()出错,错误信息如下:{0}", ex.Message));
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return ret;
        }
        /// <summary>
        /// 根据id删除角色权限信息
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public static bool DeleteRolePermissionInfo(Guid id)
        {
            bool ret = false;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IRolePermission dp = DataProvider.DbRolePermissionDP;
                conn = DbConnOperation.CreateMySqlConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                ret = dp.DeleteRolePermissionInfo(cmd, id);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                log.Error(string.Format("DeleteRolePermissionInfo()出错,错误信息如下:{0}", ex.Message));
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return ret;
        }
        /// <summary>
        /// 根据id获取角色权限信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static RolePermission GetRolePermissionById(Guid id)
        {
            RolePermission info = null;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IRolePermission dp = DataProvider.DbRolePermissionDP;
                conn = DbConnOperation.CreateMySqlConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                info = dp.GetRolePermissionById(cmd, id);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                log.Error(string.Format("GetRolePermissionById()出错,错误信息如下:{0}", ex.Message));
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return info;
        }
        /// <summary>
        /// 根据rid获取角色权限列表信息
        /// </summary>
        /// <param name="rid">角色编号</param>
        /// <returns></returns>
        public static List<RolePermission> GetRolePermissionByRid(Guid rid)
        {
            List<RolePermission> list = new List<RolePermission>();
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IRolePermission dp = DataProvider.DbRolePermissionDP;
                conn = DbConnOperation.CreateMySqlConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                list = dp.GetRolePermissionByRid(cmd, rid);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                log.Error(string.Format("GetRolePermissionByRid()出错,错误信息如下:{0}", ex.Message));
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
