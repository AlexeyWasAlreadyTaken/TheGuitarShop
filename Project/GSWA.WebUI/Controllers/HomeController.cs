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
        public ActionResult Index()
        {
            return View();            
        }

        public ActionResult News()
        {
            return View();
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
    }
}