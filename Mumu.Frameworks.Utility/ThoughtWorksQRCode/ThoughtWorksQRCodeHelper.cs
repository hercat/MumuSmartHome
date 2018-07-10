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

        /// <summary>
        /// 生成二维码方法
        /// </summary>
        /// <param name="context">写入二维码内容</param>
        /// <param name="filename">保存名称</param>
        /// <param name="backgroundColor">二维码背景色</param>
        /// <param name="foregroundColor">二维码前景色</param>
        /// <param name="scale"></param>
        /// <param name="version"></param>
        /// <param name="mode"></param>
        /// <param name="errorcorrection"></param>
        /// <param name="imageFormat"></param>
        /// <returns></returns>
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
                Image image = qrCodeEncoder.Encode(context,Encoding.UTF8);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="filename"></param>
        /// <param name="backgroundColor"></param>
        /// <param name="foregroundColor"></param>
        /// <param name="scale"></param>
        /// <param name="version"></param>
        /// <param name="mode"></param>
        /// <param name="errorcorrection"></param>
        /// <param name="imageFormat"></param>
        /// <param name="logo"></param>
        /// <returns></returns>
        public bool CreateThoughWorksQRCodeWithLogo(string context, string filename, Color backgroundColor, Color foregroundColor, int scale, int version, QRCodeEncoder.ENCODE_MODE mode, QRCodeEncoder.ERROR_CORRECTION errorcorrection, ImageFormat imageFormat, Image logo)
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
                Image image = qrCodeEncoder.Encode(context, Encoding.UTF8);
                Graphics graphics = Graphics.FromImage(image);
                graphics.DrawImage(logo, (image.Width - 120) / 2, (image.Height - 120) / 2, 120, 120);
                FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
                image.Save(fs, imageFormat);
                graphics.Dispose();
            }
            catch (Exception ex)
            {
                log.Error("CreateThoughWorksQRCodeWithLogo()发生错误,错误信息如下:{0}", ex);
            }
            return true;
        }
    }
}
