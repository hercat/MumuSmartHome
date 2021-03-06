﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mumu.Frameworks.Entity;
using Mumu.Frameworks.DatabaseInterface;
using System.Data;
using System.Reflection;
using MySql.Data.MySqlClient;

namespace Mumu.Frameworks.Dal
{
    /// <summary>
    /// Description:用户组数据访问层
    /// Author:WUWEI
    /// Date:2018/07/11
    /// </summary>
    public class GroupDal : IGroup
    {       
        public bool AddOrUpdateGroupInfo(IDbCommand icmd, GroupInfo info, EnumAddOrUpdate mode)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            if (mode == EnumAddOrUpdate.Add)
            {
                string sql = @"insert into t_group_info(id,name,description,updatetime,status) 
                                values('{0}','{1}','{2}','{3}','{4}')";
                cmd.CommandText = string.Format(sql, info.id, info.name, info.description, info.updatetime, info.status);
            }
            else if (mode == EnumAddOrUpdate.Update)
            {
                string sql = @"update t_group_info set name = '{0}',description = '{1}',updatetime = '{2}',status = '{3}'
                                where id = '{4}'";
                cmd.CommandText = string.Format(sql, info.name, info.description, info.updatetime, info.status, info.id);
            }
            cmd.ExecuteNonQuery();
            return true;
        }

        public bool DeleteGroupInfo(IDbCommand icmd, Guid id)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"delete from t_group_info where id = '{0}'";
            cmd.CommandText = string.Format(sql, id);
            cmd.ExecuteNonQuery();
            return true;
        }

        public GroupInfo GetGroupInfoByName(IDbCommand icmd, string name)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"select id,name,description,updatetime,status from t_group_info
                            where name = '{0}'";
            cmd.CommandText = string.Format(sql, name);
            GroupInfo info = null;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                info = new GroupInfo();
                info.AllParse(dt.Rows[0]);
            }
            return info;
        }

        public GroupInfo GetGroupInfoById(IDbCommand icmd, Guid id)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            string sql = @"select id,name,description,updatetime,status from t_group_info
                            where id = '{0}'";
            cmd.CommandText = string.Format(sql, id);
            GroupInfo info = null;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                info = new GroupInfo();
                info.AllParse(dt.Rows[0]);
            }
            return info;
        }

        public List<GroupInfo> GetGroupInfoListAll(IDbCommand icmd, string fields, string whereCondition)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(fields))
                sb.AppendFormat("select {0} from t_group_info ", fields);
            if (!string.IsNullOrEmpty(whereCondition))
                sb.AppendFormat("{0} ", whereCondition);            
            cmd.CommandText = sb.ToString();
            List<GroupInfo> list = new List<GroupInfo>();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                GroupInfo info = null;
                foreach (DataRow dr in dt.Rows)
                {
                    info = new GroupInfo();
                    info.AllParse(dr);
                    if (null != info)
                        list.Add(info);
                }
            }
            return list;
        }
        public List<GroupInfo> GetGroupInfoPageList(IDbCommand icmd, string fileds, string whereCondition,string orderby, string limit)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(fileds))
                sb.AppendFormat("select {0} from t_group_info ", fileds);
            if (!string.IsNullOrEmpty(whereCondition))
                sb.AppendFormat("{0} ", whereCondition);
            sb.AppendFormat("{0} ", orderby);
            sb.AppendFormat("{0}",limit);
            cmd.CommandText = sb.ToString();
            List<GroupInfo> list = new List<GroupInfo>();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                GroupInfo info = null;
                foreach (DataRow dr in dt.Rows)
                {
                    info = new GroupInfo();
                    info.AllParse(dr);
                    if (null != info)
                        list.Add(info);
                }
            }
            return list;
        }
    }
}
