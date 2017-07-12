using GSWA.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GSWA.WebUI.Models
{
    public class HomeIndexVM
    {
        public Guid categoryid { get; set; }
        public Guid? subCategoryId { get; set; }
        public string categoryName { get; set; }
    }
}