using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Business.ServiceContracts.Wcf
{
    [ServiceContract]
    public interface ICategoryServiceWcf
    {
        [OperationContract]
        List<Category> GetAll();

        [OperationContract]
        Category GetById(int id);

        [OperationContract]
        Category Add(Category category);

        [OperationContract]
        Category Update(Category category);

        [OperationContract]
        void Delete(Category category);

        [OperationContract]
        void TransactionalOperation(Category category1, Category category2);
    }
}
