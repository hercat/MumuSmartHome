using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Mumu.Frameworks.Entity;

namespace Mumu.Frameworks.DatabaseInterface
{
    public interface IUserRole
    {
        bool AddOrUpdateUserRoleInfo(IDbCommand idbcmd, UserRole info, EnumAddOrUpdate mode);
    }
}
