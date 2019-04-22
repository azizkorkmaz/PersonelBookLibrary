using PersonalBookLibrary.Business.Abstract;
using PersonalBookLibrary.MvcUI.Models.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalBookLibrary.MvcUI.Controllers
{
    public class UndoBookController : Controller
    {
        private IBookService _bookService;
        private ILentBookService _lentBookService;

        public UndoBookController(IBookService bookService, ILentBookService lentBookService)
        {
            _bookService = bookService;
            _lentBookService = lentBookService;
        }

        [HttpGet]
        public ActionResult UndoBookList()
        {
            var model = new LentBookViewModel
            {
                LentBookDetails=_lentBookService.GetAllActiveLentBookDetail()
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult UndoBook(int id)
        {
            var model = new LentBookViewModel
            {
                LentBookDetail = _lentBookService.GetByIdLentBookDetail(id),
                LentBook=_lentBookService.GetById(id)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult UndoBook(LentBookViewModel form)
        {
            var model = new LentBookViewModel
            {
                LentBook = _lentBookService.UndoBook(form.LentBook)
            };

            return View("UndoBookList");
        }

        [HttpGet]
        public ActionResult UndoBookDetail(int id)
        {
            var lentBook = _lentBookService.GetById(id);
            var model = new LentBookViewModel
            {
                LentBookDetail = _lentBookService.GetByIdLentBookDetail(id),
                LentBook = lentBook,
                BookDetail = _bookService.GetByIdBookDetail(lentBook.BookID)
            };

            return View(model);
        }
    }
}