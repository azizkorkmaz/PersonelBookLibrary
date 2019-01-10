using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Entities.ComplexType
{
    public class BookDetail
    {
        public int BookId { get; set; }

        public string BookName { get; set; }

        public string AuthorName { get; set; }

        public string CategoryName { get; set; }

        public string BookSummary { get; set; }
    }
}
