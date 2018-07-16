using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Mumu.Frameworks.Entity;

namespace Mumu.Frameworks.DatabaseInterface
{
    public interface IRolePermission
    {
        bool AddOrUpdateRolePermissionInfo(IDbCommand idbcmd, RolePermission info, EnumAddOrUpdate mode);
        bool DeleteRolePermissionInfo(IDbCommand idbcmd, Guid id);
        RolePermission GetRolePermissionById(IDbCommand idbcmd, Guid id);
    }
}
