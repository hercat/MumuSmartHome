using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Mumu.Frameworks.Utility
{
    /// <summary>
    /// Description:常用正则表达式帮助类
    /// Author:WUWEI
    /// Date:2018/09/30
    /// </summary>
    public class RegexMatchHelper
    {
        /// <summary>
        /// 邮箱有效性验证
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool RegexEmailAddressMatch(string email)
        {
            Regex reg = new Regex(@"^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+(\.[a-zA-Z0-9-]+)*\.[a-zA-Z0-9]{2,6}$");
            if (reg.IsMatch(email))
                return true;
            else
                return false;
        }
    }
}
