using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Business.Abstract
{
    public interface IUserRoleService
    {
        List<UserRole> GetAll();

        UserRole GetById(int id);

        UserRole Add(int userId, int roleId);

        UserRole LooseDelete(UserRole userRole);

        void HardDelete(UserRole userRole);
    }
}
