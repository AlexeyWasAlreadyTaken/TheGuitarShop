using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.DTO
{
    public class CategoryCharacteristicDTO
    {
        public Guid Id { get; set; }
        public Guid CategoryID { get; set; }
        public Guid CharacteristicID { get; set; }
        public CharacteristicDTO Characteristic { get; set; }
    }
}
