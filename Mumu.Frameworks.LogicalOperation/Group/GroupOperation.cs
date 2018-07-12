using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Mumu.Frameworks.Entity;
using Mumu.Frameworks.Utility;
using Mumu.Frameworks.DatabaseInterface;
using log4net;
using System.Reflection;

namespace Mumu.Frameworks.LogicalOperation
{
    /// <summary>
    /// Description:
    /// </summary>
    public class GroupOperation
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// 添加或修改用户组信息
        /// </summary>
        /// <param name="info">用户组</param>
        /// <param name="mode">操作模式</param>
        /// <returns></returns>
        public static bool AddOrUpdateGroupInfo(GroupInfo info, EnumAddOrUpdate mode)
        {
            bool ret = false;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IGroup dp = DataProvider.DbGroupDP;
                conn = DbConnOperation.CreateMySqlConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                ret = dp.AddOrUpdateGroupInfo(cmd, info, mode);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                log.Error(string.Format("AddOrUpdateGroupInfo()出错,错误信息如下:{0}", ex.Message));
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return ret;
        }
        /// <summary>
        /// 物理删除用户组信息
        /// </summary>
        /// <param name="id">用户组编号</param>
        /// <returns></returns>
        public static bool DeleteGroupInfo(Guid id)
        {
            bool ret = false;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IGroup dp = DataProvider.DbGroupDP;
                conn = DbConnOperation.CreateMySqlConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                ret = dp.DeleteGroupInfo(cmd, id);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                log.Error(string.Format("DeleteGroupInfo()出错,错误信息如下:{0}", ex.Message));
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return ret;
        }
        /// <summary>
        /// 根据名称获取用户组信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static GroupInfo GetGroupInfoByName(string name)
        {
            GroupInfo info = null;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IGroup dp = DataProvider.DbGroupDP;
                conn = DbConnOperation.CreateMySqlConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                info = dp.GetGroupInfoByName(cmd, name);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                log.Error(string.Format("GetGroupInfoByName()出错,错误信息如下:{0}", ex.Message));
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return info;
        }
        /// <summary>
        /// 根据id获取用户组信息
        /// </summary>
        /// <param name="id">用户组编号</param>
        /// <returns></returns>
        public static GroupInfo GetGroupInfoById(Guid id)
        {
            GroupInfo info = null;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IGroup dp = DataProvider.DbGroupDP;
                conn = DbConnOperation.CreateMySqlConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                info = dp.GetGroupInfoById(cmd, id);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                log.Error(string.Format("GetGroupInfoById()出错,错误信息如下:{0}", ex.Message));
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return info;
        }
        /// <summary>
        /// 用户组信息分页获取
        /// </summary>
        /// <param name="fields">字段</param>
        /// <param name="whereCondition">where条件</param>
        /// <param name="startIndex">开始下标</param>
        /// <param name="pageSize">页面大小</param>
        /// <returns></returns>
        public static List<GroupInfo> GetGroupInfoPageList(string fields, string whereCondition, int startIndex, int pageSize)
        {
            List<GroupInfo> list = new List<GroupInfo>();
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IGroup dp = DataProvider.DbGroupDP;
                conn = DbConnOperation.CreateMySqlConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                list = dp.GetGroupInfoPageList(cmd, fields, whereCondition, startIndex, pageSize);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                log.Error(string.Format("GetGroupInfoPageList()出错,错误信息如下:{0}", ex.Message));
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
