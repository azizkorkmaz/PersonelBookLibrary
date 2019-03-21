using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Entities.ComplexTypes
{
    public class BookDetail
    {
        public int BookID { get; set; }

        public string BookName { get; set; }

        public string AuthorName { get; set; }

        public string CategoryName { get; set; }

        public string BookSummary { get; set; }

        public string PublisherName { get; set; }

        public int Edition { get; set; }

        public bool LastUpdated { get; set; }

        public bool Status { get; set; }

        public string InsertUser { get; set; }

        public DateTime InsertDate { get; set; }

        public string UpdateUser { get; set; }

        public DateTime? UpdateDate { get; set; }

    }
}
