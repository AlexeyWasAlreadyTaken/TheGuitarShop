using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.DTO
{
    public class ItemCharacteristicDTO
    {
        public Guid? Id { get; set; }
        public Guid? ItemID { get; set; }
        public Guid? CharacteristicID { get; set; }
        public string CharacteristicName { get; set; }
        public Guid? CharValueID { get; set; }
    }
}
