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
        List<List<LentBook>> GetAll();

        List<LentBook> GetLentBook(LentBook lentBook);

        LentBook GetByIdLentBook(int id);

        LentBook GetById(int id);

        LentBook Add(LentBook lentBook);

        LentBook Update(LentBook lentBook);

        LentBook LooseDelete(LentBook lentBook);

        void HardDelete(LentBook lentBook);
    }
}
