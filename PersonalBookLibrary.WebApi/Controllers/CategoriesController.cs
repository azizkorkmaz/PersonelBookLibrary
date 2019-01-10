using PersonalBookLibrary.Business.Abstract;
using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PersonalBookLibrary.WebApi.Controllers
{
    public class CategoriesController : ApiController
    {
        private ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public List<Category> Get()
        {
            return _categoryService.GetAll();
        }
    }
}
