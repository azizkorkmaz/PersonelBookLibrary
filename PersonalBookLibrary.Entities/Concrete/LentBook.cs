﻿using PersonalBookLibrary.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBookLibrary.Entities.Concrete
{
    public class LentBook : BaseModel, IEntity
    {
        public int LentBookId { get; set; }

        public int BookID { get; set; }

        public string BorrowPersonName { get; set; }

        public string BorrowPersonLastName { get; set; }

        public string GivenUserName { get; set; }
        
        public DateTime GivenDate { get; set; }

        public DateTime? UndoDate { get; set; }
    }
}
