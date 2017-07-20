using GSWA.Domain;
using GSWA.Domain.Abstract;
using GSWA.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GSWA.WebUI.Controllers
{
    public class CartController : Controller
    {
        public ActionResult Index(ICart cart)
        {
            var orderItems = cart.GetOrderItems();
            var CartIndexVMList = new List<CartIndexVM>();
            foreach (var orderItem in orderItems)
            {
                CartIndexVM cartIndexVM = new CartIndexVM();
                cartIndexVM.PurposeId = orderItem.Purpose.id;
                cartIndexVM.ItemId = orderItem.ItemId;
                cartIndexVM.BrandName = orderItem.Item.Brand.Name;
                cartIndexVM.ItemName = orderItem.Item.Name;
                cartIndexVM.IsPromo = orderItem.Purpose.IsPromo;
                cartIndexVM.Count = orderItem.count;
                cartIndexVM.Price = orderItem.purposePrice.price * orderItem.count;
                cartIndexVM.Currency = orderItem.purposePrice.Curency.Name;
                CartIndexVMList.Add(cartIndexVM);
            }
            return View(CartIndexVMList);
        }
        public ActionResult AddPurpose(ICart cart, string purposeId)
        {
            cart.AddPurpose(new Guid(purposeId), 1);
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult DeletePurpose(ICart cart, string purposeId)
        {
            cart.DeletePurpose(new Guid(purposeId), 1);
            return Redirect(Request.UrlReferrer.ToString());
        }
        public RedirectToRouteResult DeleteAll(ICart cart)
        {
            cart.DeleteAllPurposes();
            return RedirectToAction("Index");
        }
    }
}