using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.DTO
{
    class UltimatePurposeDTO
    {
        public Guid? PurposeId { get; set; }
        public Guid? ItemId { get; set; }
        public Guid CurencyID { get; set; }
        public double? Price { get; set; }
        public Guid? AvailabilityTypeID { get; set; }
        public bool? IsPromo { get; set; }
        public DateTime? Date { get; set; }
    }
}
