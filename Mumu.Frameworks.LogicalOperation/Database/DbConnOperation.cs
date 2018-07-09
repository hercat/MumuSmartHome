using System.Data;

namespace Mumu.Frameworks.LogicalOperation
{
    /// <summary>
    /// Description:数据库连接操作层
    /// Author:WUWEI
    /// Date:208/07/08
    /// </summary>
    public class DbConnOperation
    {
        /// <summary>
        /// 创建Mysql数据库连接对象
        /// </summary>
        /// <returns></returns>
        public static IDbConnection CreateMySqlConnection()
        {
            return DataProvider.DbConnDP.CreateDbConn(Mumu.Frameworks.Entity.ConnString.MySqldb);
        }
    }
}
