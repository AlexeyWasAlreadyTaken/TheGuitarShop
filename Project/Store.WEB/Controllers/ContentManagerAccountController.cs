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
                var i = _catalog.GetCategoryByID((Guid)id);
                category.categoryid = i.Id;
                category.categoryName = i.Name;
                category.parentCategoryId = i.ParentCategoryID;
            }
            else
            {
                //debug
                category = new CategoryVM() { categoryid = new Guid("00000000-0000-0000-0000-000000000000"), categoryName = "NULL", parentCategoryId = new Guid("00000000-0000-0000-0000-000000000000") };
            }
            return View(category);
        }


        public ActionResult CreateCategory(Guid? id)
        {
            var pc = id;//parentcategory
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(Guid? id, CategoryVM category)
        {
            var pc = id;//parentcategory
            var buff = new CategoryDTO();
            buff.Name = category.categoryName;
            //   buff.Id = category.categoryid;
            buff.ParentCategoryID = id;//category.parentCategoryId;
            _catalog.CreateCategory(buff);
            return Redirect(Request.UrlReferrer.ToString());
        }



        public ActionResult GetCharacteristics(Guid? id)
        {
            var categoryCharacteristic = _catalog.GetCurrentCategoryCharacteristics((Guid)id);
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


        public ActionResult EditCategoryCharacteristic(Guid CharacteristicId)
        {
            var currentCharacteristic = _catalog.GetCharacteristicByID(CharacteristicId);
            var characteristic = new CharacteristicVM();
            characteristic.id = currentCharacteristic.Id;
            characteristic.Name = currentCharacteristic.Name;
            return View(characteristic);
        }
        public ActionResult GetCharacteristicsValues(Guid CharacteristicId)
        {
            var currentCharacteristicValues = _catalog.GetCharValuesByCharacteristicId(CharacteristicId);
            var currentCharacteristicValuesDTO = new List<CharValueVM>();
            foreach (var i in currentCharacteristicValues)
            {
                var buff = new CharValueVM();
                buff.Id = i.Id;
                buff.StrVal = i.StrVal;
                buff.IntVal = i.IntVal;
                buff.FloatVal = i.FloatVal;
                buff.CharacteristicId = CharacteristicId;
                currentCharacteristicValuesDTO.Add(buff);
            }
            return PartialView(currentCharacteristicValuesDTO);
        }

        public ActionResult AddCategoryCharacteristic(Guid? categoryID,Guid? charID)
        {
            // to do
            var categoryChar = new CategoryCharacteristicDTO();
            categoryChar.CategoryID = (Guid)categoryID;
            categoryChar.CharacteristicID = (Guid)charID;
            _catalog.CreateCategoryCharacteristic(categoryChar);
            return RedirectToAction("CategoryEditor", new { id = (Guid)categoryID });
        }

        public ActionResult CreateCategoryCharacteristic(Guid? categoryID)
        {
            var ALL = new List<CharacteristicVM>();
            var NOTNEED = new List<CharacteristicVM>();
            var FINAL = new List<CharacteristicVM>();
            var allCharacteristic = _catalog.GetAllCharacteristic();

            if (_catalog.GetAllChainCategoryCharacteristics((Guid)categoryID) == null)
            {
                foreach (var i in allCharacteristic)
                {
                    var buff = new CharacteristicVM();
                    buff.id = i.Id;
                    buff.Name = i.Name;
                    ALL.Add(buff);
                }
                return View(ALL);
            }

            var alreadyExistCharacteristic = _catalog.GetAllChainCategoryCharacteristics((Guid)categoryID);
            

            
            

           

            foreach (var i in allCharacteristic)
            {
                var buff = new CharacteristicVM();
                buff.id = i.Id;
                buff.Name = i.Name;
                ALL.Add(buff);
            }

            foreach (var i in alreadyExistCharacteristic)
            {
                var buff = new CharacteristicVM();
                buff.id = i.CharacteristicID;
                buff.Name = "";
                NOTNEED.Add(buff);
            }

            foreach (var i in ALL)
            {
                if (NOTNEED.Contains(i))
                {
                  
                }
                else
                {
                   if (!FINAL.Contains(i))
                        FINAL.Add(i);
                }
            }

            return View(FINAL);
        }

        public ActionResult ItemsEditor(Guid? categoryId)
        {
            //TO DO
            var categories = categoryId == null ? _catalog.GetGeneralCategoryList() : _catalog.GetChildCategoryByParentID((Guid)categoryId);
            var selectList = new SelectList(categories, "Id", "Name", new { Id = "", Name = "Select Category " });

            if (categoryId != null)
            {
                ViewBag.currentCategory = "Current category: " + _catalog.GetCategoryByID((Guid)categoryId).Name;
            }
            return View(selectList);
        }
        [HttpPost]
        public ActionResult ItemsEditorPost(Guid? categoryId) // Delete me later
        {
            if (categoryId == null)
                return Redirect(Request.UrlReferrer.ToString());

            return RedirectToAction("ItemsEditor", new { categoryId = (Guid)categoryId });
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
            if (itemVMList.Any())
            {
                return PartialView(itemVMList);
            }
            else
            {
                return null;
            }
        }

        public ActionResult CreateItem(Guid categoryId)
        {
            var itemVM = new ItemVM();
            itemVM.CategoryID = categoryId;

            var brands = _catalog.GetBrands();
            itemVM.Brands = new SelectList(brands, "Id", "Name");
            var countries = _catalog.GetCountries();
            itemVM.BrandCountries = new SelectList(countries, "Id", "Name");
            itemVM.ManufCountries = new SelectList(countries, "Id", "Name");

            return View(itemVM);
        }
        [HttpPost]
        public ActionResult CreateItem(ItemVM itemVM)
        {
            if (string.IsNullOrEmpty(itemVM.Name))
                ModelState.AddModelError("Name", "Fill name");
            if (string.IsNullOrEmpty(itemVM.CategoryID.ToString()))
                ModelState.AddModelError("CategoryId", "Category must be chosen!");
            if (string.IsNullOrEmpty(itemVM.Description))
                ModelState.AddModelError("Description", "Fill description");
            if (string.IsNullOrEmpty(itemVM.BrandID.ToString()))
                ModelState.AddModelError("BrandID", "Choose brand");
            if (string.IsNullOrEmpty(itemVM.ManufCountryID.ToString()))
                ModelState.AddModelError("ManufCountryID", "Choose manuf country");
            if (string.IsNullOrEmpty(itemVM.BrandCountryID.ToString()))
                ModelState.AddModelError("BrandCountryID", "Choose brand country");

            if (ModelState.IsValid)
            {
                var itemDTO = new ItemDTO();
                itemDTO.CategoryID = itemVM.CategoryID;
                itemDTO.Name = itemVM.Name;
                itemDTO.ManufCountryID = itemVM.ManufCountryID;
                itemDTO.Description = itemVM.Description;
                itemDTO.BrandID = itemVM.BrandID;
                itemDTO.BrandCountryID = itemVM.BrandCountryID;
                _catalog.CreateItem(itemDTO);
                return RedirectToAction("ItemsEditor", new { categoryId = itemVM.CategoryID });
            }

            var brands = _catalog.GetBrands();
            itemVM.Brands = new SelectList(brands, "Id", "Name");
            var countries = _catalog.GetCountries();
            itemVM.BrandCountries = new SelectList(countries, "Id", "Name");
            itemVM.ManufCountries = new SelectList(countries, "Id", "Name");
            return View(itemVM);
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
            if (string.IsNullOrEmpty(itemVM.Name))
                ModelState.AddModelError("Name", "Fill name");
            if (string.IsNullOrEmpty(itemVM.CategoryID.ToString()))
                ModelState.AddModelError("CategoryId", "Category must be chosen!");
            if (string.IsNullOrEmpty(itemVM.Description))
                ModelState.AddModelError("Description", "Fill description");
            if (string.IsNullOrEmpty(itemVM.BrandID.ToString()))
                ModelState.AddModelError("BrandID", "Choose brand");
            if (string.IsNullOrEmpty(itemVM.ManufCountryID.ToString()))
                ModelState.AddModelError("ManufCountryID", "Choose manuf country");
            if (string.IsNullOrEmpty(itemVM.BrandCountryID.ToString()))
                ModelState.AddModelError("BrandCountryID", "Choose brand country");

            if (ModelState.IsValid)
            {
                var itemDTO = new ItemDTO();
                itemDTO.Id = itemVM.Id;
                itemDTO.Name = itemVM.Name;
                itemDTO.Description = itemVM.Description;
                itemDTO.CategoryID = itemVM.CategoryID;
                itemDTO.BrandID = itemVM.BrandID;
                itemDTO.BrandCountryID = itemVM.BrandCountryID;
                itemDTO.ManufCountryID = itemVM.ManufCountryID;
                _catalog.UpdateItem(itemDTO);
                return RedirectToAction("ItemsEditor", new { categoryId = itemVM.CategoryID });
            }

            var brands = _catalog.GetBrands();
            itemVM.Brands = new SelectList(brands, "Id", "Name");
            var countries = _catalog.GetCountries();
            itemVM.BrandCountries = new SelectList(countries, "Id", "Name");
            itemVM.ManufCountries = new SelectList(countries, "Id", "Name");
            return View(itemVM);
        }

        public ActionResult EditItemCharacteristics(Guid itemId, Guid categoryId)
        {
            var categoryCharacteristics = _catalog.GetAllChainCategoryCharacteristics(categoryId);
            var itemCharacteristics = _catalog.GetItemCharacteristicsByItemId(itemId);

            var itemCharacteristicVMList = new List<ItemCharacteristicVM>();
            foreach (var i in categoryCharacteristics)
            {
                var itemCharacteristicVM = new ItemCharacteristicVM();

                itemCharacteristicVM.CharacteristicID = i.Characteristic.Id;
                itemCharacteristicVM.CharacteristicName = i.Characteristic.Name;
                var charValues = _catalog.GetCharValuesByCharacteristicId(i.Characteristic.Id);

                itemCharacteristicVM.ItemID = itemId;

                var itemCharateristicForCurrent = itemCharacteristics.Where(ic => ic.CharacteristicID == i.Characteristic.Id).FirstOrDefault();

                if (itemCharateristicForCurrent != null)
                {
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

                if (itemCharacteristicDTO.Id != null)
                {
                    _catalog.UpdateItemCharacteristic(itemCharacteristicDTO);
                }
                else
                {
                    _catalog.CreateItemCharacteristic(itemCharacteristicDTO);
                }
            }

            return RedirectToAction("EditItem", new { itemId = itemCharacteristicVMs.FirstOrDefault().ItemID });
        }

    }
}