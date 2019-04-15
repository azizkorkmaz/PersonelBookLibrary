using PersonalBookLibrary.Entities.ComplexTypes;
using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalBookLibrary.MvcUI.Models.ComplexType
{
    public class LentBookViewModel
    {
        //public List<Book> Books { get; set; }
        //public Book Book { get; set; }
        public List<List<BookDetail>> BookDetailList { get; set; }
        public BookDetail BookDetail { get; set; }
        public LentBookDetail LentBookDetail { get; set; }
        public List<LentBookDetail> LentBookDetails { get; set; }
        public List<List<LentBookDetail>> LentBookDetailList { get; set; }
        public LentBook LentBook { get; set; }
    }
}