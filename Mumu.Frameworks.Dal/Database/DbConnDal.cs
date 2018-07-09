using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mumu.Frameworks.DatabaseInterface;
using MySql.Data.MySqlClient;
using System.Data;

namespace Mumu.Frameworks.Dal
{
    /// <summary>
    /// Description:
    /// </summary>
    public class DbConnDal : IDbConn
    {
        IDbConnection IDbConn.CreateDbConn(string connString)
        {
            return new MySqlConnection(connString);
        }
    }
}
