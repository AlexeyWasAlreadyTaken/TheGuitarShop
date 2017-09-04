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
            var orderItemVMList = new List<OrderItemVM>();
            foreach (var orderItemDTO in orderItems)
            {
                OrderItemVM orderItemVM = new OrderItemVM();
                orderItemVM.PurposeId = orderItemDTO.PurposeId;
                orderItemVM.ItemId = orderItemDTO.ItemId;
                orderItemVM.BrandName = orderItemDTO.BrandName;
                orderItemVM.ItemName = orderItemDTO.ItemName;
                orderItemVM.IsPromo = orderItemDTO.IsPromo;
                orderItemVM.Count = orderItemDTO.Count;
                orderItemVM.Price = orderItemDTO.Price;
                orderItemVM.Currency = orderItemDTO.Currency;
                orderItemVMList.Add(orderItemVM);
            }
            return View(orderItemVMList);
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