using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.WEB.Models
{
    public class OrderItemVM
    {
        public Guid PurposeId { get; set; }
        public bool? IsPromo { get; set; }
        public Nullable<Guid> ItemId { get; set; }
        public string ItemName { get; set; }
        public string BrandName { get; set; }
        public int Count { get; set; }
        public double? Price { get; set; }
        public string Currency { get; set; }
    }
}