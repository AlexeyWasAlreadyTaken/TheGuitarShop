using Store.BLL.DTO;
using Store.BLL.Interfaces;
using Store.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Store.WEB.Controllers
{
    public class OrderController : Controller
    {
        IOrderManager _orderManager;

        public OrderController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }
        public ActionResult Index()
        {
            var ddl = _orderManager.GetDeliveryTypes();
            //ViewBag.dtl = new SelectList(_orderManager.GetDeliveryTypes(), "Id", "Name");
            ViewBag.dtl = new SelectList(ddl, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Index(OrderVM model, ICart cart)
        {
            //DropDownListFor 
            var ddl = _orderManager.GetDeliveryTypes();
            //ViewBag.dtl = new SelectList(_orderManager.GetDeliveryTypes(), "Id", "Name");
            ViewBag.dtl = new SelectList(ddl, "Id", "Name");
            //Validation
            if (string.IsNullOrEmpty(model.Name))
                ModelState.AddModelError("Name", "Fill your name");
            if (string.IsNullOrEmpty(model.Lname))
                ModelState.AddModelError("Lname", "Fill your last name");
            if (string.IsNullOrEmpty(model.Phone))
                ModelState.AddModelError("Phone", "Fill your phone");
            if (model.deliveryTypeID == null)
                ModelState.AddModelError("deliveryTypeID", "Select delivery type");
            if (string.IsNullOrEmpty(model.Address))
                ModelState.AddModelError("Adress", "Fill your adress");
            if (model.email != null && !new Regex(@"\b[A-Za-z0-9._]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}\b").IsMatch(model.email))
                ModelState.AddModelError("Adress", "Email empty or wrong");


         





            //Validation Check
            if (ModelState.IsValid)
            {
                if (cart.GetOrderItems().ToList().Count > 0)
                {
                    // initialize order information 
                    var currentOrderInfo = new OrderDTO();

                    currentOrderInfo.Name = model.Name;
                    currentOrderInfo.Lname = model.Lname;
                    currentOrderInfo.Phone = model.Phone;
                    currentOrderInfo.deliveryTypeID = model.deliveryTypeID;
                    currentOrderInfo.Address = model.Address;
                    currentOrderInfo.Comment = model.Comment;
                    currentOrderInfo.data = DateTime.Now;
                    currentOrderInfo.statusID = _orderManager.GetStatusIDByName("New");
                    currentOrderInfo.email = model.email;

                    if (User.Identity.IsAuthenticated)
                    {
                        currentOrderInfo.UserId = User.Identity.GetUserId();
                    }
                    var orderItemeList = new List<OrderItemDTO>();
                    foreach (var orderItem in cart.GetOrderItems())
                    {
                        var temp = new OrderItemDTO();
                        temp.ItemId = orderItem.ItemId;
                        temp.PurposePriceId = orderItem.PurposePriceId;
                        temp.PurposeId = orderItem.PurposeId;
                        temp.Count = orderItem.Count;
                        orderItemeList.Add(temp);
                    }
                 
                    _orderManager.SaveOrder(currentOrderInfo, orderItemeList);
                    cart.DeleteAllPurposes();
                    // order object "currentOrderInfo" complete to write to base=
                    ViewBag.orderNumber = "ORDER NUMBER";  // to do
                    return View("OrderRegistered");
                }
                else
                {
                    return RedirectToAction("Index", "Cart");
                }
            }
            else
            {
                return View();
            }
        }
    }
}