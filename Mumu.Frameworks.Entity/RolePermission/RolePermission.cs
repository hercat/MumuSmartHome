using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Mumu.Frameworks.Entity
{
    public class RolePermission
    {
        public int id { get; set; }
        public Guid rid { get; set; }
        public Guid pid { get; set; }
        public DateTime updatetime { get; set; }
        public bool AllParse(DataRow dr)
        {
            if (dr.Table.Columns.Contains(EnumRolePermission.id.ToString()))
                id = Int32.Parse(dr[EnumRolePermission.id.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumRolePermission.rid.ToString()))
                rid = new Guid(dr[EnumRolePermission.rid.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumRolePermission.pid.ToString()))
                pid = new Guid(dr[EnumRolePermission.pid.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumRolePermission.updatetime.ToString()))
                updatetime = DateTime.Parse(dr[EnumRolePermission.updatetime.ToString()].ToString());
            return true;
        }
    }
    enum EnumRolePermission
    {
        id,
        rid,
        pid,
        updatetime
    }
}
