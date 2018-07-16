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
    public class GroupPermissionDal : IGroupPermission
    {
        public bool AddOrUpdateGroupPermissionInfo(IDbCommand icmd, GroupPermission info, EnumAddOrUpdate mode)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            if (mode == EnumAddOrUpdate.Add)
            {
                string sql = @"insert into t_group_permission(id,gid,pid,updatetime) values('{0}','{1}','{2}','{3}')";
                cmd.CommandText = string.Format(sql, info.id, info.gid, info.pid, info.updatetime);
            }
            else if (mode == EnumAddOrUpdate.Update)
            {
                string sql = @"update t_group_permission set gid = '{0}',pid = '{1}',updatetime = '{2}'
                                where id = '{3}'";
                cmd.CommandText = string.Format(sql, info.gid, info.pid, info.updatetime, info.id);
            }
            cmd.ExecuteNonQuery();
            return true;
        }

        public bool DeleteGroupPermissionInfo(IDbCommand icmd, Guid id)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"delete from t_group_permission where id = '{0}'";
            cmd.CommandText = string.Format(sql, id);
            cmd.ExecuteNonQuery();
            return true;
        }

        public GroupPermission GetGroupPermissionInfoById(IDbCommand icmd, Guid id)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"select id,gid,pid,updatetime from t_group_permission
                            where id = '{0}'";
            cmd.CommandText = string.Format(sql, id);
            DataTable dt = new DataTable();
            GroupPermission info = null;
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                info = new GroupPermission();
                info.AllParse(dt.Rows[0]);
            }
            return info;
        }
        public List<GroupPermission> GetGroupPermissionInfoByGid(IDbCommand icmd, Guid gid)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"select id,gid,pid,updatetime from t_group_permission
                            where gid = '{0}'";
            cmd.CommandText = string.Format(sql, gid);
            List<GroupPermission> list = new List<GroupPermission>();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                GroupPermission info = null;
                foreach (DataRow dr in dt.Rows)
                {
                    info = new GroupPermission();
                    info.AllParse(dr);
                    if (info != null)
                        list.Add(info);
                }
            }
            return list;
        }
    }
}
