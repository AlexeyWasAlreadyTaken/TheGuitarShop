using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.DTO
{
    public class ItemDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? CategoryID { get; set; }
        public Guid? BrandID { get; set; }
        public Guid? ManufCountryID { get; set; }
        public Guid? BrandCountryID { get; set; }
    }
}
