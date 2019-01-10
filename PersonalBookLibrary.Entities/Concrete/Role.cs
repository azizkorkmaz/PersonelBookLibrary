using PersonalBookLibrary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Entities.Concrete
{
    public class Role:BaseModel,IEntity
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; }
    }
}
