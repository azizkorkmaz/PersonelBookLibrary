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
    public interface ICategoryDetailService
    {
        [OperationContract]
        List<Category> GetAll();
    }
}
