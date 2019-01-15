using PersonalBookLibrary.Business.ServiceContracts.Wcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonalBookLibrary.Entities.Concrete;
using PersonalBookLibrary.Business.Abstract;
using PersonalBookLibrary.Business.DependencyResolvers.Ninject;

/// <summary>
/// Summary description for CategoryDetailService
/// </summary>
public class CategoryDetailService:ICategoryDetailServiceWcf
{
    /*burada sistemin tamamını servislere bağlı olarak değilde bir kısmını dış dünyaya açamak için uygaldığımız yöntem.*/
    PersonalBookLibrary.Business.Abstract.ICategoryService _categoryServiceWcf = InstanceFactory.GetInstance<PersonalBookLibrary.Business.Abstract.ICategoryService>();

    public List<Category> GetAll()
    {
        return _categoryServiceWcf.GetAll();
    }
}