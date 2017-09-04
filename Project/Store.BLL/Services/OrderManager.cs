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
            currentorder.Address = order.Address;
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


        public IEnumerable<OrderDTO> GetOrders()
        {
            var orders = _order.GetWithInclude(o=>o.Status);
            var orderDTOList = new List<OrderDTO>();
            foreach (var order in orders)
            {
                var orderDTO = new OrderDTO();
                orderDTO.Id = order.Id;
                orderDTO.email = order.Email;
                orderDTO.Address = order.Address;
                orderDTO.Comment = order.Comment;
                orderDTO.data = (DateTime)order.Date;
                orderDTO.Phone = order.Phone;
                orderDTO.Name = order.Name;
                orderDTO.Lname = order.LastName;
                orderDTO.statusID = order.StatusId;
                orderDTO.Status = order.Status.Name;
                orderDTO.deliveryTypeID = order.DeliveryTypeId;

                orderDTO.Number = order.Number;
                orderDTO.ContactId = order.ContactId;

                orderDTOList.Add(orderDTO);
            }

            return orderDTOList;
        }

        public OrderDTO GetOrderById(Guid orderId)
        {
            var order = _order.GetWithInclude(o=> o.Id == orderId,o => o.Status).FirstOrDefault();

            var orderDTO = new OrderDTO();
            orderDTO.Id = order.Id;
            orderDTO.email = order.Email;
            orderDTO.Address = order.Address;
            orderDTO.Comment = order.Comment;
            orderDTO.data = (DateTime)order.Date;
            orderDTO.Phone = order.Phone;
            orderDTO.Name = order.Name;
            orderDTO.Lname = order.LastName;
            orderDTO.statusID = order.StatusId;
            orderDTO.Status = order.Status.Name;
            orderDTO.deliveryTypeID = order.DeliveryTypeId;

            orderDTO.Number = order.Number;
            orderDTO.ContactId = order.ContactId;

            return orderDTO;
        }
        public IEnumerable<OrderDTO> GetOrdersByUserId(string userId)
        {
            var orders = _order.GetWithInclude(o=>o.ApplicationUserId == userId,o => o.Status);
            var orderDTOList = new List<OrderDTO>();
            foreach (var order in orders)
            {
                var orderDTO = new OrderDTO();
                orderDTO.Id = order.Id;
                orderDTO.email = order.Email;
                orderDTO.Address = order.Address;
                orderDTO.Comment = order.Comment;
                orderDTO.data = (DateTime)order.Date;
                orderDTO.Phone = order.Phone;
                orderDTO.Name = order.Name;
                orderDTO.Lname = order.LastName;
                orderDTO.statusID = order.StatusId;
                orderDTO.Status = order.Status.Name;
                orderDTO.deliveryTypeID = order.DeliveryTypeId;

                orderDTO.Number = order.Number;
                orderDTO.ContactId = order.ContactId;

                orderDTOList.Add(orderDTO);
            }

            return orderDTOList;
        }

        public void UpdateOrder(OrderDTO orderDTO)
        {
            var order = new Order();

            order.Id = orderDTO.Id;
            order.StatusId = orderDTO.Id;
            order.ApplicationUserId = orderDTO.UserId;
            order.Comment = orderDTO.Comment;
            order.Name = orderDTO.Name;
            order.LastName = orderDTO.Lname;
            order.Phone = orderDTO.Phone;
            order.Address = orderDTO.Address;
            order.Date = orderDTO.data;
            order.DeliveryTypeId = orderDTO.deliveryTypeID;
            order.Email = orderDTO.email;

            order.ContactId = orderDTO.ContactId;
            order.Number = orderDTO.Number;


            _order.Update(order);
        }

        public IEnumerable<StatusDTO> GetStatuses()
        {
            var statuses = _status.Get();
            var statusDTOList = new List<StatusDTO>();
            foreach (var status in statuses)
            {
                var statusDTO = new StatusDTO();
                statusDTO.Id = status.Id;
                statusDTO.Name = status.Name;
                statusDTOList.Add(statusDTO);
            }
            return statusDTOList;
        }

        public IEnumerable<OrderItemDTO> GetOrderItemsByOrderId(Guid orderId)
        {
            var orderItems = _orderItems.GetWithInclude(o => o.OrderId == orderId, o => o.Item, o => o.PurposePrice, o => o.Purpose, o => o.Item.Brand, o => o.PurposePrice.Curency);
            var orderItemDTOList = new List<OrderItemDTO>();
            foreach (var orderItem in orderItems)
            {
                var orderItemDTO = new OrderItemDTO();
                orderItemDTO.Id = orderItem.Id;
                orderItemDTO.ItemId = orderItem.ItemId;
                orderItemDTO.ItemName = orderItem.Item.Name;
                orderItemDTO.OrderId = orderItem.OrderId;
                orderItemDTO.Price = (double)orderItem.PurposePrice.Price;
                orderItemDTO.PurposeId = orderItem.PurposeId;
                orderItemDTO.PurposePriceId = orderItem.PurposePriceId;
                orderItemDTO.BrandName = orderItem.Item.Brand.Name;
                orderItemDTO.IsPromo = (bool)orderItem.Purpose.IsPromo;
                orderItemDTO.Currency = orderItem.PurposePrice.Curency.Name;
                orderItemDTO.Count = orderItem.Count;
                orderItemDTOList.Add(orderItemDTO);
            }
            return orderItemDTOList;
        }
    }
}
