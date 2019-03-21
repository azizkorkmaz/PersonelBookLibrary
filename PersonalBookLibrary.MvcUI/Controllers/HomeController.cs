using PersonalBookLibrary.Business.Abstract;
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
            var model = new BookCategoryViewModel();

            model.BookDetailList = _bookService.GetAll();
            foreach (var bookDetail in model.BookDetailList)
            {
                model.BookDetails = bookDetail;

                foreach (var book in bookDetail)
                {
                    model.BookDetail = book;
                }
            }

            return View(model);
        }
    }
}