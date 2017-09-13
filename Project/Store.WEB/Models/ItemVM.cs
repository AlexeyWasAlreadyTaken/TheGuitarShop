using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.WEB.Models
{
    public class ItemVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? CategoryID { get; set; }

        public Guid? BrandID { get; set; }
        public Guid? ManufCountryID { get; set; }
        public Guid? BrandCountryID { get; set; }

        public string BrandName{ get; set; }

        public SelectList Brands { get; set; }
        public SelectList ManufCountries { get; set; }
        public SelectList BrandCountries { get; set; }
    }
}