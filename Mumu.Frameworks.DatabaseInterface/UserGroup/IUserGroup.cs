using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Mumu.Frameworks.Entity;

namespace Mumu.Frameworks.DatabaseInterface
{
    public interface IUserGroup
    {
        bool AddOrUpdateUserGroupInfo(IDbCommand idbcmd, UserGroup info, EnumAddOrUpdate mode);
        bool DeleteUserGroupInfo(IDbCommand idbcmd, Guid id);
        UserGroup GetUserGroupById()
    }
}
