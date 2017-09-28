using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.WEB.Models
{
    public class FilterVM
    {
        public Guid characteristicId { get; set; }
        public string characteristicName { get; set; }
        public IList<FilterCharValueVM> valuesList { get; set; } 
    }
}