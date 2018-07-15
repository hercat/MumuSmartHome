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
    public class UserLoginDal : IUserLogin
    {
        public bool AddOrUpdateUserLoginInfo(IDbCommand icmd, UserLogin info, EnumAddOrUpdate mode)
        {
            icmd.Parameters.Clear();
            MySqlCommand cmd = icmd as MySqlCommand;
            cmd.CommandType = CommandType.Text;
            if (mode == EnumAddOrUpdate.Add)
            {
                string sql = @"insert into t_user_login(id,login_name,password,cellphone,email,last_login_ip,last_login_time,create_user_id,createtime,is_authentication,prop1,prop2,prop3,status)
                                values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}')";
                cmd.CommandText = string.Format(sql, info.id, info.loginName, info.password, info.cellphone, info.email, info.lastLoginIP, info.lastLoginTime, info.createUserId, info.createtime, info.isAuthentication, info.prop1, info.prop2, info.prop3, info.status);
            }
            else if (mode == EnumAddOrUpdate.Update)
            {
                string sql = @"update t_user_login set login_name = '{0}',password = '{1}',cellphone = '{2}',email = '{3}',last_login_ip = '{4}',last_login_time = '{5}',
                                create_user_id = '{6}',createtime = '{7}',is_authentication = '{8}',prop1 = '{9}',prop2 = '{10}',prop3 = '{11}',status = '{12}'
                                where id = '{13}'";
                cmd.CommandText = string.Format(sql, info.loginName, info.password, info.cellphone, info.email, info.lastLoginIP, info.lastLoginTime, info.createUserId, info.createtime, info.isAuthentication, info.prop1, info.prop2, info.prop3, info.status, info.id);
            }
            cmd.ExecuteNonQuery();
            return true;
        }
    }
}
