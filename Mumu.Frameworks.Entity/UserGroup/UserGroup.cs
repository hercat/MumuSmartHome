using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Mumu.Frameworks.Entity
{
    public class UserGroup
    {
        public int id { get; set; }
        public Guid uid { get; set; }
        public Guid gid { get; set; }
        public DateTime updatetime { get; set; }
        public bool AllParse(DataRow dr)
        {
            if (dr.Table.Columns.Contains(EnumUserGroup.id.ToString()))
                id = Int32.Parse(dr[EnumUserGroup.id.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumUserGroup.uid.ToString()))
                uid = new Guid(dr[EnumUserGroup.uid.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumUserGroup.gid.ToString()))
                gid = new Guid(dr[EnumUserGroup.gid.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumUserGroup.updatetime.ToString()))
                updatetime = DateTime.Parse(dr[EnumUserGroup.updatetime.ToString()].ToString());
            return true;
        }
    }
    enum EnumUserGroup
    {
        id,
        uid,
        gid,
        updatetime
    }
}
