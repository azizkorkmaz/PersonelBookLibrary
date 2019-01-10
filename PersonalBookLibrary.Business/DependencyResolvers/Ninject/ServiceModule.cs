using Ninject.Modules;
using PersonalBookLibrary.Business.Abstract;
using PersonalBookLibrary.Core.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Business.DependencyResolvers.Ninject
{
    public class ServiceModule:NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryService>().ToConstant(WcfProxy<ICategoryService>.CreateChannel());
        }
    }
}
