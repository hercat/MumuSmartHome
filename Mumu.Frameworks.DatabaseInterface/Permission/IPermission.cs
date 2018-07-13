using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mumu.Frameworks.Entity;
using System.Data;

namespace Mumu.Frameworks.DatabaseInterface
{
    public interface IPermission
    {
        bool AddOrUpdatePermission(IDbCommand idbcmd, PermissionInfo info, EnumAddOrUpdate mode);
        bool DeletePermissionInfo(IDbCommand idbcmd, Guid id);
    }
}
