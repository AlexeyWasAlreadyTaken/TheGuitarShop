using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSWA.Domain.Abstract
{
    public interface IOrderManager : IDisposable
    {
        Nullable<Guid> GetStatusIDByName(string name);
        IEnumerable<DeliveryType> GetDeliveryTypes();
        void SaveOrder(Order order);
    }
}
