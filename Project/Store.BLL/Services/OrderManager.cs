using Store.BLL.Interfaces;
using Store.BLL.DTO;
using Store.DAL.Entities;
using Store.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BLL.Services
{
    public class OrderManager : IOrderManager
    {
        private IRepository<Order> _order;
        private IRepository<Status> _status;
        private IRepository<DeliveryType> _deliveryType;
        private IRepository<OrderItem> _orderItems;

        public OrderManager(IRepository<Order> orderRepo, IRepository<DeliveryType> deliveryTypeRepo, IRepository<Status> statusTypeRepo, IRepository<OrderItem> orderItems)
        {
            _order = orderRepo;
            _status = statusTypeRepo;
            _deliveryType = deliveryTypeRepo;
            _orderItems = orderItems;
        }

        public IEnumerable<DeliveryTypesDTO> GetDeliveryTypes()
        {
            var deliveryTypes = _deliveryType.Get();
            var deliveryTypesDTOList = new List<DeliveryTypesDTO>();
            foreach (var i in deliveryTypes)
            {
                var _buff = new DeliveryTypesDTO();
                _buff.Id = i.Id;
                _buff.Name = i.Name;
                deliveryTypesDTOList.Add(_buff);
                _buff = null;
            }
            return deliveryTypesDTOList;
        }

        public Nullable<Guid> GetStatusIDByName(string name)
        {
            return _status.Get(x => x.Name == name).ToList().FirstOrDefault().Id;
        }

        public void SaveOrder(OrderDTO order, IEnumerable<OrderItemDTO> orderItemsDTOList)
        {
            //orderDTO -> order entity , orderitemDTO - orderitems

            var currentorder = new Order();
            currentorder.Id = Guid.NewGuid();//order.id;
            currentorder.Name = order.Name;
            currentorder.LastName = order.Lname;
            currentorder.Phone = order.Phone;
            currentorder.DeliveryTypeId = order.deliveryTypeID;
            currentorder.Address = order.Adress;
            currentorder.Comment = order.Comment;
            currentorder.Date = order.data;
            currentorder.StatusId = order.statusID;
            currentorder.Email = order.email;
            currentorder.ApplicationUserId = order.UserId.ToString();
            _order.Create(currentorder);

            foreach (var i in orderItemsDTOList)
            {
                var _buff = new OrderItem();
                _buff.Id = Guid.NewGuid();
                _buff.OrderId = currentorder.Id;
                _buff.ItemId = i.ItemId;
                _buff.PurposePriceId = i.PurposePriceId;
                _buff.PurposeId = i.PurposeId;
                _buff.Count = i.Count;
                _orderItems.Create(_buff);
            }

        }
    }
}
