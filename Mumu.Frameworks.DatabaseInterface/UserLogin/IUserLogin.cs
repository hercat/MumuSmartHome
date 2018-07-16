using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Mumu.Frameworks.Entity;

namespace Mumu.Frameworks.DatabaseInterface
{
    public interface IUserLogin
    {
        bool AddOrUpdateUserLoginInfo(IDbCommand idbcmd, UserLogin info, EnumAddOrUpdate mode);
        bool DeleteUserLoginInfo(IDbCommand idbcmd, Guid id);        
    }
}
