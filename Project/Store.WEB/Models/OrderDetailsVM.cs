using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.WEB.Models
{
    public class OrderDetailsVM
    {
        public OrderVM Order { get; set; }
        public IEnumerable<OrderItemVM> OrderItems { get; set; }
    }
}