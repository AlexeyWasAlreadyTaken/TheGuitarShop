using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.WEB.Models
{
    public class OrderDetailsVM
    {
        public OrderVM order { get; set; }
        public IEnumerable<OrderItemVM> orderItems { get; set; }
    }
}