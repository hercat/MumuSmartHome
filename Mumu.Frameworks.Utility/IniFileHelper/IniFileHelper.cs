using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;

namespace Mumu.Frameworks.Utility
{
    /// <summary>
    /// Description:.ini文件操作帮助类
    /// Author:WUWEI
    /// Date:2018/07/09
    /// </summary>
    public class IniFileHelper
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #region 单例模式
        private static IniFileHelper _instance = null;
        private static object locker = new object();
        private IniFileHelper() { }
        public static IniFileHelper CreateInstance()
        {
            if (null == _instance)
            {
                lock (locker)
                {
                    if (null == _instance)
                    {
                        _instance = new IniFileHelper();
                    }
                }
            }
            return _instance;
        }
        #endregion

        public T ReadConfigurationValue<T>(string section, string key, string iniPath)
        {
            try
            {
                if (File.Exists(iniPath))
                {
                    IniFile ini = new IniFile(iniPath);
                    string value = ini.ReadContentValue(section, key);
                    if (string.IsNullOrWhiteSpace(value))
                        return default(T);
                    if (typeof(T).IsEnum)
                        return (T)Enum.Parse(typeof(T), value, true);
                    return (T)Convert.ChangeType(value, typeof(T));
                }
                else
                    return default(T);
            }
            catch (Exception ex)
            {
                log.Error(string.Format("出现异常,异常信息如下:{0}", ex));                
            }
            return default(T);
        }

        public bool WriteConfigurationValue(string section, string key, string value, string iniPath)
        {
            bool ret = false;
            if (!File.Exists(iniPath))
            {
                using (FileStream stream = new FileStream(iniPath, FileMode.Create)) { }
            }
            IniFile ini = new IniFile(iniPath);
            ret = ini.WriteContentValue(section, key, value);
            return ret;
        }
    }

    public class IniFile
    {
        private string iniPath;
        public IniFile() { }
        public IniFile(string path)
        {
            this.iniPath = path;
        }
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string value, string path);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retValue, int size, string path);
        public bool WriteContentValue(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, this.iniPath);
            return true;
        }
        public string ReadContentValue(string section, string key)
        {
            StringBuilder sb = new StringBuilder();
            GetPrivateProfileString(section, key, "", sb, 1024, this.iniPath);
            return sb.ToString();
        }
    }
}
