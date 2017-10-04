using Store.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Store.WEB.Models;

namespace Store.WEB.Controllers
{
    public class UserAccountController : Controller
    {
        private IOrderManager _orderManager;
        public UserAccountController(IOrderManager order)
        {
            _orderManager = order;
        }

        // GET: UserAccount
        public ActionResult Index()
        {
            var currentUserId = "Empty";
            if (User.Identity.IsAuthenticated)
            {
                currentUserId = User.Identity.GetUserId();
                var orderList = _orderManager.GetOrdersByUserId(currentUserId);

                var orderDetailsVMList = new List<OrderDetailsVM>();
                

                foreach (var i in orderList)
                {
                    var orderDetailsVM = new OrderDetailsVM();
                    var orderVM = new OrderVM();
                    orderVM.Id = i.Id;
                    orderVM.Address = i.Address;
                    orderVM.Comment = i.Comment;
                    orderVM.ContactId = i.ContactId;
                    orderVM.Date = i.Date;
                    orderVM.deliveryTypeID = i.DeliveryTypeID;
                    orderVM.Email = i.Email;
                    orderVM.Lname = i.Lname;
                    orderVM.Name = i.Name;
                    orderVM.Number = i.Number;
                    orderVM.Phone = i.Phone;
                    orderVM.Status = i.Status;
                    orderVM.StatusId = i.StatusID;
                    orderDetailsVM.Order = orderVM;
                    orderVM = null;

                    var orderItems = _orderManager.GetOrderItemsByOrderId(i.Id);
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
                        orderItemVM = null;
                    }
                    orderDetailsVM.OrderItems = orderItemVMList;
                    orderDetailsVMList.Add(orderDetailsVM);

                }

                return View(orderDetailsVMList);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}