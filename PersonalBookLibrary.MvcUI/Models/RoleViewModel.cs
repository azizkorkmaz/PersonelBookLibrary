using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalBookLibrary.MvcUI.Models
{
    public class RoleViewModel
    {
        public Role Role { get; set; }
        public List<Role> Roles { get; set; }
    }
}