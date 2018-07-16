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
    public class UserGroupOperation
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// 新增或更新用户用户组信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static bool AddOrUpdateUserGroupInfo(UserGroup info, EnumAddOrUpdate mode)
        {
            bool ret = false;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IUserGroup dp = DataProvider.DbUserGroupDP;
                conn = DbConnOperation.CreateMySqlConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                ret = dp.AddOrUpdateUserGroupInfo(cmd, info, mode);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                log.Error(string.Format("AddOrUpdateUserGroupInfo()出错,错误信息如下:{0}", ex.Message));
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return ret;
        }
        /// <summary>
        /// 根据id删除用户用户组信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteUserGroupInfo(Guid id)
        {
            bool ret = false;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IUserGroup dp = DataProvider.DbUserGroupDP;
                conn = DbConnOperation.CreateMySqlConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                ret = dp.DeleteUserGroupInfo(cmd, id);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                log.Error(string.Format("DeleteUserGroupInfo()出错,错误信息如下:{0}", ex.Message));
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return ret;
        }
        /// <summary>
        /// 根据id获取用户用户组信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static UserGroup GetUserGroupById(Guid id)
        {
            UserGroup info = null;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IUserGroup dp = DataProvider.DbUserGroupDP;
                conn = DbConnOperation.CreateMySqlConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                info = dp.GetUserGroupById(cmd, id);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                log.Error(string.Format("GetUserGroupById()出错,错误信息如下:{0}", ex.Message));
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return info;
        }
        /// <summary>
        /// 根据uid获取用户组权限信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public static List<UserGroup> GetUserGroupByUid(Guid uid)
        {
            List<UserGroup> list = new List<UserGroup>();
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IUserGroup dp = DataProvider.DbUserGroupDP;
                conn = DbConnOperation.CreateMySqlConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                list = dp.GetUserGroupByUid(cmd, uid);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                log.Error(string.Format("GetUserGroupByUid()出错,错误信息如下:{0}", ex.Message));
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
