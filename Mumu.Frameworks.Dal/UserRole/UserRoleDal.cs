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
    public class UserRoleDal : IUserRole
    {
        public bool AddOrUpdateUserRoleInfo(IDbCommand icmd, UserRole info, EnumAddOrUpdate mode)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            if (mode == EnumAddOrUpdate.Add)
            {
                string sql = @"insert into t_user_role(id,uid,rid,updatetime) values('{0}','{1}','{2}','{3}')";
                cmd.CommandText = string.Format(sql, info.id, info.uid, info.rid, info.updatetime);
            }
            else if (mode == EnumAddOrUpdate.Update)
            {
                string sql = @"update t_user_role set uid = '{0}',rid = '{1}',updatetime = '{2}' where id = '{3}'";
                cmd.CommandText = string.Format(sql, info.uid, info.rid, info.updatetime, info.id);
            }
            cmd.ExecuteNonQuery();
            return true;
        }

        public bool DeleteUserRoleInfo(IDbCommand icmd, Guid id)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"delete from t_user_role where id = '{0}'";
            cmd.CommandText = string.Format(sql, id);
            cmd.ExecuteNonQuery();
            return true;
        }

        public UserRole GetUserRoleInfoById(IDbCommand icmd, Guid id)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"select id,uid,rid,updatetime from t_user_role where id = '{0}'";
            cmd.CommandText = string.Format(sql, id);
            DataTable dt = new DataTable();
            UserRole info = null;
            dt.Load(cmd.ExecuteReader());
            if(dt.Rows.Count>0)
            {
                info = new UserRole();
                info.AllParse(dt.Rows[0]);
            }
            return info;
        }

        public List<UserRole> GetUserRoleByUid(IDbCommand icmd, Guid uid)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"select id,uid,rid,updatetime from t_user_role where uid = '{0}'";
            cmd.CommandText = string.Format(sql, uid);
            DataTable dt = new DataTable();
            List<UserRole> list = new List<UserRole>();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                UserRole info = null;
                foreach (DataRow dr in dt.Rows)
                {
                    info = new UserRole();
                    info.AllParse(dr);
                    if (info != null)
                        list.Add(info);
                }
            }
            return list;
        }
    }
}
