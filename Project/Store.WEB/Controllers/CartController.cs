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
                OrderItemVM buff = new OrderItemVM();
                buff.PurposeId = orderItemDTO.PurposeId;
                buff.ItemId = orderItemDTO.ItemId;
                buff.BrandName = orderItemDTO.BrandName;
                buff.ItemName = orderItemDTO.ItemName;
                buff.IsPromo = orderItemDTO.IsPromo;
                buff.Count = orderItemDTO.Count;
                buff.Price = orderItemDTO.Price;
                buff.Currency = orderItemDTO.Currency;
                orderItemVMList.Add(buff);
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