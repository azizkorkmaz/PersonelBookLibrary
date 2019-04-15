using Ninject.Modules;
using PersonalBookLibrary.Business.Abstract;
using PersonalBookLibrary.Business.Concrete.Managers;
using PersonalBookLibrary.DataAccess.Abstract;
using PersonalBookLibrary.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Business.DependencyResolvers.Ninject
{
    public class BusinessModule:NinjectModule
    {
        public override void Load()
        {
            /*Burada şunu belirtiyoruz, senden ICategoryService isteyene CategoryManager ver.
             * Birde InSingletonScope diyerek her serferinde new lenmesini önleyerek ciddi bir performans artışını sağlıyoruz.*/
            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();

            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope();

            Bind<IRoleService>().To<RoleManager>().InSingletonScope();
            Bind<IRoleDal>().To<EfRoleDal>().InSingletonScope();

            Bind<IUserRoleService>().To<UserRoleManager>().InSingletonScope();
            Bind<IUserRoleDal>().To<EfUserRoleDal>().InSingletonScope();

            Bind<IBookService>().To<BookManager>().InSingletonScope();
            Bind<IBookDal>().To<EfBookDal>().InSingletonScope();

            Bind<IUserRolesTransactionService>().To<UserRolesTransactionManager>().InSingletonScope();

            Bind<IReadBookService>().To<ReadBookManager>().InSingletonScope();
            Bind<IReadBookDal>().To<EfReadBookDal>().InSingletonScope();

            Bind<ILentBookService>().To<LentBookManager>().InSingletonScope();
            Bind<ILentBookDal>().To<EfLentBookDal>().InSingletonScope();

        }
    }
}
