using PersonalBookLibrary.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalBookLibrary.MvcUI.Models
{
    public class ReadBookViewModel
    {
        public List<ReadBook> ReadBooks { get; set; }
        public ReadBook ReadBook { get; set; }
    }
}