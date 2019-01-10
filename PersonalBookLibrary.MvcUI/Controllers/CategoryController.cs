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
            var model = new CategoryListViewModel
            {
                Categorys = _categoryService.GetAll()
            };
            return View(model);
        }

       

        

    }
}