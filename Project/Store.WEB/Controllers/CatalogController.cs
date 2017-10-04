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
            IEnumerable<CategoryDTO> categoryList = _catalog.GetGeneralCategoryList();
            IEnumerable<CategoryVM> categoryListVM = Enumerable.Empty<CategoryVM>();
            List<CategoryVM> hilist = new List<CategoryVM>();

            foreach (var i in categoryList)
            {
                CategoryVM buff = new CategoryVM();
                buff.CategoryId = i.Id;
                buff.ParentCategoryId = i.ParentCategoryID;
                buff.CategoryName = i.Name;
                hilist.Add(buff);
                buff = null;
            }
            categoryListVM = hilist;
            return View(categoryListVM);
        }
        public ActionResult SubCategories(Guid id)
        {
            var categoryList = _catalog.GetChildCategoryByParentID(id);
            if (categoryList.ToList().Count == 0)
            {
                return RedirectToAction("PurposesList", "Catalog", new { id = id });
            }
            IEnumerable<CategoryVM> categoryListVM = Enumerable.Empty<CategoryVM>();
            List<CategoryVM> hilist = new List<CategoryVM>();

            foreach (var i in categoryList)
            {
                CategoryVM buff = new CategoryVM();
                buff.CategoryId = i.Id;
                buff.ParentCategoryId = i.ParentCategoryID;
                buff.CategoryName = i.Name;
                hilist.Add(buff);
                buff = null;
            }
            categoryListVM = hilist;
            return View(categoryListVM);
        }
        public ActionResult PurposesList(Guid id, string st)
        {
            var purposeDTOList = _catalog.GetPurposesByCategoryID(id);
            var purposeVMList = Enumerable.Empty<CatalogPurposeVM>();
            List<CatalogPurposeVM> pList = new List<CatalogPurposeVM>();

            foreach (var i in purposeDTOList)
            {
                CatalogPurposeVM buff = new CatalogPurposeVM();
                buff.PurposeID = i.PurposeID;
                buff.CategoryID = id;
                buff.Brand = i.Brand;
                buff.Name = i.Name;
                buff.Price = i.Price;
                buff.Curency = i.Curency;
                buff.Category = i.CategoryName;

                pList.Add(buff);
                buff = null;
            }
            purposeVMList = pList;

            if (String.IsNullOrEmpty(st))
                st = "ByPrice";

            switch (st)
            {
                case "ByName":
                    purposeVMList = purposeVMList.OrderBy(x => x.Name).Distinct();
                    break;
                case "ByPrice":
                    purposeVMList = purposeVMList.OrderBy(x => x.Price);
                    break;
                case "ByBrand":
                    purposeVMList = purposeVMList.OrderBy(x => x.Brand);
                    break;
            }

            return View(purposeVMList);
        }

        public ActionResult GetFilters(Guid categoryId)
        {
            var characteristics = _catalog.GetAllChainCategoryCharacteristics(categoryId);
            var filterVMList = new List<FilterVM>();
            foreach (var i in characteristics)
            {
                var filterVM = new FilterVM();
                filterVM.CharacteristicId = i.Characteristic.Id;
                filterVM.CharacteristicName = i.Characteristic.Name;
                
                var filterCharValues = _catalog.GetCharValuesByCharacteristicId(filterVM.CharacteristicId);
                filterVM.ValuesList = new List<FilterCharValueVM>();
                foreach (var j in filterCharValues)
                {
                    var buff = new FilterCharValueVM();
                    buff.Id = j.Id;
                    buff.CharacteristicId = j.CharacteristicId;
                    buff.IntVal = j.IntVal;
                    buff.FloatVal = j.FloatVal;
                    buff.StrVal = j.StrVal;
                    filterVM.ValuesList.Add(buff);
                }
                filterVMList.Add(filterVM);
            }

            return PartialView(filterVMList);
        }
        [HttpPost]
        public ActionResult PurposesList(Guid id, string st, IList<FilterVM> filterVMs)
        {
            var charValueDTOList = new List<CharValueDTO>();
            foreach (var i in filterVMs)
            {
                foreach (var j in i.ValuesList)
                {
                    if (j.isApplied)
                    {
                        var buff = new CharValueDTO();
                        buff.Id = j.Id;
                        buff.CharacteristicId = j.CharacteristicId;
                        buff.IntVal = j.IntVal;
                        buff.FloatVal = j.FloatVal;
                        buff.StrVal = j.StrVal;
                        charValueDTOList.Add(buff);
                    }
                }
            }
            var purposes = _catalog.GetPurposesByCharValues((Guid)id, charValueDTOList);

            var purposeList = new List<CatalogPurposeVM>();
            foreach (var curr in purposes)
            {
                CatalogPurposeVM buff = new CatalogPurposeVM();
                buff.PurposeID = curr.PurposeID;
                buff.CategoryID = id;
                buff.Brand = curr.Brand;
                buff.Name = curr.Name;
                buff.Price = curr.Price;
                buff.Curency = curr.Curency;
                buff.Category = curr.CategoryName;

                purposeList.Add(buff);
                buff = null;
            }
            if (String.IsNullOrEmpty(st))
                st = "ByPrice";

            switch (st)
            {
                case "ByName":
                    purposeList = purposeList.OrderBy(x => x.Name).Distinct().ToList();
                    break;
                case "ByPrice":
                    purposeList = purposeList.OrderBy(x => x.Price).ToList();
                    break;
                case "ByBrand":
                    purposeList = purposeList.OrderBy(x => x.Brand).ToList();
                    break;
            }

            return View(purposeList);
        }
        
        

    }
}