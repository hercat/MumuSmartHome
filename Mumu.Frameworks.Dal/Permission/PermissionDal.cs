using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mumu.Frameworks.Entity;
using Mumu.Frameworks.DatabaseInterface;
using System.Data;
using MySql.Data.MySqlClient;

namespace Mumu.Frameworks.Dal
{
    public class PermissionDal : IPermission

    {
        public bool AddOrUpdatePermission(IDbCommand icmd, PermissionInfo info, EnumAddOrUpdate mode)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            if (mode == EnumAddOrUpdate.Add)
            {
                string sql = @"insert into t_permission_info(id,name,description,updatetime,status)
                                values ('{0}','{1}','{2}','{3}','{4}')";
                cmd.CommandText = string.Format(sql, info.id, info.name, info.description, info.updatetime, info.status);
            }
            else if (mode == EnumAddOrUpdate.Update)
            {
                string sql = @"update t_permission_info set name = '{0}',description = '{1}',updatetime = '{2}',status = '{3}'
                                where id = '{4}'";
                cmd.CommandText = string.Format(sql, info.name, info.description, info.updatetime, info.status, info.id);
            }
            cmd.ExecuteNonQuery();
            return true;
        }
    }
}
