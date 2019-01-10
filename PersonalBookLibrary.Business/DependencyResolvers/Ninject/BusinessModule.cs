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

            Bind<IUserService>().To<UserManager>();
            Bind<IUserDal>().To<EfUserDal>();

        }
    }
}
