using PersonalBookLibrary.Business.Abstract;
using PersonalBookLibrary.Entities.Concrete;
using PersonalBookLibrary.MvcUI.Models.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalBookLibrary.MvcUI.Controllers
{
    [RoutePrefix("book")]
    public class BookController : Controller
    {
        private IBookService _bookService;
        private ICategoryService _categoryService;

        public BookController(IBookService bookService, ICategoryService categoryService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
        }

        [Route("list")]
        public ActionResult GetList()
        {
            var model = new BookCategoryViewModel
            {
                 BookDetailList=_bookService.GetAll()
            };

            return View(model);
        }

        [HttpGet]
        [Route("insert")]
        public ActionResult Insert()
        {
            var model = new BookCategoryViewModel
            {
                Categories = _categoryService.GetAll()
            };

            return View(model);
        }

        [HttpPost]
        [Route("insert")]
        public ActionResult Insert(Book book)
        {
            var model = new BookCategoryViewModel
            {
                Book = _bookService.Add(book),
                BookDetailList = _bookService.GetAll()
            };

            return RedirectToAction("GetList");
        }

        [Route("update")]
        [HttpGet]
        public ActionResult Update(int id)
        {
            var model = new BookCategoryViewModel
            {
                Book = _bookService.GetById(id),
                Categories = _categoryService.GetAll()
            };

            return View(model);
        }

        [Route("update")]
        [HttpPost]
        public ActionResult Update(Book book)
        {
            var model = new BookCategoryViewModel
            {
                Book = _bookService.Update(book),
                BookDetailList = _bookService.GetAll()
            };

            return RedirectToAction("GetList");
        }

        [HttpGet]
        [Route("delete")]
        public ActionResult Delete(int id)
        {
            var model = new BookCategoryViewModel
            {
                Book = _bookService.GetById(id),
                Categories = _categoryService.GetAll()
            };

            return View(model);
        }

        [HttpPost]
        [Route("delete")]
        public ActionResult Delete(Book book)
        {
            //book.status u false olmuyor 27.01.2019
            var model = new BookCategoryViewModel
            {
                Book = _bookService.Update(book),
                BookDetailList=_bookService.GetAll()
            };

            return View("GetList");
        }

        [Route("detail/{id}")]
        public ActionResult Detail(int id)
        {
            var model = new BookCategoryViewModel
            {
                BookDetailList = _bookService.GetAll(),
                BookDetail = _bookService.GetByIdBookDetail(id)
            };

            return View(model); 
        }
    }
}