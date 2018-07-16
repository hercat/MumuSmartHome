using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Mumu.Frameworks.Entity;

namespace Mumu.Frameworks.DatabaseInterface
{
    public interface IGroupPermission
    {
        bool AddOrUpdateGroupPermissionInfo(IDbCommand idbcmd, GroupPermission info, EnumAddOrUpdate mode);
        bool DeleteGroupPermissionInfo(IDbCommand idbcmd, Guid id);
        GroupPermission GetGroupPermissionInfoById(IDbCommand idbcmd, Guid id);
        List<GroupPermission> GetGroupPermissionInfoByGid(IDbCommand idbcmd, Guid gid);
    }
}
