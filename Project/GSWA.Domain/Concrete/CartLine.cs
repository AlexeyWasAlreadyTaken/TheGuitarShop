using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSWA.Domain.Concrete
{
    public class CartLine
    {
        public Purpose Purpose { get; set; }
        public purposePrice PurposePrice { get; set; }
        public int Count { get; set; }
    }
}