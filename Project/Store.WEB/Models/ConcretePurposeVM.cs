using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.WEB.Models
{
    public class ConcretePurposeVM
    {
        public Nullable<Guid> PurposeID { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public List<string> CharName { get; set; }
        public List<string> CharValue { get; set; }
    }
}