using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Store.BLL.Interfaces;

namespace Store.WEB.Infrastructure
{
    public class CartModelBinder : IModelBinder
    {
        private const string CARTKEY = "cart";
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ICart cart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cart = (ICart)controllerContext.HttpContext.Session[CARTKEY];
            }
            if (cart == null)
            {
                cart = (ICart)DependencyResolver.Current.GetService(typeof(ICart));
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[CARTKEY] = cart;
                }
            }
            return cart;
        }
    }
}