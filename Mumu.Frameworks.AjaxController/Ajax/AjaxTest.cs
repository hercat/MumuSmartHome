using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMVC;

namespace Mumu.Frameworks.AjaxController
{
    public class AjaxTest
    {
        [Action]
        public object Hello()
        {
            var obj = "这是一个测试方法！";
            return new JsonResult(obj);
        }
    }
}
