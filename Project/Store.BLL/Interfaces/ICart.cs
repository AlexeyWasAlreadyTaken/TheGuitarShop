using Store.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.Interfaces
{
    public interface ICart 
    {
        void AddPurpose(Guid purposeId, int count);
        void DeleteAllPurposes();
        void DeletePurpose(Guid purposeId, int count);
        IEnumerable<OrderItemDTO> GetOrderItems();
        double? GetTotalPrice();
    }
}
