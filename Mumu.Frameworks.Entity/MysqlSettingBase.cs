using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumu.Frameworks.Entity
{
    /// <summary>
    /// Description:Mysql数据库配置类
    /// Author:WUWEI
    /// Date:2018/07/09
    /// </summary>
    public class MysqlSettingBase
    {
        private string _server;
        public string Server
        {
            get { return _server; }
            set { this._server = value; }
        }

        private string _database;
        public string DataBase
        {
            get { return _database; }
            set { this._database = value; }
        }

        private string _uid;
        public string Uid
        {
            get { return _uid; }
            set { this._uid = value; }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { this._password = value; }
        }

        private string _charset;
        public string Charset
        {
            get { return _charset; }
            set { this._charset = value; }
        }

        public string ConnString
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (!string.IsNullOrEmpty(Server))
                    sb.AppendFormat("Server={0};", this.Server);
                if (!string.IsNullOrEmpty(DataBase))
                    sb.AppendFormat("Database={0};", this.DataBase);
                if (!string.IsNullOrEmpty(Charset))
                    sb.AppendFormat("Charset={0};", Charset);
                if (!string.IsNullOrEmpty(Uid))
                    sb.AppendFormat("Uid={0};", Uid);
                if (!string.IsNullOrEmpty(Password))
                    sb.AppendFormat("Pwd={0}", Password);
                return sb.ToString();
            }
        }
    }
}
