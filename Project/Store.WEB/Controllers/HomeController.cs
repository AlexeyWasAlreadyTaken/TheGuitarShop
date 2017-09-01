using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.BLL.Interfaces;
using Store.WEB.Models;

namespace Store.WEB.Controllers
{
    public class HomeController : Controller
    {

        INewsManager _newsManager;
        public HomeController(INewsManager newsManager)
        {
            _newsManager = newsManager;
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
           // return RedirectToAction("Categories", "Catalog");
        }
        public ActionResult News()
        {
            var news = _newsManager.GetNews();
            var homeNewsVMList = new List<HomeNewsVM>();
            foreach (var n in news)
            {
                var homeNewsVM = new HomeNewsVM();
                homeNewsVM.Id = n.Id;
                homeNewsVM.Name = n.Name;
                homeNewsVM.Description = n.Description;
                homeNewsVM.Date = n.Date;
                homeNewsVMList.Add(homeNewsVM);
            }
            return View(homeNewsVMList);
        }


        public ActionResult Delivery()
        {
            return View();
        }
        public ActionResult Payment()
        {
            return View();
        }

        public ActionResult Contacts()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult GetHeader()
        {
            return PartialView();
        }

        public ActionResult GetNav()
        {
            return PartialView("_GetNav");
        }
    }
}