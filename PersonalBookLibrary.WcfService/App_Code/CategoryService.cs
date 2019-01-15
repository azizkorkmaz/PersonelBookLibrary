using PersonalBookLibrary.Business.ServiceContracts.Wcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonalBookLibrary.Entities.Concrete;
using PersonalBookLibrary.Business.DependencyResolvers.Ninject;

/// <summary>
/// Summary description for CategoryService
/// </summary>
public class CategoryService:ICategoryServiceWcf
{
    public CategoryService()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private ICategoryServiceWcf _categoryServiceWcf = 
        InstanceFactory.GetInstance<ICategoryServiceWcf>();


    public Category Add(Category category)
    {
        return _categoryServiceWcf.Add(category);
    }

    public List<Category> GetAll()
    {
        return _categoryServiceWcf.GetAll();
    }

    public Category GetById(int id)
    {
        return _categoryServiceWcf.GetById(id);
    }

    public void TransactionalOperation(Category category1, Category category2)
    {
        _categoryServiceWcf.TransactionalOperation(category1, category2);
    }

    public Category Update(Category category)
    {
        return _categoryServiceWcf.Update(category);
    }

    public void Delete(Category category)
    {
        _categoryServiceWcf.Delete(category);
    }
}