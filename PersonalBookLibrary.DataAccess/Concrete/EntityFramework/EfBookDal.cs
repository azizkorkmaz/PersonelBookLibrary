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
    public class EfBookDal : EfEntityRepositoryBase<Book, PersonalBookLibraryContext>, IBookDal
    {
        public List<BookDetail> GetBookDetail(Book book)
        {
            using (PersonalBookLibraryContext context = new PersonalBookLibraryContext())
            {
                var result = from b in context.Books
                             join c in context.Categories
                             on b.CategoryID equals c.CategoryId
                             where b.BookId == book.BookId
                             select new BookDetail
                             {
                                 CategoryName = c.CategoryName,
                                 AuthorName = b.AuthorName,
                                 BookID = b.BookId,
                                 BookName = b.BookName,
                                 BookSummary = b.BookSummary,
                                 Edition = b.Edition,
                                 PublisherName = b.PublisherName,
                                 InsertDate = b.InsertDate,
                                 InsertUser = b.InsertUser,
                                 UpdateDate = b.UpdateDate,
                                 UpdateUser = b.UpdateUser,
                                 LastUpdated = b.LastUpdated,
                                 Status = b.Status
                             };
                return result.ToList();
            }
        }

        public BookDetail GetBookDetailById(Book book)
        {
            using (PersonalBookLibraryContext context=new PersonalBookLibraryContext())
            {
                var result = from b in context.Books
                             join c in context.Categories
                             on b.CategoryID equals c.CategoryId
                             where b.BookId == book.BookId
                             select new BookDetail
                             {
                                 CategoryName = c.CategoryName,
                                 AuthorName = b.AuthorName,
                                 BookID = b.BookId,
                                 BookName = b.BookName,
                                 BookSummary = b.BookSummary,
                                 Edition = b.Edition,
                                 PublisherName = b.PublisherName,
                                 InsertDate = b.InsertDate,
                                 InsertUser = b.InsertUser,
                                 UpdateDate = b.UpdateDate,
                                 UpdateUser = b.UpdateUser,
                                 LastUpdated = b.LastUpdated,
                                 Status = b.Status
                             };

                return result.FirstOrDefault();
            }
        }
    }
}
