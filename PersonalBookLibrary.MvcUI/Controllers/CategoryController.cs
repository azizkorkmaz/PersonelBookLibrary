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
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult GetList()
        {
            var model = new CategoryViewModel
            {
                Categories = _categoryService.GetAll()
            };
            return View(model);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Category category)
        {
            var model = new CategoryViewModel
            {
                Category = _categoryService.Add(category)
            };

            return RedirectToAction("GetList", "Category");
        }

        public ActionResult Detail(int id)
        {
            var model = new CategoryViewModel
            {
                Category = _categoryService.GetById(id)
            };
            return View(model);
        }

        public ActionResult Update(int id)
        {
            var model = new CategoryViewModel
            {
                Category = _categoryService.GetById(id)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(Category category)
        {
            var model = _categoryService.Update(category);

            return RedirectToAction("GetList");
        }

        public ActionResult Delete(int id)
        {
            var model = new CategoryViewModel
            {
                Category = _categoryService.GetById(id)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(Category category)
        {
            var model = _categoryService.LooseDelete(category);

            return RedirectToAction("GetList");
        }
    }
}