using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GSWA.WebUI.Models
{
    public class ConcretePurposeVM
    {
        public Nullable<Guid> purposeID { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Curency { get; set; }
        public string description { get; set; }
        public string Category { get; set; }
        public List<string> charname { get; set; }
        public List<string> charvalue { get; set; }
    }
}