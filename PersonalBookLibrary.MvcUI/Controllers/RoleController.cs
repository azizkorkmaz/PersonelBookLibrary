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
    public class RoleController : Controller
    {
        private IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public ActionResult GetList()
        {
            var model = new RoleViewModel
            {
                Roles = _roleService.GetAll()
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Role role)
        {
            if (role != null)
            {
                var model = new RoleViewModel
                {
                    Role = _roleService.Add(role)
                };

                return RedirectToAction("GetList");
            }

            return RedirectToAction("Insert");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var model = new RoleViewModel
            {
                Role = _roleService.GetById(id)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(Role role)
        {
            if (role != null)
            {
                var model = new RoleViewModel
                {
                    Role = _roleService.Update(role)
                };

                return RedirectToAction("GetList");
            }

            return RedirectToAction("Update");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = new RoleViewModel
            {
                Role = _roleService.GetById(id)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(Role role)
        {
            if (role != null)
            {
                role = _roleService.Update(role);

                return RedirectToAction("GetList");
            }

            return RedirectToAction("Delete");
        }

        public ActionResult Detail(int id)
        {
            var model = new RoleViewModel
            {
                Role = _roleService.GetById(id)
            };

            return View(model);
        }
    }
}