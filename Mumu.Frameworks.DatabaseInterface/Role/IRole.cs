using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Mumu.Frameworks.Entity;

namespace Mumu.Frameworks.DatabaseInterface
{
    public interface IRole
    {
        bool AddOrUpdateRoleInfo(IDbCommand idbcmd, RoleInfo info, EnumAddOrUpdate mode);
        bool DeleteRoleInfo(IDbCommand idbcmd, Guid id);
        RoleInfo GetRoleInfoByName(IDbCommand idbcmd, string name);
        RoleInfo GetRoleInfoById(IDbCommand idbcmd, Guid id);
        List<RoleInfo> GetRoleInfoPageList(IDbCommand idbcmd, string fileds, string whereCondition, int startIndex, int pageSize);
    }
}
