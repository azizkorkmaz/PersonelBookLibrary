using PersonalBookLibrary.Business.Abstract;
using PersonalBookLibrary.Entities.Concrete;
using PersonalBookLibrary.MvcUI.Models;
using PersonalBookLibrary.MvcUI.Models.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalBookLibrary.MvcUI.Controllers
{
    public class LentBookController : Controller
    {
        private ILentBookService _lentBookService;
        private IBookService _bookService;

        public LentBookController(ILentBookService lentBookService,
            IBookService bookService)
        {
            _lentBookService = lentBookService;
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult BookList()
        {
            var model = new LentBookViewModel
            {
                BookDetails = _bookService.GetActiveBook().ToList()
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult BookDetail(int id)
        {
            var model = new LentBookViewModel
            {
                BookDetail = _bookService.GetByIdBookDetail(id)
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Insert(int id)
        {
            var model = new LentBookViewModel
            {
                BookDetail = _bookService.GetByIdBookDetail(id)//burdan çektiğimiz kitap adlarını viewe aktarmalıyız.
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Insert(LentBookViewModel form)
        {
            form.LentBook.BookID = form.BookDetail.BookID;

            var createdModel = _lentBookService.Add(form.LentBook);
            form.LentBook = createdModel;
            return RedirectToAction("BookList");
        }

        [HttpGet]
        public ActionResult GetList()
        {
            var model = new LentBookViewModel
            {
                LentBookDetails = _lentBookService.GetAllLentBookDetail()
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var model = new LentBookViewModel
            {
                LentBookDetail = _lentBookService.GetByIdLentBookDetail(id),
                LentBook = _lentBookService.GetById(id)
            };

            return View(model);
        }
        
        [HttpPost]
        public ActionResult Update(LentBookViewModel form)
        {
            var model = new LentBookViewModel
            {
                LentBook=_lentBookService.Update(form.LentBook)
            };

            return RedirectToAction("GetList");
        }

        [HttpGet]
        public ActionResult LentBookDetail(int id)
        {
            var lentBook = _lentBookService.GetById(id);
            var model = new LentBookViewModel
            {
                LentBookDetail = _lentBookService.GetByIdLentBookDetail(id),
                LentBook = lentBook,
                BookDetail=_bookService.GetByIdBookDetail(lentBook.BookID)
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = new LentBookViewModel
            {
                LentBook=_lentBookService.GetById(id),
                LentBookDetail=_lentBookService.GetByIdLentBookDetail(id)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(LentBookViewModel form)
        {
            var lentBook = form.LentBook;
            var model = new LentBookViewModel
            {
                 LentBook=_lentBookService.LooseDelete(lentBook)
            };

            return View("GetList");
        }
    }
}