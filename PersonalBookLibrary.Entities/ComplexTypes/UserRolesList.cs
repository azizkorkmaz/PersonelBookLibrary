using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Entities.ComplexTypes
{
    public class UserRolesList
    {
        public User User { get; set; }
        public List<User> Users { get; set; }
        public UserRole UserRole { get; set; }
        public List<UserRole> UserRoles { get; set; }
        public List<int> UserRoleIds { get; set; }
    }
}
