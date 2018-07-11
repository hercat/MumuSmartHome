using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Mumu.Frameworks.Entity
{
    public class GroupPermission
    {
        public int id { get; set; }
        public Guid gid { get; set; }
        public Guid pid { get; set; }
        public DateTime updatetime { get; set; }
        public bool AllParse(DataRow dr)
        {
            if (dr.Table.Columns.Contains(EnumGroupPermission.id.ToString()))
                id = Int32.Parse(dr[EnumGroupPermission.id.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumGroupPermission.gid.ToString()))
                gid = new Guid(dr[EnumGroupPermission.gid.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumGroupPermission.pid.ToString()))
                pid = new Guid(dr[EnumGroupPermission.pid.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumGroupPermission.updatetime.ToString()))
                updatetime = DateTime.Parse(dr[EnumGroupPermission.updatetime.ToString()].ToString());
            return true;
        }
    }
    enum EnumGroupPermission
    {
        id,
        gid,
        pid,
        updatetime
    }
}
