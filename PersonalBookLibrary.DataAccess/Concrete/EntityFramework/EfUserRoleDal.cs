using PersonalBookLibrary.Core.DataAccess.EntityFramework;
using PersonalBookLibrary.DataAccess.Abstract;
using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.DataAccess.Concrete.EntityFramework
{
    public class EfUserRoleDal: EfEntityRepositoryBase<UserRole, PersonalBookLibraryContext>,
        IUserRoleDal
    {
    }
}
