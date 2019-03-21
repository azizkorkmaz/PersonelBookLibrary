using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        
        Category GetById(int id);

        Category Add(Category category);

        Category Update(Category category);

        Category LooseDelete(Category category);

        void HardDelete(Category category);

        void TransactionalOperation(Category category1, Category category2);
    }
}
