using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mumu.Frameworks.Entity;
using System.Data;

namespace Mumu.Frameworks.DatabaseInterface
{
    public interface IGroup
    {
        bool AddOrUpdateGroupInfo(IDbCommand idbcmd, GroupInfo info, EnumAddOrUpdate mode);
        bool DeleteGroupInfo(IDbCommand idbcmd, Guid id);
        GroupInfo GetGroupInfoByName(IDbCommand idbcmd, string name);
        GroupInfo GetGroupInfoById(IDbCommand idbcmd, Guid id);
        List<GroupInfo> GetGroupInfoListAll(IDbCommand idbcmd, string fields, string whereCondition);
        List<GroupInfo> GetGroupInfoPageList(IDbCommand idbcmd, string fileds, string whereCondition, string orderby,string limit);        
    }
}
