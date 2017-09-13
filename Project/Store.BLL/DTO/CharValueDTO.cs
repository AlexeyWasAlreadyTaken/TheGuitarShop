using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.DTO
{
    public class CharValueDTO
    {
        public Guid Id { get; set; }
        public Guid CharacteristicId { get; set; }
        public int? IntVal { get; set; }
        public double? FloatVal { get; set; }
        public string StrVal { get; set; }
    }
}
