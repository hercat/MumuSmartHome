using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mumu.Frameworks.Entity
{
    public class RoleInfo
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime updatetime { get; set; }
        public int status { get; set; }
        public bool AllParse(DataRow dr)
        {
            if (dr.Table.Columns.Contains(EnumRoleInfo.id.ToString()))
                id = new Guid(dr[EnumRoleInfo.id.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumRoleInfo.name.ToString()))
                name = dr[EnumRoleInfo.name.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumRoleInfo.description.ToString()))
                description = dr[EnumRoleInfo.description.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumRoleInfo.updatetime.ToString()))
                updatetime = DateTime.Parse(dr[EnumRoleInfo.updatetime.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumRoleInfo.status.ToString()))
                status = Int32.Parse(dr[EnumRoleInfo.status.ToString()].ToString());
            return true;
        }
    }
    enum EnumRoleInfo
    {
        id,
        name,
        description,
        updatetime,
        status
    }
}
