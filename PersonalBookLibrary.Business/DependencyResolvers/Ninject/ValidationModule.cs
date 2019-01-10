using FluentValidation;
using Ninject.Modules;
using PersonalBookLibrary.Business.ValidationRules.FluentValidation;
using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Business.DependencyResolvers.Ninject
{
    public class ValidationModule:NinjectModule
    {
        /*Client side vlidation için yazıyoruz.*/
        public override void Load()
        {
            Bind<IValidator<Category>>().To<CategoryValidator>().InSingletonScope();
        }
    }
}
