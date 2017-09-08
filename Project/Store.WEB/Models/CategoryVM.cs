using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.WEB.Models
{
    public class CategoryVM
    {
        public Guid categoryid { get; set; }
        public Guid? parentCategoryId { get; set; }
        public string categoryName { get; set; }
    }
}