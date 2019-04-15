using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Entities.ComplexTypes
{
    public class LentBookDetail
    {
        public int LentBookID { get; set; }
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string CategoryName { get; set; }
        public string AuthorName { get; set; }
        public string BookSummary { get; set; }
        public string BorrowPersonName { get; set; }
        public string BorrowPersonLastName { get; set; }
        public string GivenUserName { get; set; }
        public DateTime GivenDate { get; set; }
        public DateTime? UndoDate { get; set; }
        public bool Status { get; set; }
    }
}
