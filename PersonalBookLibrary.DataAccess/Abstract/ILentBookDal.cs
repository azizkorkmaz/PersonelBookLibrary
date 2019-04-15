using PersonalBookLibrary.Core.DataAccess;
using PersonalBookLibrary.Entities.ComplexTypes;
using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.DataAccess.Abstract
{
    public interface ILentBookDal: IEntityRepository<LentBook>
    {
        List<LentBookDetail> GetLentBookDetail(LentBook lentBook);
        LentBookDetail GetByIdLentBookDetail(int id);
    }
}
