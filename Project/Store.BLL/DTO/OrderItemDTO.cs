using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.DTO
{
    public class OrderItemDTO
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ItemId { get; set; }
        public Guid PurposePriceId { get; set; }
        public Guid PurposeId { get; set; }
        public int Count { get; set; }
        public string BrandName { get; set; }
        public string ItemName { get; set; }
        public bool IsPromo { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
    }
}
