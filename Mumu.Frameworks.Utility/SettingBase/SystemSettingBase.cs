using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Mumu.Frameworks.Entity;

namespace Mumu.Frameworks.Utility
{
    /// <summary>
    /// Description:系统配置信息类
    /// Author:WUWEI
    /// Date:2018/07/09
    /// </summary>
    public class SystemSettingBase : SettingBase
    {
        private static SystemSettingBase _instance = null;
        private static readonly object locker = new object();
        private SystemSettingBase() { }
        public static SystemSettingBase Instance
        {
            get
            {
                if (null == _instance)
                {
                    SystemSettingBase temp = new SystemSettingBase();
                    _instance = SystemSettingBase.Load(temp, LocationType.Application) as SystemSettingBase;
                }
                return _instance;
            }
        }

        public static SystemSettingBase CreateInstance()
        {
            if (null == _instance)
            {
                lock (locker)
                {
                    if (null == _instance)
                    {
                        SystemSettingBase temp = new SystemSettingBase();
                        _instance = SystemSettingBase.Load(temp, LocationType.Application) as SystemSettingBase;
                    }
                }
            }
            return _instance;
        }

        private MysqlSettingBase _sysMySqlDB = new MysqlSettingBase();
        public MysqlSettingBase SysMySqlDB
        {
            get { return _sysMySqlDB; }
            set { this._sysMySqlDB = value; }
        }

        private MongodbSettingBase _sysMongodb = new MongodbSettingBase();
        public MongodbSettingBase SysMongoDB
        {
            get { return _sysMongodb; }
            set { this._sysMongodb = value; }
        }
    }
}
