using Store.BLL.DTO;
using Store.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.Interfaces
{
    public interface IOrderManager
    {
        Nullable<Guid> GetStatusIDByName(string name);
        IEnumerable<DeliveryTypesDTO> GetDeliveryTypes();
        void SaveOrder(OrderDTO order, IEnumerable<OrderItemDTO> orderItemList);


        IEnumerable<OrderDTO> GetOrders();
        OrderDTO GetOrderById(Guid orderId);
        IEnumerable<OrderDTO> GetOrdersByUserId(string userId);
        void UpdateOrder(OrderDTO orderDTO);

        IEnumerable<StatusDTO> GetStatuses();
        IEnumerable<OrderItemDTO> GetOrderItemsByOrderId(Guid orderId);
    }
}
