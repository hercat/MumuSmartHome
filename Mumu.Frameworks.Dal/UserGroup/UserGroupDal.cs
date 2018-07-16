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
    public class UserGroupDal : IUserGroup
    {
        public bool AddOrUpdateUserGroupInfo(IDbCommand icmd, UserGroup info, EnumAddOrUpdate mode)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            if (mode == EnumAddOrUpdate.Add)
            {
                string sql = @"insert into t_user_group(id,uid,gid,updatetime) values('{0}','{1}','{2}','{3}')";
                cmd.CommandText = string.Format(sql, info.id, info.uid, info.gid, info.updatetime);
            }
            else if (mode == EnumAddOrUpdate.Update)
            {
                string sql = @"update t_user_group set uid = '{0}',gid = '{1}',updatetime = '{2}'
                                where id = '{3}'";
                cmd.CommandText = string.Format(sql, info.uid, info.gid, info.updatetime, info.id);
            }
            cmd.ExecuteNonQuery();
            return true;
        }

        public bool DeleteUserGroupInfo(IDbCommand icmd, Guid id)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"delete from t_user_group where id = '{0}'";
            cmd.CommandText = string.Format(sql, id);
            cmd.ExecuteNonQuery();
            return true;
        }

        public UserGroup GetUserGroupById(IDbCommand icmd, Guid id)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"select id,uid,gid,updatetime from t_user_group
                            where id = '{0}'";
            cmd.CommandText = string.Format(sql, id);
            DataTable dt = new DataTable();
            UserGroup info = null;
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                info = new UserGroup();
                info.AllParse(dt.Rows[0]);
            }
            return info;
        }

        public List<UserGroup> GetUserGroupByUid(IDbCommand icmd, Guid uid)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"select id,uid,gid,updatetime from t_user_group
                            where uid = '{0}'";
            cmd.CommandText = string.Format(sql, uid);
            DataTable dt = new DataTable();
            List<UserGroup> list = new List<UserGroup>();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                UserGroup info = null;
                foreach (DataRow dr in dt.Rows)
                {
                    info = new UserGroup();
                    info.AllParse(dr);
                    if (info != null)
                        list.Add(info);
                }
            }
            return list;
        }
    }
}
