using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;
using log4net;

namespace Mumu.Frameworks.Utility
{
    /// <summary>
    /// Description:配置基类进行配置信息存取
    /// Author:WUWEI
    /// Date:2018/07/09
    /// </summary>
    public class SettingBase
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private string m_filename;
        public string FileName
        {
            get { return m_filename; }
            set { m_filename = value; }
        }

        private string m_formatVersion;
        public string FormatVersion
        {
            get { return m_formatVersion; }
            set { m_formatVersion = value; }
        }

        public static string DefaultLocation(LocationType locationType)
        {
            switch (locationType)
            {
                case LocationType.UserLocal:
                    return Application.LocalUserAppDataPath;
                case LocationType.UserCommon:
                    return Application.CommonAppDataPath;
                case LocationType.Application:
                    return AppDomain.CurrentDomain.BaseDirectory;
                default:
                    break;
            }
            return null;
        }

        public string DefaultName()
        {
            return string.Format("{0}.xml", "MumuSmartHome.Default.SysSettingBase");
        }

        public SettingBase()
        {
            m_formatVersion = Application.ProductVersion;
        }

        public virtual void Save(string filename)
        {
            XmlSerializer serializer = null;
            try
            {
                serializer = new XmlSerializer(this.GetType());
                using (TextWriter textWriter = new StreamWriter(filename))
                    serializer.Serialize(textWriter, this);
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Saving settings class '{0}' to {1} failed.Exception info as fellowing:{2}", this.GetType().ToString(), filename, ex));
            }
        }

        public virtual void Save()
        {
            Save(m_filename);
        }

        public static SettingBase Load(SettingBase defaultSetttings, string filename)
        {
            defaultSetttings.m_filename = filename;
            if (!File.Exists(filename))
                return defaultSetttings;
            SettingBase settings = defaultSetttings;
            try
            {
                XmlSerializer serializer = new XmlSerializer(defaultSetttings.GetType());
                using (TextReader reader = new StreamReader(filename))
                {
                    settings = (SettingBase)serializer.Deserialize(reader);
                    settings.m_filename = filename;
                }
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Loading settings from file '{1}' to {0} failed.", defaultSetttings.GetType().ToString(), filename));
            }
            if (File.Exists(filename + ".tmp"))
                File.Delete(filename + ".tmp");
            return settings;
        }

        public static SettingBase LoadFromPath(SettingBase defaultSettings, string path)
        {
            string filename = Path.Combine(path, defaultSettings.DefaultName());
            return Load(defaultSettings, filename);
        }

        public static SettingBase Load(SettingBase defaultSettings, LocationType locationType, string name)
        {
            string filename = Path.Combine(DefaultLocation(locationType), name);
            return Load(defaultSettings, filename);
        }

        public static SettingBase Load(SettingBase defaultSettings, LocationType locationType)
        {
            return Load(defaultSettings, locationType, defaultSettings.DefaultName());
        }

        public string SettingsFilePath
        {
            get { return m_filename; }
        }
    }

    public enum LocationType
    {
        UserLocal,
        UserCommon,
        Application
    }
}
