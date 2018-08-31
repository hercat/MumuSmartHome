using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Reflection;
using iTextSharp.text;

namespace Mumu.Frameworks.Utility
{
    public class ItextSharpPdfHelper
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #region 单例模式
        private static ItextSharpPdfHelper _instance = null;
        private static object locker = new object();
        private ItextSharpPdfHelper() { }
        public ItextSharpPdfHelper CreateInstance()
        {
            if (_instance == null)
            {
                lock (locker)
                {
                    if (_instance == null)
                    {
                        _instance = new ItextSharpPdfHelper();
                    }
                }
            }
            return _instance;
        }
        #endregion
               
    }
}
