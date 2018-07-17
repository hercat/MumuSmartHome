using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Mumu.Frameworks.Entity;

namespace Mumu.Frameworks.DatabaseInterface
{
    public interface IUserPermission
    {
        bool AddOrUpdateUserPermissionInfo(IDbCommand idbcmd, UserPermission info, EnumAddOrUpdate mode);
        bool DeleteUserPermissionInfo(IDbCommand idbcmd, Guid id);
        UserPermission GetUserPermissionInfoById(IDbCommand idbcmd, Guid id);
        List<UserPermission> GetUserPermissionInfoByUid(IDbCommand idbcmd, Guid uid);
    }
}
