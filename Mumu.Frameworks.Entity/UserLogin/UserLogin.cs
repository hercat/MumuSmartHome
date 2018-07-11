using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Mumu.Frameworks.Entity
{
    public class UserLogin
    {
        public Guid id { get; set; }
        public string loginName { get; set; }
        public string password { get; set; }
        public string cellphone { get; set; }
        public string email { get; set; }
        public string lastLoginIP { get; set; }
        public DateTime lastLoginTime { get; set; }
        public Guid createUserId { get; set; }
        public DateTime createtime { get; set; }
        public bool isAuthentication{ get; set; }
        public string prop1 { get; set; }
        public string prop2 { get; set; }
        public string prop3 { get; set; }
        public int status { get; set; }
        public bool AllParse(DataRow dr)
        {
            if (dr.Table.Columns.Contains(EnumUserLogin.id.ToString()))
                id = new Guid(dr[EnumUserLogin.id.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumUserLogin.login_name.ToString()))
                loginName = dr[EnumUserLogin.login_name.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumUserLogin.password.ToString()))
                password = dr[EnumUserLogin.password.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumUserLogin.cellphone.ToString()))
                cellphone = dr[EnumUserLogin.cellphone.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumUserLogin.email.ToString()))
                email = dr[EnumUserLogin.email.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumUserLogin.last_login_ip.ToString()))
                lastLoginIP = dr[EnumUserLogin.last_login_ip.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumUserLogin.last_login_time.ToString()))
                lastLoginTime = DateTime.Parse(dr[EnumUserLogin.last_login_time.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumUserLogin.create_user_id.ToString()))
                createUserId = new Guid(dr[EnumUserLogin.create_user_id.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumUserLogin.createtime.ToString()))
                createtime = DateTime.Parse(dr[EnumUserLogin.createtime.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumUserLogin.is_authentication.ToString()))
                isAuthentication = bool.Parse(dr[EnumUserLogin.is_authentication.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumUserLogin.prop1.ToString()))
                prop1 = dr[EnumUserLogin.prop1.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumUserLogin.prop2.ToString()))
                prop2 = dr[EnumUserLogin.prop2.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumUserLogin.prop3.ToString()))
                prop3 = dr[EnumUserLogin.prop3.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumUserLogin.status.ToString()))
                status = Int32.Parse(dr[EnumUserLogin.status.ToString()].ToString());
            return true;
        }
    }
    enum EnumUserLogin
    {
        id,
        login_name,
        password,
        cellphone,
        email,
        last_login_ip,
        last_login_time,
        create_user_id,
        createtime,
        is_authentication,
        prop1,
        prop2,
        prop3,
        status
    }
}
