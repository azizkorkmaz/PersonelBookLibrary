using Ninject;
using PersonalBookLibrary.Business.DependencyResolvers.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Business.DependencyResolvers.Ninject
{
    public class InstanceFactory
    {
        public static T GetInstance<T>()
        {
            /*Burada T tipinde gelen her nesnenin bir instance nı üret diyoruz.*/
            var kernel = new StandardKernel(new BusinessModule(),new AutoMapperModule());
            return kernel.Get<T>();
        }
    }
}
