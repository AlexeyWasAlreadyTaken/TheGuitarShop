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
            buff.purposeID = currentPurposeDTO.purposeID;
            buff.Brand = currentPurposeDTO.Brand;
            buff.Name = currentPurposeDTO.Name;
            buff.Price =  currentPurposeDTO.Price.ToString();
            buff.Curency = currentPurposeDTO.Curency;
            buff.description = currentPurposeDTO.Description;
            buff.Category = currentPurposeDTO.CategoryName;
            //TO DO dictionary
            buff.charname = currentPurposeDTO.charname;
            buff.charvalue = currentPurposeDTO.charvalue;
            return View(buff);
        }
    }
}