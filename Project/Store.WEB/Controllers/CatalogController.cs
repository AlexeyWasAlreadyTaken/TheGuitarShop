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
    public class CatalogController : Controller
    {
        // GET: Catalog

        ICatalog _catalog;
        
        public CatalogController(ICatalog cata)
        {
            _catalog = cata;
        }


        public ActionResult Categories()
        {
            IEnumerable<CategoryDTO> C = _catalog.GetGeneralCategoryList();
            IEnumerable<CategoryVM> H = Enumerable.Empty<CategoryVM>();
            List<CategoryVM> hilist = new List<CategoryVM>();

            foreach (var n in C)
            {
                CategoryVM buff = new CategoryVM();
                buff.categoryid = n.Id;
                buff.parentCategoryId = n.ParentCategoryID;
                buff.categoryName = n.Name;
                hilist.Add(buff);
                buff = null;
            }
            H = hilist;
            return View(H);
        }


        public ActionResult SubCategories(Guid id)
        {
            var C = _catalog.GetChildCategoryByParentID(id);
            if (C.ToList().Count == 0)
            {
                return RedirectToAction("PurposesList", "Catalog", new { id = id });
            }
            IEnumerable<CategoryVM> H = Enumerable.Empty<CategoryVM>();
            List<CategoryVM> hilist = new List<CategoryVM>();

            foreach (var n in C)
            {
                CategoryVM buff = new CategoryVM();
                buff.categoryid = n.Id;
                buff.parentCategoryId = n.ParentCategoryID;
                buff.categoryName = n.Name;
                hilist.Add(buff);
                buff = null;
            }
            H = hilist;
            return View(H);
        }

        public ActionResult PurposesList(Guid id, string st)
        {
            var C = _catalog.GetPurposesByCategoryID(id);
            var purposeList = Enumerable.Empty<CatalogPurposeVM>();
            List<CatalogPurposeVM> pList = new List<CatalogPurposeVM>();

            foreach (var curr in C)
            {
                CatalogPurposeVM buff = new CatalogPurposeVM();
                buff.purposeID = curr.purposeID;
                buff.categoryID = id;
                buff.Brand = curr.Brand;
                buff.Name = curr.Name;
                buff.Price = curr.Price;
                buff.Curency = curr.Curency;
                buff.Category = curr.CategoryName;

                pList.Add(buff);
                buff = null;
            }
            purposeList = pList;

            // 8====3
            if (String.IsNullOrEmpty(st))
                st = "ByPrice";

            switch (st)
            {
                case "ByName":
                    purposeList = purposeList.OrderBy(x => x.Name).Distinct();
                    break;
                case "ByPrice":
                    purposeList = purposeList.OrderBy(x => x.Price);
                    break;
                case "ByBrand":
                    purposeList = purposeList.OrderBy(x => x.Brand);
                    break;
            }

            return View(purposeList);
        }

    }
}