using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.BLL.Interfaces;
using Store.BLL.DTO;
using Store.WEB.Models;
using System.Text.RegularExpressions;

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
                orderVM.UserId = order.UserId;
                orderVMList.Add(orderVM);
            }
            return View(orderVMList);
        }
        public ActionResult GetOrderItems(Guid orderId)
        {
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
            
            return PartialView(orderItemVMList);
        }

        
        public ActionResult EditOrder(Guid orderId)
        {
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
            orderVM.UserId = order.UserId;

            var statuses = _orderManager.GetStatuses();
            orderVM.Statuses = new SelectList(statuses, "Id", "Name");

            var deliveryTypes = _orderManager.GetDeliveryTypes();
            orderVM.deliveryTypes = new SelectList(deliveryTypes, "Id", "Name");

            return View("EditOrder", orderVM);
        }

        //
        [HttpPost]
        public ActionResult EditOrder(OrderVM orderVM)
        {

            if (string.IsNullOrEmpty(orderVM.Name))
                ModelState.AddModelError("Name", "Fill your name");
            if (string.IsNullOrEmpty(orderVM.Lname))
                ModelState.AddModelError("Lname", "Fill your last name");
            if (string.IsNullOrEmpty(orderVM.Phone))
                ModelState.AddModelError("Phone", "Fill your phone");
            if (orderVM.deliveryTypeID == null)
                ModelState.AddModelError("deliveryTypeID", "Select delivery type");
            if (string.IsNullOrEmpty(orderVM.Address))
                ModelState.AddModelError("Adress", "Fill your adress");
            if (orderVM.email != null && !new Regex(@"\b[A-Za-z0-9._]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}\b").IsMatch(orderVM.email))
                ModelState.AddModelError("Adress", "Email empty or wrong");

            if (ModelState.IsValid)
            {
                var orderDTO = new OrderDTO();
                orderDTO.Id = orderVM.Id;
                orderDTO.data = orderVM.data;
                orderDTO.statusID = orderVM.statusID;
                orderDTO.deliveryTypeID = orderVM.deliveryTypeID;
                orderDTO.UserId = orderVM.UserId;
                orderDTO.Name = orderVM.Name;
                orderDTO.Lname = orderVM.Lname;
                orderDTO.Phone = orderVM.Phone;
                orderDTO.Address = orderVM.Address;
                orderDTO.email = orderVM.email;
                orderDTO.Comment = orderVM.Comment;
                orderDTO.ContactId = orderVM.ContactId;
                orderDTO.Number = orderVM.Number;

                _orderManager.UpdateOrder(orderDTO);

                return RedirectToAction("Orders");
            }

            var statuses = _orderManager.GetStatuses();
            orderVM.Statuses = new SelectList(statuses, "Id", "Name");

            var deliveryTypes = _orderManager.GetDeliveryTypes();
            orderVM.deliveryTypes = new SelectList(deliveryTypes, "Id", "Name");

            return View("EditOrder", orderVM);
        }
    }
}