using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mumu.Frameworks.Entity;
using Mumu.Frameworks.DatabaseInterface;
using log4net;
using System.Data;
using System.Reflection;

namespace Mumu.Frameworks.LogicalOperation
{
    public class RoleOperation
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// 新增或更新角色信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public bool AddOrUpdateRoleInfo(RoleInfo info, EnumAddOrUpdate mode)
        {
            bool ret = false;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IRole dp = DataProvider.DbRoleDP;
                conn = DbConnOperation.CreateMySqlConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                ret = dp.AddOrUpdateRoleInfo(cmd, info, mode);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                log.Error(string.Format("AddOrUpdateRoleInfo()出错,错误信息如下:{0}", ex.Message));
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return ret;
        }
        /// <summary>
        /// 根据id删除角色信息
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public bool DeleteRoleInfo(Guid id)
        {
            bool ret = false;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IRole dp = DataProvider.DbRoleDP;
                conn = DbConnOperation.CreateMySqlConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                ret = dp.DeleteRoleInfo(cmd, id);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                log.Error(string.Format("DeleteRoleInfo()出错,错误信息如下:{0}", ex.Message));
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return ret;
        }
        /// <summary>
        /// 根据name获取角色信息
        /// </summary>
        /// <param name="name">name</param>
        /// <returns></returns>
        public RoleInfo GetRoleInfoByName(string name)
        {
            RoleInfo info = null;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IRole dp = DataProvider.DbRoleDP;
                conn = DbConnOperation.CreateMySqlConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                info = dp.GetRoleInfoByName(cmd, name);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                log.Error(string.Format("GetRoleInfoByName()出错,错误信息如下:{0}", ex.Message));
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return info;
        }
        /// <summary>
        /// 根据id获取角色信息
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public RoleInfo GetRoleInfoById(Guid id)
        {
            RoleInfo info = null;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IRole dp = DataProvider.DbRoleDP;
                conn = DbConnOperation.CreateMySqlConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                info = dp.GetRoleInfoById(cmd, id);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                log.Error(string.Format("GetRoleInfoById()出错,错误信息如下:{0}", ex.Message));
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return info;
        }
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="whereCondition"></param>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<RoleInfo> GetRoleInfoPageList(string fields, string whereCondition, int startIndex, int pageSize)
        {
            List<RoleInfo> list = new List<RoleInfo>();
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IRole dp = DataProvider.DbRoleDP;
                conn = DbConnOperation.CreateMySqlConnection();
                cmd = conn.CreateCommand();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                list = dp.GetRoleInfoPageList(cmd, fields, whereCondition, startIndex, pageSize);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                log.Error(string.Format("GetRoleInfoPageList()出错,错误信息如下:{0}", ex.Message));
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
