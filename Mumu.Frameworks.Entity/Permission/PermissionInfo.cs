using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumu.Frameworks.Entity
{
    public class PermissionInfo
    {

        public Guid id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime updatetime { get; set; }
        public int status { get; set; }

        public bool AllParse(DataRow dr)
        {
            if (dr.Table.Columns.Contains(EnumPermissionInfo.id.ToString()))
                id = new Guid(dr[EnumPermissionInfo.id.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumPermissionInfo.name.ToString()))
                name = dr[EnumPermissionInfo.name.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumPermissionInfo.description.ToString()))
                description = dr[EnumPermissionInfo.description.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumPermissionInfo.updatetime.ToString()))
                updatetime = DateTime.Parse(dr[EnumPermissionInfo.updatetime.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumPermissionInfo.status.ToString()))
                status = Int32.Parse(dr[EnumPermissionInfo.status.ToString()].ToString());
            return true;
        }
    }
    enum EnumPermissionInfo
    {
        id,
        name,
        description,
        updatetime,
        status
    }
}
