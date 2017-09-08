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
    }
}