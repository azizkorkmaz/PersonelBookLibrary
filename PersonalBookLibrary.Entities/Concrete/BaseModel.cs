using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Entities.Concrete
{
    public class BaseModel
    {
        public bool LastUpdated { get; set; }

        public bool Status { get; set; }

        public string InsertUser { get; set; }

        public DateTime InsertDate { get; set; }

        public string UpdateUser { get; set; }

        public DateTime? UpdateDate { get; set; }

    }
}
