using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumu.Frameworks.Entity
{
    public class MongodbSettingBase
    {
        /// <summary>
        /// 服务器地址
        /// </summary>
        private string _server;
        public string Server
        {
            get
            {
                return _server;
            }
            set
            {
                this._server = value;
            }
        }
        /// <summary>
        /// 端口号
        /// </summary>
        private string _port;
        public string Port
        {
            get
            {
                return _port;
            }
            set
            {
                this._port = value;
            }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        private string _user;
        public string User
        {
            get
            {
                return _user;
            }
            set
            {
                this._user = value;
            }
        }
        /// <summary>
        /// 密码
        /// </summary>
        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                this._password = value;
            }
        }
        /// <summary>
        /// 数据库名
        /// </summary>
        private string _database;
        public string Database
        {
            get
            {
                return _database;
            }
            set
            {
                this._database = value;
            }
        }
    }
}
