using PersonalBookLibrary.Entities.ComplexTypes;
using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAll();

        User GetById(int id);

        User Add(User user, List<int> roleIds);

        User Update(User user, List<int> roleIds);

        User LooseDelete(User user);

        void HardDelete(User user);

        User GetByUserNameAndPassword(string userName, string password);

        List<UserRoleDetail> GetUserRoles(User user);

    }
}
