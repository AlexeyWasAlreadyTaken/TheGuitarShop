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
    public class PurposeController : Controller
    {
        ICatalog _catalog;
        public PurposeController(ICatalog cata)
        {
            _catalog = cata;
        }
        public ActionResult GetPurpose(Guid id)
        {
            IEnumerable<Purpose> C = _catalog.GetPurposeByID(id);
            IEnumerable<ConcretePurposeVM> purposeList = Enumerable.Empty<ConcretePurposeVM>();
            List<ConcretePurposeVM> pList = new List<ConcretePurposeVM>();

            foreach (Purpose curr in C)
            {
                ConcretePurposeVM buff = new ConcretePurposeVM();
                buff.purposeID = curr.id;
                buff.Brand = curr.Item.Brand.Name;
                buff.Name = curr.Item.Name;
                buff.Price = _catalog.GetPurposePriceByPuposeID(curr.id).price.ToString();
                buff.Curency = _catalog.GetPurposePriceByPuposeID(curr.id).Curency.Name; ;
                buff.description = curr.Item.Description;
                buff.Category = curr.Item.Category.Name;
                pList.Add(buff);
                buff = null;
            }
            purposeList = pList;
            var concretePurpose = purposeList.ToList()[0];
            return View(concretePurpose);
            //return View();
        }
    }
}