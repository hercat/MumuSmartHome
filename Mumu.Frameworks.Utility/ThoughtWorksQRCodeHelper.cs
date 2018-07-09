using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ThoughtWorks.QRCode;
using log4net;
using System.Drawing;
using ThoughtWorks.QRCode.Codec;
using System.IO;
using System.Drawing.Imaging;

namespace Mumu.Frameworks.Utility
{
    /// <summary>
    /// Description:ThoughtWorksQRCode二维码帮助类
    /// Author:WUWEI
    /// Date:2018/07/09
    /// </summary>
    public class ThoughtWorksQRCodeHelper
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #region 单例模式
        private static ThoughtWorksQRCodeHelper _instance = null;
        private static object locker = new object();
        private ThoughtWorksQRCodeHelper() { }
        public static ThoughtWorksQRCodeHelper CreateInstance()
        {
            if(null==_instance)
            {
                lock (locker)
                {
                    if (null == _instance)
                    {
                        _instance = new ThoughtWorksQRCodeHelper();
                    }
                }
            }
            return _instance;
        }
        #endregion

        public bool CreateThoughWorksQRCode(string context, string filename, Color backgroundColor, Color foregroundColor, int scale, int version, QRCodeEncoder.ENCODE_MODE mode, QRCodeEncoder.ERROR_CORRECTION errorcorrection,ImageFormat imageFormat)
        {            
            try
            {                
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeBackgroundColor = backgroundColor;
                qrCodeEncoder.QRCodeForegroundColor = foregroundColor;
                qrCodeEncoder.QRCodeScale = scale;
                qrCodeEncoder.QRCodeVersion = version;
                qrCodeEncoder.QRCodeEncodeMode = mode;
                qrCodeEncoder.QRCodeErrorCorrect = errorcorrection;
                Image image = qrCodeEncoder.Encode(context);
                FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
                image.Save(fs, imageFormat);
                fs.Close();
                image.Dispose();
            }
            catch (Exception ex)
            {
                log.Error("CreateThoughWorksQRCode()发生错误,错误信息如下:{0}", ex);
            }
            return true;
        }
    }
}
