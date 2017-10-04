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
                var buff = new DeliveryTypesDTO();
                buff.Id = i.Id;
                buff.Name = i.Name;
                deliveryTypesDTOList.Add(buff);
                buff = null;
            }
            return deliveryTypesDTOList;
        }

        public Nullable<Guid> GetStatusIDByName(string name)
        {
            return _status.Get(x => x.Name == name).ToList().FirstOrDefault().Id;
        }

        public void SaveOrder(OrderDTO order, IEnumerable<OrderItemDTO> orderItemsDTOList)
        {
            var currentOrder = new Order();
            currentOrder.Id = Guid.NewGuid();
            currentOrder.Name = order.Name;
            currentOrder.LastName = order.Lname;
            currentOrder.Phone = order.Phone;
            currentOrder.DeliveryTypeId = order.DeliveryTypeID;
            currentOrder.Address = order.Address;
            currentOrder.Comment = order.Comment;
            currentOrder.Date = order.Date;
            currentOrder.StatusId = order.StatusID;
            currentOrder.Email = order.Email;
            currentOrder.ApplicationUserId = order.UserId.ToString();
            _order.Create(currentOrder);

            foreach (var i in orderItemsDTOList)
            {
                var buff = new OrderItem();
                buff.Id = Guid.NewGuid();
                buff.OrderId = currentOrder.Id;
                buff.ItemId = i.ItemId;
                buff.PurposePriceId = i.PurposePriceId;
                buff.PurposeId = i.PurposeId;
                buff.Count = i.Count;
                _orderItems.Create(buff);
            }

        }


        public IEnumerable<OrderDTO> GetOrders()
        {
            var orders = _order.GetWithInclude(o=>o.Status);
            var orderDTOList = new List<OrderDTO>();
            foreach (var i in orders)
            {
                var buff = new OrderDTO();
                buff.Id = i.Id;
                buff.Email = i.Email;
                buff.Address = i.Address;
                buff.Comment = i.Comment;
                buff.Date = i.Date;
                buff.Phone = i.Phone;
                buff.Name = i.Name;
                buff.Lname = i.LastName;
                buff.StatusID = i.StatusId;
                buff.Status = i.Status.Name;
                buff.DeliveryTypeID = i.DeliveryTypeId;
                buff.UserId = i.ApplicationUserId;
                buff.Number = i.Number;
                buff.ContactId = i.ContactId;

                orderDTOList.Add(buff);
            }

            return orderDTOList;
        }

        public OrderDTO GetOrderById(Guid orderId)
        {
            var order = _order.GetWithInclude(o=> o.Id == orderId,o => o.Status).FirstOrDefault();

            var buff = new OrderDTO();
            buff.Id = order.Id;
            buff.Email = order.Email;
            buff.Address = order.Address;
            buff.Comment = order.Comment;
            buff.Date = order.Date;
            buff.Phone = order.Phone;
            buff.Name = order.Name;
            buff.Lname = order.LastName;
            buff.StatusID = order.StatusId;
            buff.Status = order.Status.Name;
            buff.DeliveryTypeID = order.DeliveryTypeId;
            buff.UserId = order.ApplicationUserId;
            buff.Number = order.Number;
            buff.ContactId = order.ContactId;

            return buff;
        }
        public IEnumerable<OrderDTO> GetOrdersByUserId(string userId)
        {
            var orders = _order.GetWithInclude(o=>o.ApplicationUserId == userId,o => o.Status);
            var orderDTOList = new List<OrderDTO>();
            foreach (var i in orders)
            {
                var buff = new OrderDTO();
                buff.Id = i.Id;
                buff.Email = i.Email;
                buff.Address = i.Address;
                buff.Comment = i.Comment;
                buff.Date = i.Date;
                buff.Phone = i.Phone;
                buff.Name = i.Name;
                buff.Lname = i.LastName;
                buff.StatusID = i.StatusId;
                buff.Status = i.Status.Name;
                buff.DeliveryTypeID = i.DeliveryTypeId;
                buff.UserId = i.ApplicationUserId;
                buff.Number = i.Number;
                buff.ContactId = i.ContactId;

                orderDTOList.Add(buff);
            }

            return orderDTOList;
        }

        public void UpdateOrder(OrderDTO orderDTO)
        {
            var buff = new Order();

            buff.Id = orderDTO.Id;
            buff.StatusId = orderDTO.StatusID;
            buff.ApplicationUserId = orderDTO.UserId;
            buff.Comment = orderDTO.Comment;
            buff.Name = orderDTO.Name;
            buff.LastName = orderDTO.Lname;
            buff.Phone = orderDTO.Phone;
            buff.Address = orderDTO.Address;
            buff.Date = orderDTO.Date;
            buff.DeliveryTypeId = orderDTO.DeliveryTypeID;
            buff.Email = orderDTO.Email;

            buff.ContactId = orderDTO.ContactId;
            buff.Number = orderDTO.Number;


            _order.Update(buff);
        }

        public IEnumerable<StatusDTO> GetStatuses()
        {
            var statuses = _status.Get();
            var statusDTOList = new List<StatusDTO>();
            foreach (var i in statuses)
            {
                var statusDTO = new StatusDTO();
                statusDTO.Id = i.Id;
                statusDTO.Name = i.Name;
                statusDTOList.Add(statusDTO);
            }
            return statusDTOList;
        }

        public IEnumerable<OrderItemDTO> GetOrderItemsByOrderId(Guid orderId)
        {
            var orderItems = _orderItems.GetWithInclude(o => o.OrderId == orderId, o => o.Item, o => o.PurposePrice, o => o.Purpose, o => o.Item.Brand, o => o.PurposePrice.Curency);
            var orderItemDTOList = new List<OrderItemDTO>();
            foreach (var i in orderItems)
            {
                var buff = new OrderItemDTO();
                buff.Id = i.Id;
                buff.ItemId = i.ItemId;
                buff.ItemName = i.Item.Name;
                buff.OrderId = i.OrderId;
                buff.Price = (double)i.PurposePrice.Price;
                buff.PurposeId = i.PurposeId;
                buff.PurposePriceId = i.PurposePriceId;
                buff.BrandName = i.Item.Brand.Name;
                buff.IsPromo = (bool)i.Purpose.IsPromo;
                buff.Currency = i.PurposePrice.Curency.Name;
                buff.Count = i.Count;
                orderItemDTOList.Add(buff);
            }
            return orderItemDTOList;
        }
    }
}
