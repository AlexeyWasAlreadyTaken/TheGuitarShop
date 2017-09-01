using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.DTO
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }
        public Nullable<System.Guid> ParentCategoryID { get; set; }
        public string Name { get; set; }
    }
}
