using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.WEB.Models
{
    public class ItemCharacteristicVM
    {
        public Guid? Id { get; set; }
        public Guid? ItemID { get; set; }
        public Guid CharacteristicID { get; set; }
        public string CharacteristicName { get; set; }
        public Guid? CharValueID { get; set; }
        public SelectList CharValues { get; set; }
    }
}