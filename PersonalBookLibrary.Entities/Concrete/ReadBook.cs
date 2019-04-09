using PersonalBookLibrary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Entities.Concrete
{
    public class ReadBook: BaseModel, IEntity
    {
        public int ReadBookId { get; set; }

        public string BookName { get; set; }

        public string AuthorName { get; set; }
    }
}
