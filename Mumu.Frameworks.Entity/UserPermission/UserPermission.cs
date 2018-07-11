using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Mumu.Frameworks.Entity
{
    public class UserPermission
    {
        public int id { get; set; }
        public Guid uid { get; set; }
        public Guid pid { get; set; }
        public DateTime updatetime { get; set; }
        public bool AllParse(DataRow dr)
        {
            if (dr.Table.Columns.Contains(EnumUserPermission.id.ToString()))
                id = Int32.Parse(dr[EnumUserPermission.id.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumUserPermission.uid.ToString()))
                uid = new Guid(dr[EnumUserPermission.uid.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumUserPermission.pid.ToString()))
                pid = new Guid(dr[EnumUserPermission.pid.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumUserPermission.updatetime.ToString()))
                updatetime = DateTime.Parse(dr[EnumUserPermission.updatetime.ToString()].ToString());
            return true;
        }
    }
    enum EnumUserPermission
    {
        id,
        uid,
        pid,
        updatetime
    }
}
