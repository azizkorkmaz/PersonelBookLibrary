using PersonalBookLibrary.Core.DataAccess.EntityFramework;
using PersonalBookLibrary.DataAccess.Abstract;
using PersonalBookLibrary.Entities.ComplexType;
using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal: EfEntityRepositoryBase<User,PersonalBookLibraryContext>, IUserDal 
    {
        public List<UserRoleItem> GetUserRoles(User user)
        {
            using (PersonalBookLibraryContext context = new PersonalBookLibraryContext())
            {
                var result = from r in context.Roles
                             join ur in context.UserRoles
                             on r.RoleId equals ur.RoleID
                             where ur.UserID == user.UserId
                             select new UserRoleItem { RoleName = r.RoleName };

                return result.ToList();
            }
        }
    }
}
