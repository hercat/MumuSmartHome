﻿using System;
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

        public bool DeletePermissionInfo(IDbCommand icmd, Guid id)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"delete from t_permission_info
                        where id = '{0}'";
            cmd.CommandText = string.Format(sql, id);
            cmd.ExecuteNonQuery();
            return true;
        }

        public PermissionInfo GetPermissionInfoByName(IDbCommand icmd, string name)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"select id,name,description,updatetime,status
                            from t_permission_info
                            where name = '{0}'";
            cmd.CommandText = string.Format(sql, name);
            DataTable dt = new DataTable();
            PermissionInfo info = null;
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                info = new PermissionInfo();
                info.AllParse(dt.Rows[0]);
            }
            return info;
        }

        public PermissionInfo GetPermissionInfoById(IDbCommand icmd, Guid id)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"select id,name,description,updatetime,status
                            from t_permission_info
                            where id = '{0}'";
            cmd.CommandText = string.Format(sql, id);
            DataTable dt = new DataTable();
            PermissionInfo info = null;
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                info = new PermissionInfo();
                info.AllParse(dt.Rows[0]);
            }
            return info;
        }

        public List<PermissionInfo> GetPermissionInfoPageList(IDbCommand icmd, string fields, string whereCondition, int startIndex, int pageSize)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(fields))
                sb.AppendFormat("select {0} from t_permission_info ", fields);
            if (!string.IsNullOrEmpty(whereCondition))
                sb.AppendFormat("{0} ", whereCondition);
            sb.AppendFormat("limit {0},{1}", startIndex, pageSize);
            cmd.CommandText = sb.ToString();
            List<PermissionInfo> list = new List<PermissionInfo>();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                PermissionInfo info = null;
                foreach (DataRow dr in dt.Rows)
                {
                    info = new PermissionInfo();
                    info.AllParse(dr);
                    if (null != info)
                        list.Add(info);
                }
            }
            return list;
        }
    }
}
