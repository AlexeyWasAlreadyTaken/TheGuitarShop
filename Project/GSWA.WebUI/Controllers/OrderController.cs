using GSWA.Domain;
using GSWA.Domain.Abstract;
using GSWA.Domain.Concrete;
using GSWA.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace GSWA.WebUI.Controllers
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
            ViewBag.dtl = new SelectList(_orderManager.GetDeliveryTypes(), "id", "name");
            return View();
        }

        [HttpPost]
        public ActionResult Index(OrderVM model, ICart cart)
        {
            //DropDownListFor 
            ViewBag.dtl = new SelectList(_orderManager.GetDeliveryTypes(), "id", "name");
            //Validation
            if (string.IsNullOrEmpty(model.Name))
                ModelState.AddModelError("Name", "Fill your name");
            if (string.IsNullOrEmpty(model.Lname))
                ModelState.AddModelError("Lname", "Fill your last name");
            if (string.IsNullOrEmpty(model.Phone))
                ModelState.AddModelError("Phone", "Fill your phone");
            if (model.deliveryTypeID == null)
                ModelState.AddModelError("deliveryTypeID", "Select delivery type");
            if (string.IsNullOrEmpty(model.Adress))
                ModelState.AddModelError("Adress", "Fill your adress");
            if (model.email != null && !new Regex(@"\b[A-Za-z0-9._]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}\b").IsMatch(model.email))
                ModelState.AddModelError("Adress", "Email empty or wrong");

            //Validation Check
            if (ModelState.IsValid)
            {
                if (cart.GetOrderItems().ToList().Count > 0)
                {
                    // initialize order information 
                    Order currentOrderInfo = new Order();
                    currentOrderInfo.Id = Guid.NewGuid();
                    currentOrderInfo.Name = model.Name;
                    currentOrderInfo.LastName = model.Lname;
                    currentOrderInfo.Phone = model.Phone;
                    currentOrderInfo.DeliveryTypeId = model.deliveryTypeID;
                    currentOrderInfo.Address = model.Adress;
                    currentOrderInfo.Comment = model.Comment;
                    currentOrderInfo.Date = DateTime.Now;
                    currentOrderInfo.StatusId = _orderManager.GetStatusIDByName("New");
                    currentOrderInfo.email = model.email;

                    List<OrderItem> orderItemeList = new List<OrderItem>();
                    foreach (var orderItem in cart.GetOrderItems())
                    {
                        var temp = new OrderItem();
                        temp.id = Guid.NewGuid();
                        temp.OrderId = currentOrderInfo.Id;
                        temp.ItemId = orderItem.ItemId;
                        temp.purposePriceId = orderItem.purposePrice.id;
                        temp.purposeId = orderItem.Purpose.id;
                        temp.count = orderItem.count;
                        orderItemeList.Add(temp);
                    }

                    _orderManager.SaveOrder(currentOrderInfo, orderItemeList);
                    cart.DeleteAllPurposes();
                    // order object "currentOrderInfo" complete to write to base=
                    ViewBag.orderNumber = currentOrderInfo.Id;
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