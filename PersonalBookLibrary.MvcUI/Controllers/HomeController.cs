using PersonalBookLibrary.Business.Abstract;
using PersonalBookLibrary.Entities.ComplexTypes;
using PersonalBookLibrary.MvcUI.Models.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalBookLibrary.MvcUI.Controllers
{
    public class HomeController : Controller
    {
        private IBookService _bookService;

        public HomeController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public ActionResult Index()
        {
            var bookDetail = new BookDetail();
            var bookDetails = _bookService.GetActiveBook();
            foreach (var book in bookDetails)
            {
                bookDetail = _bookService.GetByIdBookDetail(book.BookID);
            }

            var model = new BookCategoryViewModel
            {
                BookDetails = bookDetails,
                BookDetail = bookDetail
            };

            return View(model);
        }
    }
}