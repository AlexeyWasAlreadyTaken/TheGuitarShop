using Store.BLL.DTO;
using Store.BLL.Interfaces;
using Store.WEB.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.WEB.Controllers
{
    public class ContentManagerAccountController : Controller
    {
        // GET: ContentManagerAccount
        private ICatalog _catalog;
        public ContentManagerAccountController(ICatalog catalog)
        {
            _catalog = catalog;
        }



        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CategoryEditorNavigation(Guid? id)
        {
            var categoryList = new List<CategoryVM>();
            var catalogCategoryList = new List<CategoryDTO>();
            if (id == null)
            {
                catalogCategoryList = _catalog.GetGeneralCategoryList().ToList();
            }
            else
            {
                catalogCategoryList = _catalog.GetChildCategoryByParentID((Guid)id).ToList();
            }


            if (catalogCategoryList.Count != 0)
            {
                foreach (var i in catalogCategoryList)
                {
                    var buff = new CategoryVM();
                    buff.categoryid = i.Id;
                    buff.categoryName = i.Name;
                    buff.parentCategoryId = i.ParentCategoryID;
                    categoryList.Add(buff);
                }
            }
            else
            {
                return RedirectToAction("CategoryEditor", "ContentManagerAccount", new { id = id });
            }

            return View(categoryList);
        }

        public ActionResult CategoryEditor(Guid? id)
        {
            var category = new CategoryVM();
            if (id != null)
            {                
                var i = _catalog.GetCategoryBytID((Guid)id);
                category.categoryid = i.Id;
                category.categoryName = i.Name;
                category.parentCategoryId = i.ParentCategoryID;
            }
            else
            {
                //debug
                category = new CategoryVM() {categoryid = new Guid("00000000-0000-0000-0000-000000000000"),categoryName = "NULL", parentCategoryId = new Guid("00000000-0000-0000-0000-000000000000") };
            }
            return View(category);
        }

        public ActionResult GetCharacteristics(Guid? id)
        {
            var categoryCharacteristic = _catalog.GetCategoryCharacteristics((Guid)id);
            var categoryCharacteristicList = new List<CategoryCharacteristicVM>();

            foreach (var i in categoryCharacteristic)
            {
                var buff = new CategoryCharacteristicVM();
                buff.Id = i.Id;
                buff.CategoryID = i.CategoryID;
                buff.CharacteristicID = i.CharacteristicID;
                buff.CharacteristicName = i.Characteristic.Name;
                categoryCharacteristicList.Add(buff);
            }
            return PartialView(categoryCharacteristicList);
        }



        public ActionResult GetItems(Guid categoryId)
        {
            var items = _catalog.GetItemsByCategoryId(categoryId);
            var itemVMList = new List<ItemVM>();
            foreach (var i in items)
            {
                var itemVM = new ItemVM();
                itemVM.Id = i.Id;
                itemVM.Name = i.Name;
                itemVM.Description = i.Description;
                itemVM.CategoryID = i.CategoryID;
                itemVM.BrandID = i.BrandID;
                itemVM.BrandCountryID = i.BrandCountryID;
                itemVM.BrandName = _catalog.GetBrandById((Guid)i.BrandID).Name; //?
                itemVM.ManufCountryID = i.ManufCountryID;
                itemVMList.Add(itemVM);
            }
            return View(itemVMList);
        }
        public ActionResult EditItem(Guid itemId)
        {
            var item = _catalog.GetItemById(itemId);
            var itemVM = new ItemVM();
            itemVM.Id = item.Id;
            itemVM.Name = item.Name;
            itemVM.Description = item.Description;
            itemVM.CategoryID = item.CategoryID;
            itemVM.BrandID = item.BrandID;
            itemVM.BrandCountryID = item.BrandCountryID;
            itemVM.ManufCountryID = item.ManufCountryID;

            var brands = _catalog.GetBrands();
            itemVM.Brands = new SelectList(brands, "Id", "Name");

            var countries = _catalog.GetCountries();
            itemVM.BrandCountries = new SelectList(countries, "Id", "Name");
            itemVM.ManufCountries = new SelectList(countries, "Id", "Name");

            return View(itemVM);
        }
        [HttpPost]
        public ActionResult EditItem(ItemVM itemVM)
        {
            // TO DO 
            // validation here

            var itemDTO = new ItemDTO();
            itemDTO.Id = itemVM.Id;
            itemDTO.Name = itemVM.Name;
            itemDTO.Description = itemVM.Description;
            itemDTO.CategoryID = itemVM.CategoryID;
            itemDTO.BrandID = itemVM.BrandID;
            itemDTO.BrandCountryID = itemVM.BrandCountryID;
            itemDTO.ManufCountryID = itemVM.ManufCountryID;
            _catalog.UpdateItem(itemDTO);
            
            return RedirectToAction("Index");
        }

        public ActionResult EditItemCharacteristics(Guid itemId, Guid categoryId)
        {
            var categoryCharacteristics = _catalog.GetCategoryCharacteristics(categoryId);
            var itemCharacteristics = _catalog.GetItemCharacteristicsByItemId(itemId);

            var itemCharacteristicVMList = new List<ItemCharacteristicVM>();
            foreach (var i in categoryCharacteristics)
            {
                var itemCharacteristicVM = new ItemCharacteristicVM();
                itemCharacteristicVM.IsApplied = false;

                itemCharacteristicVM.CharacteristicID = i.Characteristic.Id;
                itemCharacteristicVM.CharacteristicName = i.Characteristic.Name;
                var charValues = _catalog.GetCharValuesByCharacteristicId(i.Characteristic.Id);
                
                itemCharacteristicVM.ItemID = itemId;

                var itemCharateristicForCurrent = itemCharacteristics.Where(ic => ic.CharacteristicID == i.Characteristic.Id).FirstOrDefault();

                if (itemCharateristicForCurrent != null)
                {
                    itemCharacteristicVM.IsApplied = true;
                    itemCharacteristicVM.Id = itemCharateristicForCurrent.Id;
                    itemCharacteristicVM.CharValueID = itemCharateristicForCurrent.CharValueID;
                }

                itemCharacteristicVM.CharValues =
                    new SelectList(charValues, "Id",
                    charValues.FirstOrDefault().IntVal != null ? "IntVal" :
                    charValues.FirstOrDefault().FloatVal != null ? "FloatVal" :
                    "StrVal", itemCharacteristicVM.CharValueID); // TO DO

                itemCharacteristicVMList.Add(itemCharacteristicVM);
            }
            return View(itemCharacteristicVMList);
        }
        [HttpPost]
        public ActionResult EditItemCharacteristics(IList<ItemCharacteristicVM> itemCharacteristicVMs)
        {
            // TO DO
            if (itemCharacteristicVMs == null || !itemCharacteristicVMs.Any())
                return RedirectToAction("Index");
            
            foreach (var i in itemCharacteristicVMs)
            {
                var itemCharacteristicDTO = new ItemCharacteristicDTO();
                itemCharacteristicDTO.Id = i.Id;
                itemCharacteristicDTO.ItemID = i.ItemID;
                itemCharacteristicDTO.CharacteristicID = i.CharacteristicID;
                itemCharacteristicDTO.CharacteristicName = i.CharacteristicName;
                itemCharacteristicDTO.CharValueID = i.CharValueID;

                if (i.IsApplied)
                {
                    if (i.Id != null)
                    {
                        _catalog.UpdateItemCharacteristic(itemCharacteristicDTO);
                    }
                    else
                    {
                        _catalog.CreateItemCharacteristic(itemCharacteristicDTO);
                    }
                }
                else if(i.Id != null)
                {
                    _catalog.DeleteItemCharacteristic(itemCharacteristicDTO);
                }
            }
            
            return RedirectToAction("Index");
        }

    }
}