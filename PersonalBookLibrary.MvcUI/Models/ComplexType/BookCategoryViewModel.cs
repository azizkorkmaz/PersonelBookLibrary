using PersonalBookLibrary.Entities.ComplexTypes;
using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalBookLibrary.MvcUI.Models.ComplexType
{
    public class BookCategoryViewModel
    {
        public Book Book { get; set; }
        public List<Book> Books { get; set; }
        public Category Category { get; set; }
        public List<Category> Categories { get; set; }
        public BookDetail BookDetail { get; set; }
        public List<BookDetail> BookDetails { get; set; }
    }
}