using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.BLL.Interfaces;
using Store.WEB.Models;
using Store.BLL.DTO;

namespace Store.WEB.Controllers
{
    public class PurposeController : Controller
    {
        ICatalog _catalog;
        public PurposeController(ICatalog cata)
        {
            _catalog = cata;
        }
        public ActionResult GetPurpose(Guid id)
        {
            var currentPurposeDTO = _catalog.GetPurposeByID(id);
            ConcretePurposeVM buff = new ConcretePurposeVM();
            buff.PurposeID = currentPurposeDTO.PurposeID;
            buff.Brand = currentPurposeDTO.Brand;
            buff.Name = currentPurposeDTO.Name;
            buff.Price =  currentPurposeDTO.Price.ToString();
            buff.Currency = currentPurposeDTO.Curency;
            buff.Description = currentPurposeDTO.Description;
            buff.Category = currentPurposeDTO.CategoryName;
            buff.CharName = currentPurposeDTO.CharName;
            buff.CharValue = currentPurposeDTO.CharValue;
            return View(buff);
        }
    }
}