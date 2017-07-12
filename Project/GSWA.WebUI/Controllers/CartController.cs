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
        private ICart _newCart; //TO DO

        public CartController(ICart cart)
        {
            _newCart = cart;
        }
        private ICart GetCart()
        {
            //***TO DO***
            if (Session["cart"] == null)
            {
                Session["cart"] = _newCart;
            }
            return (ICart)Session["cart"];
            //***TO DO***
        }

        public ActionResult Index()
        {
            var cartLines = GetCart().GetCartLines();
            var CartIndexVMCollection = new List<CartIndexVM>();
            foreach (var cl in cartLines)
            {
                CartIndexVM cartIndexVM = new CartIndexVM
                {
                    PurposeId = cl.Purpose.id,
                    ItemId = cl.Purpose.ItemId,
                    BrandName = cl.Purpose.Item.Brand.Name,
                    ItemName = cl.Purpose.Item.Name,
                    IsPromo = cl.Purpose.IsPromo,
                    Count = cl.Count,
                    Price = cl.PurposePrice.price * cl.Count,
                    Currency = cl.PurposePrice.Curency.Name
                };
                CartIndexVMCollection.Add(cartIndexVM);
            }
            return View(CartIndexVMCollection);
        }
        public ActionResult AddPurpose(string purposeId)
        {
            GetCart().AddPurpose(new Guid(purposeId), 1);
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult DeletePurpose(string purposeId)
        {
            GetCart().DeletePurpose(new Guid(purposeId), 1);
            return Redirect(Request.UrlReferrer.ToString());
        }
        public RedirectToRouteResult DeleteAll()
        {
            GetCart().DeleteAllPurposes();
            return RedirectToAction("Index");
        }
    }
}