using PersonalBookLibrary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Entities.Concrete
{
    public class UserRole:BaseModel,IEntity
    {
        public int UserRolesId { get; set; }

        public int UserID { get; set; }

        public int RoleID { get; set; }
    }
}
