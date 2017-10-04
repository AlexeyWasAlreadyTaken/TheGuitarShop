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
        #region Init
        // GET: ContentManagerAccount
        private ICatalog _catalog;
        public ContentManagerAccountController(ICatalog catalog)
        {
            _catalog = catalog;
        }

        #endregion

        public ActionResult Index()
        {
            return View();
        }
        #region Category
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
        [HttpPost]
        public ActionResult CategoryEditor(CategoryVM category)
        {
            var updatedCategory = new CategoryDTO();
            updatedCategory.Id = category.categoryid;
            updatedCategory.Name = category.categoryName;
            updatedCategory.ParentCategoryID = category.parentCategoryId;
            _catalog.UpdateCategory(updatedCategory);
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
        public ActionResult UpdateCategory(Guid? id)
        {
            
            return View();
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
        public ActionResult AddCategoryCharacteristic(Guid? categoryID, Guid? charID)
        {
            // to do
            var categoryChar = new CategoryCharacteristicDTO();
            categoryChar.CategoryID = (Guid)categoryID;
            categoryChar.CharacteristicID = (Guid)charID;
            _catalog.CreateCategoryCharacteristic(categoryChar);
            return RedirectToAction("CategoryEditor", new { id = (Guid)categoryID });
        }
        public ActionResult CreateCharacteristic()
        {     
            return View();
        }
        [HttpPost]
        public ActionResult CreateCharacteristic(CharacteristicVM newCharacteristic)
        {
            var dto = new CharacteristicDTO();
            dto.Name = newCharacteristic.Name;
            _catalog.CreateCharacteristic(dto);
            return Redirect(Request.UrlReferrer.ToString()); //TO DO , doesnt work
           // return View();
        }
        public ActionResult UpdateCharacteristic(Guid? id)
        {
            var currentCharacteristic = _catalog.GetCharacteristicByID((Guid)id);
            var currentCharVM = new CharacteristicVM();
            currentCharVM.id = currentCharacteristic.Id;
            currentCharVM.Name = currentCharacteristic.Name;
            return View(currentCharVM);
        }
        [HttpPost]
        public ActionResult UpdateCharacteristic(CharacteristicVM characteristic)
        {

            var updatedCharDTO = new CharacteristicDTO();
            updatedCharDTO.Id = characteristic.id;
            updatedCharDTO.Name = characteristic.Name;
            _catalog.UpdateCharacteristic(updatedCharDTO);
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult CreateCharacteristicValue(Guid? id) 
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCharacteristicValue(CharValueVM newCharValue)   
        {
            var dto = new CharValueDTO();
            dto.CharacteristicId = newCharValue.CharacteristicId;
            dto.IntVal = newCharValue.IntVal;
            dto.StrVal = newCharValue.StrVal;
            dto.FloatVal = newCharValue.FloatVal;
            _catalog.CreateCharacteristicValue(dto);
            return RedirectToAction("GetCharacteristicsValues", "ContentManagerAccount", new { CharacteristicId = newCharValue.CharacteristicId });
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
            return View(currentCharacteristicValuesDTO);
        }
        public ActionResult DeleteCategoryCharacteristic(Guid? id)// to do
        {
            _catalog.DeleteCategoryCharacteristic(id);
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult DeleteCharacteristicValue(Guid? id) // to do
        {
            _catalog.DeleteCharacteristicValue(id);
            return Redirect(Request.UrlReferrer.ToString());
        }
        #endregion
        #region Items
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
        #endregion
        #region Purposes
        public ActionResult PurposesEditor(Guid? categoryId)
        {
            var categories = categoryId == null ? _catalog.GetGeneralCategoryList() : _catalog.GetChildCategoryByParentID((Guid)categoryId);
            var selectList = new SelectList(categories, "Id", "Name", new { Id = "", Name = "Select Category " });

            if (categoryId != null)
            {
                ViewBag.currentCategory = "Current category: " + _catalog.GetCategoryByID((Guid)categoryId).Name;
            }
            return View(selectList);
        }
        [HttpPost]
        public ActionResult PurposesEditorPost(Guid? categoryId) 
        {
            if (categoryId == null)
                return Redirect(Request.UrlReferrer.ToString());

            return RedirectToAction("PurposesEditor", new { categoryId = (Guid)categoryId });
        }
        public ActionResult GetPurposes(Guid categoryId)
        {
            var ultPurposes = _catalog.GetPurposeListByCategoryId(categoryId);
            var ultPurposeVMList = new List<UltimatePurposeVM>();
            foreach (var i in ultPurposes)
            {
                var ultPurposeVM = new UltimatePurposeVM();
                ultPurposeVM.PurposeId = i.PurposeId;

                if (i.ItemId != null)
                {
                    ultPurposeVM.ItemId = i.ItemId;
                    var currItem = _catalog.GetItemById((Guid)i.ItemId);
                    ultPurposeVM.ItemBrand = _catalog.GetBrandById((Guid)currItem.BrandID).Name;
                    ultPurposeVM.ItemName = currItem.Name;
                }
                ultPurposeVM.Price = i.Price;
                ultPurposeVM.IsPromo = (bool)i.IsPromo;
                ultPurposeVM.AvailabilityTypeID = i.AvailabilityTypeID;
                ultPurposeVM.CurencyID = i.CurencyID;
                ultPurposeVMList.Add(ultPurposeVM);
            }
            if (ultPurposeVMList.Any())
            {
                return PartialView(ultPurposeVMList);
            }
            else
            {
                return null;
            }
        }
        public ActionResult CreatePurpose(Guid categoryId, Guid? itemId)
        {
            var purposeVM = new UltimatePurposeVM();
            purposeVM.categoryId = categoryId;

            purposeVM.AvailabilityTypes = new SelectList(_catalog.GetAvailabilityTypeList(), "Id", "Name");
            purposeVM.CurrencyList = new SelectList(_catalog.GetCurrencyList(), "Id", "Name");
            if (itemId != null)
            {
                var item = _catalog.GetItemById((Guid)itemId);
                purposeVM.ItemId = item.Id;
                purposeVM.ItemName = item.Name;
                purposeVM.ItemBrand = _catalog.GetBrandById((Guid)item.BrandID).Name;
            }
            return View(purposeVM);
        }
        [HttpPost]
        public ActionResult CreatePurpose(UltimatePurposeVM ultimatePurposeVM)
        {
            var ultPurposeDTO = new UltimatePurposeDTO();
            ultPurposeDTO.ItemId = ultimatePurposeVM.ItemId;
            ultPurposeDTO.Price = ultimatePurposeVM.Price;
            ultPurposeDTO.IsPromo = ultimatePurposeVM.IsPromo;
            ultPurposeDTO.AvailabilityTypeID = ultimatePurposeVM.AvailabilityTypeID;
            ultPurposeDTO.CurencyID = ultimatePurposeVM.CurencyID;

            _catalog.CreateUltimatePurpose(ultPurposeDTO);
            return RedirectToAction("PurposesEditor", new { categoryId = ultimatePurposeVM.categoryId });
        }
        public ActionResult SelectItemToPurpose(Guid categoryId)
        {
            var items = _catalog.GetItemsByCategoryId(categoryId);
            var itemVMList = new List<ItemVM>();
            foreach (var i in items)
            {
                var itemVM = new ItemVM();
                itemVM.Id = i.Id;
                itemVM.Name = i.Name;
                itemVM.BrandName = _catalog.GetBrandById((Guid)i.BrandID).Name;
                itemVMList.Add(itemVM);
            }
            return View(itemVMList);
        }
        public ActionResult EditPurpose(Guid purposeId)
        {
            var purpose = _catalog.GetPurposeById(purposeId);
            var purposeVM = new UltimatePurposeVM();

            purposeVM.AvailabilityTypes = new SelectList(_catalog.GetAvailabilityTypeList(), "Id", "Name");
            purposeVM.CurrencyList = new SelectList(_catalog.GetCurrencyList(), "Id", "Name");
            purposeVM.PurposeId = purpose.PurposeId;
            purposeVM.AvailabilityTypeID = purpose.AvailabilityTypeID;
            purposeVM.Price = purpose.Price;
            purposeVM.ItemId = purpose.ItemId;
            purposeVM.IsPromo = (bool)purpose.IsPromo;
            purposeVM.CurencyID = purpose.CurencyID;

            var item = _catalog.GetItemById((Guid)purpose.ItemId);
            purposeVM.ItemBrand = _catalog.GetBrandById((Guid)item.BrandID).Name;
            purposeVM.ItemName = item.Name;
            purposeVM.categoryId = item.CategoryID;

            return View(purposeVM);
        }
        [HttpPost]
        public ActionResult EditPurpose(UltimatePurposeVM ultimatePurposeVM)
        {
            var ultPurposeDTO = new UltimatePurposeDTO();
            ultPurposeDTO.PurposeId = ultimatePurposeVM.PurposeId;
            ultPurposeDTO.ItemId = ultimatePurposeVM.ItemId;
            ultPurposeDTO.Price = ultimatePurposeVM.Price;
            ultPurposeDTO.IsPromo = ultimatePurposeVM.IsPromo;
            ultPurposeDTO.AvailabilityTypeID = ultimatePurposeVM.AvailabilityTypeID;
            ultPurposeDTO.CurencyID = ultimatePurposeVM.CurencyID;

            _catalog.UpdateUltimatePurpose(ultPurposeDTO);
            return RedirectToAction("PurposesEditor", new { categoryId = ultimatePurposeVM.categoryId });
        }
        public ActionResult DeletePurpose(Guid purposeId)
        {
            _catalog.RemoveUltimatePurpose(purposeId);
            return Redirect(Request.UrlReferrer.ToString());
        }
        #endregion
    }
}