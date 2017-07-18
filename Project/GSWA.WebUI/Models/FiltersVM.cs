using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GSWA.WebUI.Models
{
    public class FiltersVM
    {
        public Guid characteristicId { get; set; }
        public string characteristicName { get; set; }
        public Guid valueId { get; set; }
        public string value { get; set; }
    }
}