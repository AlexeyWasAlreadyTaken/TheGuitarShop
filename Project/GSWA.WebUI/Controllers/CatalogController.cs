﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GSWA.Domain;
using GSWA.Domain.Abstract;
using GSWA.Domain.Concrete;
using GSWA.WebUI.Models;

namespace GSWA.WebUI.Controllers
{
    public class CatalogController : Controller
    {

        ICatalog catalog;

        public CatalogController(ICatalog cata)
        {
            catalog = cata;
        }


        public ActionResult Categories()
        {
            IEnumerable<Category> C = catalog.GetGeneralCategoryList();
            IEnumerable<HomeIndexVM> H = Enumerable.Empty<HomeIndexVM>();
            List<HomeIndexVM> hilist = new List<HomeIndexVM>();

            foreach (Category n in C)
            {
                HomeIndexVM buff = new HomeIndexVM();
                buff.categoryid = n.id;
                buff.subCategoryId = n.ParentID;
                buff.categoryName = n.Name;
                hilist.Add(buff);
                buff = null;
            }
            H = hilist;
            return View(H);
        }

        public ActionResult SubCategories(Guid id)
        {
            IEnumerable<Category> C = catalog.GetChildCategoryByParentID(id);
            if (C.ToList().Count == 0)
            {
                return RedirectToAction("PurposesList", "Catalog", new { id = id });
            }
            IEnumerable<HomeIndexVM> H = Enumerable.Empty<HomeIndexVM>();
            List<HomeIndexVM> hilist = new List<HomeIndexVM>();

            foreach (Category n in C)
            {
                HomeIndexVM buff = new HomeIndexVM();
                buff.categoryid = n.id;
                buff.subCategoryId = n.ParentID;
                buff.categoryName = n.Name;
                hilist.Add(buff);
                buff = null;
            }
            H = hilist;
            return View(H);
        }

        public ActionResult PurposesList(Guid id,string st)
        {
            IEnumerable<Purpose> C = catalog.GetPurposesByCategoryID(id);
            IEnumerable<CatalogPurposeVM> purposeList = Enumerable.Empty<CatalogPurposeVM>();
            List<CatalogPurposeVM> pList = new List<CatalogPurposeVM>();

            foreach (Purpose curr in C)
            {
                CatalogPurposeVM buff = new CatalogPurposeVM();
                buff.purposeID = curr.id;
                buff.categoryID = id;
                buff.Brand = curr.Item.Brand.Name;
                buff.Name = curr.Item.Name;
                buff.Price = catalog.GetPurposePriceByPuposeID(curr.id).price;
                buff.Curency = catalog.GetPurposePriceByPuposeID(curr.id).Curency.Name;
                buff.Category = curr.Item.Category.Name;
                pList.Add(buff);
                buff = null;
            }
            purposeList = pList;
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

        public ActionResult FiltredPurposesList(Guid id, string st , string ft)
        {
            //id - category id
            //st - sort type
            //ft - filter type
            IEnumerable<Purpose> C = catalog.GetPurposesByCategoryID(id);
            IEnumerable<CatalogPurposeVM> purposeList = Enumerable.Empty<CatalogPurposeVM>();
            List<CatalogPurposeVM> pList = new List<CatalogPurposeVM>();

            foreach (Purpose curr in C)
            {
                
                CatalogPurposeVM buff = new CatalogPurposeVM();
                buff.purposeID = curr.id;
                buff.categoryID = id;
                buff.Brand = curr.Item.Brand.Name;
                buff.Name = curr.Item.Name;
                buff.Price = catalog.GetPurposePriceByPuposeID(curr.id).price;
                buff.Curency = catalog.GetPurposePriceByPuposeID(curr.id).Curency.Name;
                buff.Category = curr.Item.Category.Name;
                pList.Add(buff);
                buff = null;
            }
            purposeList = pList;
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