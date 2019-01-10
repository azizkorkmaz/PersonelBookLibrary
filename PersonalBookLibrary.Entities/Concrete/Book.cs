using PersonalBookLibrary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Entities.Concrete
{
    public class Book:BaseModel,IEntity
    {
        public int BookId { get; set; }

        public string BookName { get; set; }

        public string AuthorName { get; set; }

        public int CategoryID { get; set; }

        public string PublisherName { get; set; }

        public int Edition { get; set; }

        public string BookSummary { get; set; }
    }
}
