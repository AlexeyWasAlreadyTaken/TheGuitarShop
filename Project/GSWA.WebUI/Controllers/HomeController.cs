using System;
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
    public class HomeController : Controller
    {
        private INewsManager _newsManager;

        public HomeController(INewsManager newsManager)
        {
            _newsManager = newsManager;
        }

        public ActionResult Index()
        {
            return View();            
        }
        public ActionResult News()
        {
            var news = _newsManager.GetNews();
            var homeNewsVMList = new List<HomeNewsVM>();
            foreach (var n in news)
            {
                var homeNewsVM = new HomeNewsVM();
                homeNewsVM.Id = n.id;
                homeNewsVM.Name = n.name;
                homeNewsVM.Description = n.description;
                homeNewsVM.Date = n.date;
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