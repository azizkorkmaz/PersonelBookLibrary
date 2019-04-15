using PersonalBookLibrary.Entities.ComplexTypes;
using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Business.Abstract
{
    public interface ILentBookService
    {
        List<LentBook> GetAll();

        List<List<LentBookDetail>> GetAllLentBookDetail();

        LentBook GetById(int id);

        LentBookDetail GetByIdLentBookDetail(int id);

        LentBook Add(LentBook lentBook);

        LentBook Update(LentBook lentBook);

        LentBook LooseDelete(LentBook lentBook);
    }
}
