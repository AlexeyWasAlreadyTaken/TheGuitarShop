using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.WEB.Models
{
    public class CatalogPurposeVM
    {
        public Nullable<Guid> PurposeID { get; set; }
        public Nullable<Guid> CategoryID { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public string Curency { get; set; }
        public string Category { get; set; }
        public List<string> FilterCharName { get; set; }
        public List<string> FilterCharVal { get; set; }
    }
}