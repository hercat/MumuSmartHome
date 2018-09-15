using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumu.Frameworks.Entity
{
    public class GridResult<T>
    {
        public int total { get; private set; }
        public string remark { get; private set; }
        public IEnumerable<T> rows { get; private set; }
        public GridResult(IEnumerable<T> list)
        {
            this.rows = list;
            this.total = rows.Count();
        }
        public GridResult(IEnumerable<T> list, int recCount)
        {
            this.rows = list;
            this.total = recCount;
        }
        public GridResult(IEnumerable<T> list, int recCount, string remark)
        {
            this.rows = list;
            this.total = recCount;
            this.remark = remark;
        }
    }
}
