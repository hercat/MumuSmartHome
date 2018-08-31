using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Reflection;
using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using System.IO;
using System.Drawing;

namespace Mumu.Frameworks.Utility
{
    public class ImageProcessorHelper
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #region 单例模式
        private static ImageProcessorHelper _instance = null;
        private static object locker = new object();
        private ImageProcessorHelper() { }
        public static ImageProcessorHelper CreateInstance()
        {
            if (null == _instance)
            {
                lock (locker)
                {
                    if (null == _instance)                    
                        _instance = new ImageProcessorHelper();                    
                }
            }
            return _instance;
        }
        #endregion

        public static void SaveOnOtherFormat(string sourceName, string targetName, JpegFormat format)
        {
            byte[] photoBytes = File.ReadAllBytes(sourceName);
            
        }
    }
}
