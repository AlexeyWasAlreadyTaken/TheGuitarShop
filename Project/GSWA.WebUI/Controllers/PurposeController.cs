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
            var _temp = _catalog.GetCharacterististicByItemId((Guid)C.FirstOrDefault().ItemId);
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

                buff.charname = new List<string>();
                buff.charvalue = new List<string>();

                foreach (ItemCharacteristic item in _temp)
                {
                    var charval = ""; 
                    if (item.CharValue.intVal != null)
                        charval = item.CharValue.intVal.ToString();
                    if (item.CharValue.floatVal != null)
                        charval = item.CharValue.floatVal.ToString();
                    if (item.CharValue.strVal != null)
                        charval = item.CharValue.strVal;

                    buff.charname.Add(item.Characteristic.Name);
                    buff.charvalue.Add(charval);
                }


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