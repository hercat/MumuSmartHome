using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using Mumu.Frameworks.DatabaseInterface;
using Mumu.Frameworks.Entity;

namespace Mumu.Frameworks.Dal
{
    public class RoleDal : IRole
    {
        public bool AddOrUpdateRoleInfo(IDbCommand icmd, RoleInfo info, EnumAddOrUpdate mode)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            if (mode == EnumAddOrUpdate.Add)
            {
                string sql = @"insert into t_role_info(id,name,description,updatetime,status)
                            values('{0}','{1}','{2}','{3}','{4}')";
                cmd.CommandText = string.Format(sql, info.id, info.name, info.description, info.updatetime, info.status);
            }
            else if (mode == EnumAddOrUpdate.Update)
            {
                string sql = @"update t_role_info set name = '{0}',description = '{1}',updatetime = '{2}',status = '{3}'
                                where id = '{4}'";
                cmd.CommandText = string.Format(sql, info.name, info.description, info.updatetime, info.status, info.id);
            }
            cmd.ExecuteNonQuery();
            return true;
        }

        public bool DeleteRoleInfo(IDbCommand icmd, Guid id)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"delete from t_role_info
                            where id = '{0}'";
            cmd.CommandText = string.Format(sql, id);
            cmd.ExecuteNonQuery();
            return true;
        }
        
        public RoleInfo GetRoleInfoByName(IDbCommand icmd, string name)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"select id,name,description,updatetime,status
                            from t_role_info
                            where name = '{0}'";
            cmd.CommandText = string.Format(sql, name);
            DataTable dt = new DataTable();
            RoleInfo info = null;
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                info = new RoleInfo();
                info.AllParse(dt.Rows[0]);
            }
            return info;
        }

        public RoleInfo GetRoleInfoById(IDbCommand icmd, Guid id)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"select id,name,description,updatetime,status
                            from t_role_info
                            where id = '{0}'";
            cmd.CommandText = string.Format(sql, id);
            DataTable dt = new DataTable();
            RoleInfo info = null;
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                info = new RoleInfo();
                info.AllParse(dt.Rows[0]);
            }
            return info;
        }

        public List<RoleInfo> GetRoleInfoPageList(IDbCommand icmd, string fileds, string whereCondition, int startIndex, int pageSize)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(fileds))
                sb.AppendFormat("select {0} from t_role_info ", fileds);
            if (!string.IsNullOrEmpty(whereCondition))
                sb.AppendFormat("{0} ", whereCondition);
            sb.AppendFormat("limit {0},{1}", startIndex, pageSize);
            List<RoleInfo> list = new List<RoleInfo>();
            DataTable dt = new DataTable();
            if (dt.Rows.Count > 0)
            {
                RoleInfo info = null;
                foreach (DataRow dr in dt.Rows)
                {
                    info = new RoleInfo();
                    info.AllParse(dr);
                    if(info!=null)
                        list.Add(info);
                }
            }
            return list;
        }
    }
}
