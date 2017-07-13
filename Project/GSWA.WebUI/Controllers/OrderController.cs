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
        // GET: Order

        IOrderManager _order;

        public OrderController(IOrderManager ord)
        {
            _order = ord;
        }
        public ActionResult Index()
        {
            ViewBag.dtl = new SelectList(_order.GetDeliveryTypes(), "id", "name");
            return View();
        }

        [HttpPost]
        public ActionResult Index(OrderVM model, ICart cart)
        {
            //DropDownListFor 
            ViewBag.dtl = new SelectList(_order.GetDeliveryTypes(), "id", "name");
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

                if (cart.GetCartLines().ToList().Count > 0)
                    if (model.deliveryTypeID != null)
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
                        currentOrderInfo.StatusId = _order.GetStatusIDByName("New");
                        currentOrderInfo.email = model.email;

                        List<OrderItem> orlist = new List<OrderItem>();
                        foreach (CartLine cl in cart.GetCartLines())
                        {
                            OrderItem _temp = new OrderItem();
                            _temp.id = Guid.NewGuid();
                            _temp.OrderId = currentOrderInfo.Id;
                            _temp.ItemId = (Guid)cl.Purpose.ItemId; //??
                            _temp.purposePriceId = cl.PurposePrice.id;
                            _temp.purposeId = cl.Purpose.id;
                            _temp.count = cl.Count;

                            orlist.Add(_temp);

                        }


                        _order.SaveOrder(currentOrderInfo,orlist);
                        // order object "currentOrderInfo" complete to write to base=



                    }

                return RedirectToActionPermanent("index", "Home");
            }
            else
            {
                return View();
            }



        }
    }
}