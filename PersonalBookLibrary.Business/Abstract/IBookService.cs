using PersonalBookLibrary.Entities.ComplexTypes;
using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Business.Abstract
{
    public interface IBookService
    {
        List<BookDetail> GetAll();

        List<Book> GetAllBook();

       List<BookDetail> GetActiveBook();

        List<BookDetail> GetBookDetail(Book book);

        BookDetail GetByIdBookDetail(int id);

        Book GetById(int id);

        Book Add(Book book);

        Book Update(Book book);

        Book LooseDelete(Book book);

        void HardDelete(Book book);
    }
}
