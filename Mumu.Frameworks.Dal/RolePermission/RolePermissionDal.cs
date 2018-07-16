using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using Mumu.Frameworks.Entity;
using Mumu.Frameworks.DatabaseInterface;

namespace Mumu.Frameworks.Dal
{
    public class RolePermissionDal : IRolePermission
    {
        public bool AddOrUpdateRolePermissionInfo(IDbCommand icmd, RolePermission info, EnumAddOrUpdate mode)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            if (mode == EnumAddOrUpdate.Add)
            {
                string sql = @"insert into t_role_permission(id,rid,pid,updatetime) values('{0}','{1}','{2}','{3}')";
                cmd.CommandText = string.Format(sql, info.id, info.rid, info.pid, info.updatetime);
            }
            else if (mode == EnumAddOrUpdate.Update)
            {
                string sql = @"update t_role_permission set rid = '{0}',pid = '{1}',updatetime = '{2}'
                                where id = '{3}'";
                cmd.CommandText = string.Format(sql, info.rid, info.pid, info.updatetime, info.id);
            }
            cmd.ExecuteNonQuery();
            return true;
        }

        public bool DeleteRolePermissionInfo(IDbCommand icmd, Guid id)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"delete from t_role_permission where id = '{0}'";
            cmd.CommandText = string.Format(sql, id);
            cmd.ExecuteNonQuery();
            return true;
        }

        public RolePermission GetRolePermissionById(IDbCommand icmd, Guid id)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"select id,rid,pid,updatetime from t_role_permission
                            where id = '{0}'";
            cmd.CommandText = string.Format(sql, id);
            DataTable dt = new DataTable();
            RolePermission info = null;
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                info = new RolePermission();
                info.AllParse(dt.Rows[0]);
            }
            return info;
        }

        public List<RolePermission> GetRolePermissionByRid(IDbCommand icmd, Guid rid)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"select id,rid,pid,updatetime from t_role_permission
                            where rid = '{0}'";
            cmd.CommandText = string.Format(sql, rid);
            DataTable dt = new DataTable();
            List<RolePermission> list = new List<RolePermission>();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                RolePermission info = null;
                foreach (DataRow dr in dt.Rows)
                {
                    info = new RolePermission();
                    info.AllParse(dr);
                    if (info != null)
                        list.Add(info);
                }
            }
            return list;
        }
    }
}
