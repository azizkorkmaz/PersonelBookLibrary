using PersonalBookLibrary.Entities.ComplexTypes;
using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Business.Abstract
{
    public interface IUserRolesTransactionService
    {
        UserRolesList AddUserRolesTransaction(User user, List<int> userRoleIds);

        UserRolesList UpdateUserRolesTransaction(User user, List<int> userRoleIds);

        UserRolesList LooseDeleteUserRolesTransaction(User user, List<int> userRoleIds);

        void HardDeleteUserRolesTransaction(User user, List<int> userRoleIds);

        UserRolesList GetAllUserRolesTransaction();

        UserRolesList GetByIdUserRolesTransaction(int id);
    }
}
