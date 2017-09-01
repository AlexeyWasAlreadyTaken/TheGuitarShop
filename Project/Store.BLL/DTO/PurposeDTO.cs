using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.DTO
{
    public class PurposeDTO
    {
        public Guid purposeID { get; set; }
        public Guid categoryID { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public string Curency { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }

        //
        public List<string> charname { get; set; }
        public List<string> charvalue { get; set; }

        public string Description { get; set; }
    }
}
