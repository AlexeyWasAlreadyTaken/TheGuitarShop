using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.WEB.Models
{
    public class FilterVM
    {
        public Guid CharacteristicId { get; set; }
        public string CharacteristicName { get; set; }
        public IList<FilterCharValueVM> ValuesList { get; set; } 
    }
}