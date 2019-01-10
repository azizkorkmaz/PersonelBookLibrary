using PersonalBookLibrary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Entities.Concrete
{
    public class Category:BaseModel,IEntity
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
