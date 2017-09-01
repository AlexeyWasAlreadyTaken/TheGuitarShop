using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.WEB.Models
{
    public class HomeNewsVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<DateTime> Date { get; set; }
    }
}