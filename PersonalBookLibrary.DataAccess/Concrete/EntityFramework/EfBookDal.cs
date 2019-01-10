﻿using PersonalBookLibrary.Core.DataAccess.EntityFramework;
using PersonalBookLibrary.DataAccess.Abstract;
using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBookLibrary.Entities.ComplexType;

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
                             where b.CategoryID == book.CategoryID
                             select new BookDetail { BookName = c.CategoryName };
                return result.ToList();
            }
        }
    }
}
