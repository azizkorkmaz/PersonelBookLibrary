using PersonalBookLibrary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Entities.Concrete
{
    public class LentBook : BaseModel, IEntity
    {
        public int LentBookId { get; set; }

        public int BookID { get; set; }

        public string BookName { get; set; }

        public string AuthorName { get; set; }

        public string GivenPersonName { get; set; }

        public string GivenPersonLastName { get; set; }

        public DateTime GivenDate { get; set; }

        public DateTime UndoDate { get; set; }
    }
}
