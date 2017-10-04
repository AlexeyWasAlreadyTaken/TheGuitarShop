using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.DTO
{
    public class PurposeDTO
    {
        public Guid PurposeID { get; set; }
        public Guid CategoryID { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public string Curency { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public List<string> CharName { get; set; }
        public List<string> CharValue { get; set; }
        public string Description { get; set; }
    }
}
