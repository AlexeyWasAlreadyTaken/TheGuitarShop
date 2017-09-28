﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.WEB.Models
{
    public class UltimatePurposeVM
    {
        public Guid PurposeId { get; set; }
        public Guid? ItemId { get; set; }
        public string ItemBrand { get; set; }
        public string ItemName { get; set; }
        public Guid? AvailabilityTypeID { get; set; }
        public bool? IsPromo { get; set; }
        public double? Price { get; set; }
        public Guid CurencyID { get; set; }
    }
}