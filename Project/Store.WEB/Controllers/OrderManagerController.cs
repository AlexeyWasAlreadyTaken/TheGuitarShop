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
                var buff = new OrderVM();
                buff.Id = order.Id;
                buff.Address = order.Address;
                buff.Comment = order.Comment;
                buff.ContactId = order.ContactId;
                buff.Date = order.Date;
                buff.deliveryTypeID = order.DeliveryTypeID;
                buff.Email = order.Email;
                buff.Lname = order.Lname;
                buff.Name = order.Name;
                buff.Number = order.Number;
                buff.Phone = order.Phone;
                buff.Status = order.Status;
                buff.StatusId = order.StatusID;
                buff.UserId = order.UserId;
                orderVMList.Add(buff);
            }
            return View(orderVMList);
        }
        public ActionResult GetOrderItems(Guid orderId)
        {
            var orderItems = _orderManager.GetOrderItemsByOrderId(orderId);
            var orderItemVMList = new List<OrderItemVM>();
            foreach (var orderItem in orderItems)
            {
                var buff = new OrderItemVM();
                buff.PurposeId = orderItem.PurposeId;
                buff.IsPromo = orderItem.IsPromo;
                buff.ItemId = orderItem.ItemId;
                buff.ItemName = orderItem.ItemName;
                buff.BrandName = orderItem.BrandName;
                buff.Count = orderItem.Count;
                buff.Price = orderItem.Price;
                buff.Currency = orderItem.Currency;
                orderItemVMList.Add(buff);
            }
            
            return PartialView(orderItemVMList);
        }

        
        public ActionResult EditOrder(Guid orderId)
        {
            var order = _orderManager.GetOrderById(orderId);
            var buff = new OrderVM();
            buff.Id = order.Id;
            buff.Address = order.Address;
            buff.Comment = order.Comment;
            buff.ContactId = order.ContactId;
            buff.Date = order.Date;
            buff.deliveryTypeID = order.DeliveryTypeID;
            buff.Email = order.Email;
            buff.Lname = order.Lname;
            buff.Name = order.Name;
            buff.Number = order.Number;
            buff.Phone = order.Phone;
            buff.Status = order.Status;
            buff.StatusId = order.StatusID;
            buff.UserId = order.UserId;

            var statuses = _orderManager.GetStatuses();
            buff.Statuses = new SelectList(statuses, "Id", "Name");

            var deliveryTypes = _orderManager.GetDeliveryTypes();
            buff.deliveryTypes = new SelectList(deliveryTypes, "Id", "Name");

            return View("EditOrder", buff);
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
            if (orderVM.Email != null && !new Regex(@"\b[A-Za-z0-9._]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}\b").IsMatch(orderVM.Email))
                ModelState.AddModelError("Adress", "Email empty or wrong");

            if (ModelState.IsValid)
            {
                var buff = new OrderDTO();
                buff.Id = orderVM.Id;
                buff.Date = orderVM.Date;
                buff.StatusID = orderVM.StatusId;
                buff.DeliveryTypeID = orderVM.deliveryTypeID;
                buff.UserId = orderVM.UserId;
                buff.Name = orderVM.Name;
                buff.Lname = orderVM.Lname;
                buff.Phone = orderVM.Phone;
                buff.Address = orderVM.Address;
                buff.Email = orderVM.Email;
                buff.Comment = orderVM.Comment;
                buff.ContactId = orderVM.ContactId;
                buff.Number = orderVM.Number;

                _orderManager.UpdateOrder(buff);

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