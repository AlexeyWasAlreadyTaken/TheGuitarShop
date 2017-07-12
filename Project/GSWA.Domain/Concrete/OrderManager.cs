using GSWA.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSWA.Domain.Concrete
{
    public class OrderManager : IOrderManager
    {
        private IRepository<Order> _order;
        private IRepository<status> _status;
        private IRepository<DeliveryType> _deliveryType;

        public OrderManager(IRepository<Order> orderRepo, IRepository<DeliveryType> deliveryTypeRepo, IRepository<status>statusTypeRepo)
        {
            _order = orderRepo;
            _status = statusTypeRepo;
            _deliveryType = deliveryTypeRepo;
        }

        public IEnumerable<DeliveryType> GetDeliveryTypes()
        {
            return _deliveryType.Get();
        }

        public Nullable<Guid> GetStatusIDByName(string name)
        {
            return _status.Get(x => x.name == name).ToList().FirstOrDefault().id;
        }

        public void SaveOrder(Order order)
        {
         
             _order.Create(order);
        }
        public void Dispose()
        {
            _order.Dispose();
            _status.Dispose();
            _deliveryType.Dispose();
        }
    }
}
