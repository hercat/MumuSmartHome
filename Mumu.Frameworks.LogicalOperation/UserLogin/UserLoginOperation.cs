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
    public class UserLoginOperation
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// 新增或修改用户登录信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static bool AddOrUpdateUserLoginInfo(UserLogin info, EnumAddOrUpdate mode)
        {
            bool ret = false;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDbTransaction trans = null;
            try
            {
                IUserLogin dp = DataProvider.DbUserLoginDP;
                conn = DbConnOperation.CreateMySqlConnection();
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                ret = dp.AddOrUpdateUserLoginInfo(cmd, info, mode);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                log.Error(string.Format("AddOrUpdateUserLoginInfo()出错,错误信息如下:{0}", ex.Message));
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
            return ret;
        }
    }
}
