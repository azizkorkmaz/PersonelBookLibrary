using PersonalBookLibrary.Entities.ComplexTypes;
using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalBookLibrary.MvcUI.Models.ComplexType
{
    public class UserRolesViewModel
    {
        public User User { get; set; }
        public List<User> Users { get; set; }
        public Role Role { get; set; }
        public List<Role> Roles { get; set; }
        public List<UserRole> UserRoles { get; set; }
        public List<int> UserRoleIds { get; set; }
        public List<UserRoleDetail> UserRoleDetails { get; set; }
        public string Message { get; set; }
    }
}