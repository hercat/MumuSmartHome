using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Mumu.Frameworks.Entity
{
    public class GroupInfo
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime updatetime { get; set; }
        public int status { get; set; }

        public bool AllParse(DataRow dr)
        {
            if (dr.Table.Columns.Contains(EnumGroupInfo.id.ToString()))
                id = new Guid(dr[EnumGroupInfo.id.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumGroupInfo.name.ToString()))
                name = dr[EnumGroupInfo.name.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumGroupInfo.description.ToString()))
                description = dr[EnumGroupInfo.description.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumGroupInfo.updatetime.ToString()))
                updatetime = DateTime.Parse(dr[EnumGroupInfo.updatetime.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumGroupInfo.status.ToString()))
                status = Int32.Parse(dr[EnumGroupInfo.status.ToString()].ToString());
            return true;
        }
    }
    enum EnumGroupInfo
    {
        id,
        name,
        description,
        updatetime,
        status
    }
}
