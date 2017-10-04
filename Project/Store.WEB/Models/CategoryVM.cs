using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.WEB.Models
{
    public class CategoryVM
    {
        public Guid CategoryId { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}