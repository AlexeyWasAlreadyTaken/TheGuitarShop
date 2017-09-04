using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.BLL.Interfaces;
using Store.BLL.DTO;
using Store.WEB.Models;

namespace Store.WEB.Controllers
{
    public class OrderManagerController : Controller
    {
        private IOrderManager _orderManager;

        public OrderManagerController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }


        public ActionResult Index()
        {
            return RedirectToAction("Orders");
        }
        public ActionResult Orders()
        {
            var orders = _orderManager.GetOrders();
            var orderVMList = new List<OrderVM>();
            foreach (var order in orders)
            {
                var orderVM = new OrderVM();
                orderVM.Id = order.Id;
                orderVM.Address = order.Address;
                orderVM.Comment = order.Comment;
                orderVM.ContactId = order.ContactId;
                orderVM.data = order.data;
                orderVM.deliveryTypeID = order.deliveryTypeID;
                orderVM.email = order.email;
                orderVM.Lname = order.Lname;
                orderVM.Name = order.Name;
                orderVM.Number = order.Number;
                orderVM.Phone = order.Phone;
                orderVM.Status = order.Status;
                orderVM.statusID = order.statusID;
                orderVMList.Add(orderVM);
            }
            return View(orderVMList);
        }
        public ActionResult OrderDetails(Guid orderId)
        {
            var orderDetailsVM = new OrderDetailsVM();

            var order = _orderManager.GetOrderById(orderId);
            var orderVM = new OrderVM();
            orderVM.Id = order.Id;
            orderVM.Address = order.Address;
            orderVM.Comment = order.Comment;
            orderVM.ContactId = order.ContactId;
            orderVM.data = order.data;
            orderVM.deliveryTypeID = order.deliveryTypeID;
            orderVM.email = order.email;
            orderVM.Lname = order.Lname;
            orderVM.Name = order.Name;
            orderVM.Number = order.Number;
            orderVM.Phone = order.Phone;
            orderVM.Status = order.Status;
            orderVM.statusID = order.statusID;
            orderDetailsVM.order = orderVM;

            var orderItems = _orderManager.GetOrderItemsByOrderId(orderId);
            var orderItemVMList = new List<OrderItemVM>();
            foreach (var orderItem in orderItems)
            {
                var orderItemVM = new OrderItemVM();
                orderItemVM.PurposeId = orderItem.PurposeId;
                orderItemVM.IsPromo = orderItem.IsPromo;
                orderItemVM.ItemId = orderItem.ItemId;
                orderItemVM.ItemName = orderItem.ItemName;
                orderItemVM.BrandName = orderItem.BrandName;
                orderItemVM.Count = orderItem.Count;
                orderItemVM.Price = orderItem.Price;
                orderItemVM.Currency = orderItem.Currency;
                orderItemVMList.Add(orderItemVM);
            }
            orderDetailsVM.orderItems = orderItemVMList; 

            return View(orderDetailsVM);
        }
        public ActionResult ChangeOrderStatus(Guid orderId, Guid statusId)
        {
            var order = _orderManager.GetOrderById(orderId);
            order.statusID = statusId;
            _orderManager.UpdateOrder(order);

            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}