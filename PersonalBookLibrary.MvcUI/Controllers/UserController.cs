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
    public class UserController : Controller
    {
        private IUserService _userService;
        private IRoleService _roleService;
        private IUserRoleService _userRoleService;
        private IUserRolesTransactionService _userRolesTransactionService;

        public UserController(IUserService userService, IRoleService roleService, IUserRoleService userRoleService, IUserRolesTransactionService userRolesTransactionService)
        {
            _userService = userService;
            _roleService = roleService;
            _userRoleService = userRoleService;
            _userRolesTransactionService = userRolesTransactionService;
        }

        public ActionResult GetList()
        {
            var model = new UserRolesViewModel
            {
                Users = _userService.GetAll()
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Insert()
        {
            var model = new UserRolesViewModel
            {
                Roles = _roleService.GetAll()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Insert(UserRolesViewModel model)
        {
            if (model != null)
            {
                model = new UserRolesViewModel
                {
                    User = _userService.Add(model.User, model.UserRoleIds)
                };

                if (model.User.UserId == 0)
                {
                    ViewBag.message = "Bu kullanıcı adına sahip kullanıcı mevcut. Başka kullanıcı adı giriniz!";
                    return RedirectToAction("Insert");
                }

                ViewBag.message = "Yeni kullanıcı ekleme işlemi başarılı";
                return RedirectToAction("GetList");
            }
            else
            {
                ViewBag.message = "Formun gerekli kısımlarını doldurunuz!";

                return RedirectToAction("Insert"); 
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var model = new UserRolesViewModel
            {
                User = _userService.GetById(id),
                Roles = _roleService.GetAll(),
                UserRoleIds = _userRoleService.GetAll().Where(ur => ur.UserID == id).Select(r => r.UserRolesId).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(UserRolesViewModel model)
        {
            if (model != null)
            {
                model = new UserRolesViewModel
                {
                    User = _userService.Update(model.User, model.UserRoleIds)
                };

                return RedirectToAction("GetList", "User");
            }
            else
            {
                return RedirectToAction("Update", "User");
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var user = _userService.GetById(id);

                var model = new UserRolesViewModel
                {
                    User = user,
                    UserRoles = _userRoleService.GetAll().Where(ur => ur.UserID == id).ToList(),
                    UserRoleDetails = _userService.GetUserRoles(user)
                };

                return View(model);
            }

            return View("GetList");

        }

        [HttpPost]
        public ActionResult Delete(UserRolesViewModel model)
        {
            if (model != null)
            {
                model = new UserRolesViewModel
                {
                    User = _userService.LooseDelete(model.User)
                };

                return RedirectToAction("GetList", "User");
            }

            return RedirectToAction("GetList", "User");
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            if (id > 0)
            {
                var user = _userService.GetById(id);

                var model = new UserRolesViewModel
                {
                    User = user,
                    UserRoleDetails = _userService.GetUserRoles(user)
                };

                return View(model);
            }

            return RedirectToAction("GetList", "User");
        }
    }
}