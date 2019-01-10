using PersonalBookLibrary.Core.DataAccess;
using PersonalBookLibrary.Entities.ComplexType;
using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.DataAccess.Abstract
{
    public interface IBookDal : IEntityRepository<Book>
    {
        List<BookDetail> GetBookDetail(Book book);
    }
}
