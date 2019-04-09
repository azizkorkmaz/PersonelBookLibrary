using PersonalBookLibrary.Business.Abstract;
using PersonalBookLibrary.Entities.Concrete;
using PersonalBookLibrary.MvcUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalBookLibrary.MvcUI.Controllers
{
    public class ReadBookController : Controller
    {
        private IReadBookService _readBookService;

        public ReadBookController(IReadBookService readBookService)
        {
            _readBookService = readBookService;
        }

        public ActionResult GetList()
        {
            var model = new ReadBookViewModel
            {
                ReadBooks = _readBookService.GetAll()
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(ReadBook readBook)
        {
            var model = new ReadBookViewModel
            {
                ReadBook = _readBookService.Add(readBook)
            };

            return RedirectToAction("GetList");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var model = new ReadBookViewModel
            {
                ReadBook = _readBookService.GetById(id)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(ReadBook readBook)
        {
            var model = new ReadBookViewModel
            {
                ReadBook = _readBookService.Update(readBook)
            };

            return RedirectToAction("GetList");
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var model = new ReadBookViewModel
            {
                ReadBook = _readBookService.GetById(id)
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = new ReadBookViewModel
            {
                ReadBook = _readBookService.GetById(id)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(ReadBook readBook)
        {
            _readBookService.HardDelete(readBook);

            return RedirectToAction("GetList");
        }
    }
}