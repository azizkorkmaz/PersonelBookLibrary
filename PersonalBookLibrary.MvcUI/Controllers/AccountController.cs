using PersonalBookLibrary.Business.Abstract;
using PersonalBookLibrary.Core.CrossCuttingConcerns.Security.Web;
using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalBookLibrary.MvcUI.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var checkUser = _userService.GetByUserNameAndPassword(user.UserName, user.Password);

            if (checkUser != null)
            {
                AuthenticationHelper.CreateAutCookie(
                    new Guid(),
                    checkUser.UserName,
                    checkUser.Email,
                    DateTime.Now.AddDays(5),
                    _userService.GetUserRoles(checkUser).Select(u => u.RoleName).ToArray(),
                    false,
                    checkUser.FirstName,
                    checkUser.LastName);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login","Account");
            }

        }
    }
}

//engin hoca ile beraber yazılan kod
// GET: Account
//public string Login(string userName, string password)
//{
//    var user = _userService.GetByUserNameAndPassword(userName, password);

//    if ( user != null)
//    {
//        AuthenticationHelper.CreateAutCookie(
//                        new Guid(),
//                        user.UserName,
//                        user.Email,
//                        DateTime.Now.AddDays(15),
//                        _userService.GetUserRoles(user).Select(u=>u.RoleName).ToArray(),
//                        false,
//                        user.FirstName,
//                        user.LastName);
//        return "User is authenticatied!";
//    }

//    return "User is not authenticated!";
//}