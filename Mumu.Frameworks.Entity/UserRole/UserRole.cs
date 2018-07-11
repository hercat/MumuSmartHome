using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Mumu.Frameworks.Entity
{
    public class UserRole
    {
        public int id { get; set; }
        public Guid uid { get; set; }
        public Guid rid { get; set; }
        public DateTime updatetime { get; set; }
        public bool AllParse(DataRow dr)
        {
            if (dr.Table.Columns.Contains(EnumUserRole.id.ToString()))
                id = Int32.Parse(dr[EnumUserRole.id.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumUserRole.uid.ToString()))
                uid = new Guid(dr[EnumUserRole.uid.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumUserRole.rid.ToString()))
                rid = new Guid(dr[EnumUserRole.rid.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumUserRole.updatetime.ToString()))
                updatetime = DateTime.Parse(dr[EnumUserRole.updatetime.ToString()].ToString());
            return true;
        }
    }
    enum EnumUserRole
    {
        id,
        uid,
        rid,
        updatetime
    }
}
