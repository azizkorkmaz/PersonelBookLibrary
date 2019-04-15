using PersonalBookLibrary.Core.DataAccess.EntityFramework;
using PersonalBookLibrary.DataAccess.Abstract;
using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBookLibrary.Entities.ComplexTypes;

namespace PersonalBookLibrary.DataAccess.Concrete.EntityFramework
{
    public class EfLentBookDal : EfEntityRepositoryBase<LentBook, PersonalBookLibraryContext>, ILentBookDal
    {
        public LentBookDetail GetByIdLentBookDetail(int id)
        {
            using (PersonalBookLibraryContext context = new PersonalBookLibraryContext())
            {
                var result = from lb in context.LentBooks
                             join b in context.Books
                             on lb.BookID equals b.BookId
                             where lb.LentBookId == id
                             select new LentBookDetail
                             {
                                 LentBookID = id,
                                 BookID = b.BookId,
                                 BookName = b.BookName,
                                 AuthorName = b.AuthorName,
                                 BorrowPersonName = lb.BorrowPersonName,
                                 BorrowPersonLastName = lb.BorrowPersonLastName,
                                 GivenUserName = lb.GivenUserName,
                                 GivenDate = lb.GivenDate,
                                 Status = lb.Status,
                                 UndoDate = lb.UndoDate
                             };

                return result.FirstOrDefault();  //burası nasıl çevirmek lazım
            }
        }

        public List<LentBookDetail> GetLentBookDetail(LentBook lentBook)
        {
            using (PersonalBookLibraryContext context = new PersonalBookLibraryContext())
            {
                var result = from b in context.Books
                             join c in context.Categories
                             on b.CategoryID equals c.CategoryId
                             where lentBook.BookID == b.BookId
                             select new LentBookDetail
                             {
                                 LentBookID = lentBook.LentBookId,
                                 BookID = b.BookId,
                                 BookName = b.BookName,
                                 AuthorName = b.AuthorName,
                                 CategoryName = c.CategoryName,
                                 BookSummary = b.BookSummary,
                                 BorrowPersonName = lentBook.BorrowPersonName,
                                 BorrowPersonLastName = lentBook.BorrowPersonLastName,
                                 GivenUserName = lentBook.GivenUserName,
                                 GivenDate = lentBook.GivenDate,
                                 Status = lentBook.Status

                             };

                return result.ToList();
            }
        }
    }
}
