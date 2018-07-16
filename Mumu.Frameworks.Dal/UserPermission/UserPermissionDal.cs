using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using Mumu.Frameworks.Dal;
using Mumu.Frameworks.Entity;
using Mumu.Frameworks.DatabaseInterface;

namespace Mumu.Frameworks.Dal
{
    public class UserPermissionDal:IUserPermission
    {
        public bool AddOrUpdateUserPermissionInfo(IDbCommand icmd, UserPermission info, EnumAddOrUpdate mode)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            if (mode == EnumAddOrUpdate.Add)
            {
                string sql = @"insert into t_user_permission(id,uid,pid,updatetime) value('{0}','{1}','{2}','{3}')";
                cmd.CommandText = string.Format(sql, info.id, info.uid, info.pid, info.updatetime);
            }
            else if (mode == EnumAddOrUpdate.Update)
            {
                string sql = @"update t_user_permission set uid = '{0}',pid = '{1}',updatetime = '{2}' where id = '{3}'";
                cmd.CommandText = string.Format(sql, info.uid, info.pid, info.updatetime, info.id);
            }
            cmd.ExecuteNonQuery();
            return true;
        }

        public bool DeleteUserPermissionInfo(IDbCommand icmd, Guid id)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"delete from t_user_permission where id = '{0}'";
            cmd.CommandText = string.Format(sql, id);
            cmd.ExecuteNonQuery();
            return true;
        }

        public UserPermission GetUserPermissionInfoById(IDbCommand icmd, Guid id)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"select id,uid,pid,updatetime from t_user_permission where id = '{0}'";
            cmd.CommandText = string.Format(sql, id);
            DataTable dt = new DataTable();
            UserPermission info = null;
            dt.Load(cmd.ExecuteReader());
            if(dt.Rows.Count>0)
            {
                info = new UserPermission();
                info.AllParse(dt.Rows[0]);
            }
            return info;
        }
        
        public List<UserPermission> GetUserPermissionInfoByUid(IDbCommand icmd, Guid uid)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"select id,uid,pid,updatetime from t_user_permission where uid = '{0}'";
            DataTable dt = new DataTable();
            List<UserPermission> list = new List<UserPermission>();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                UserPermission info = null;
                foreach (DataRow dr in dt.Rows)
                {
                    info = new UserPermission();
                    info.AllParse(dr);
                    if (info != null)
                        list.Add(info);
                }
            }
            return list;
        }
    }
}
