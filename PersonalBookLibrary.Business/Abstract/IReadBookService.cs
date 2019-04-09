using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Business.Abstract
{
    public interface IReadBookService
    {
        List<ReadBook> GetAll();

        ReadBook GetById(int id);

        ReadBook Add(ReadBook readBook);

        ReadBook Update(ReadBook readBook);

        void HardDelete(ReadBook readBook);
    }
}
