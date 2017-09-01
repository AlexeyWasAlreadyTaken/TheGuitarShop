using Store.BLL.Interfaces;
using Store.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.WEB.Controllers
{
    public class CartController : Controller
    {
        public ActionResult Index(ICart cart)
        {
            var orderItems = cart.GetOrderItems();
            var CartIndexVMList = new List<CartIndexVM>();
            foreach (var orderItemDTO in orderItems)
            {
                CartIndexVM cartIndexVM = new CartIndexVM();
                cartIndexVM.PurposeId = orderItemDTO.PurposeId;
                cartIndexVM.ItemId = orderItemDTO.ItemId;
                cartIndexVM.BrandName = orderItemDTO.BrandName;
                cartIndexVM.ItemName = orderItemDTO.ItemName;
                cartIndexVM.IsPromo = orderItemDTO.IsPromo;
                cartIndexVM.Count = orderItemDTO.Count;
                cartIndexVM.Price = orderItemDTO.Price;
                cartIndexVM.Currency = orderItemDTO.Currency;
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