using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.WEB.Models
{
    public class CategoryCharacteristicVM
    {
        public Guid Id { get; set; }
        public Guid CategoryID { get; set; }
        public Guid CharacteristicID { get; set; }
        public string CharacteristicName{ get; set; }
    }
}