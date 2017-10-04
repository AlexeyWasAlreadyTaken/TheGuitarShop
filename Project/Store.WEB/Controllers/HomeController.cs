using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.BLL.Interfaces;
using Store.WEB.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Security.Claims;

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


        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        public ActionResult GetLoggedUserRole()
        {
            var currentUserRole = "";
            if (User.Identity.IsAuthenticated)
            {
                var userIdentity = (ClaimsIdentity)User.Identity;
                var claims = userIdentity.Claims;
                var roles = claims.Where(c => c.Type == ClaimTypes.Role).ToList();
                currentUserRole = roles.FirstOrDefault().Value;
            }
            else
                currentUserRole = "Is Not Authenticated";

            return PartialView("_GetLoggedUserRole",currentUserRole.ToUpper());
        }

        public ActionResult RoleRedirect()
        {
            
            var currentUserRole = "";
            if (User.Identity.IsAuthenticated)
            {
                var userIdentity = (ClaimsIdentity)User.Identity;
                var claims = userIdentity.Claims;
                var roles = claims.Where(c => c.Type == ClaimTypes.Role).ToList();
                currentUserRole = roles.FirstOrDefault().Value;
            }
            else
                currentUserRole = "Is Not Authenticated";



            switch (currentUserRole)
            {
                case "admin":
                    return RedirectToAction("Index", "ContentManagerAccount");
                    break;
                case "manager":
                    return RedirectToAction("Index", "OrderManager");
                    break;
                case "user":
                    return RedirectToAction("Index", "UserAccount");
                    break;
                case "Is Not Authenticated":
                    return RedirectToAction("Index", "Home");
                    break;

            }

            return RedirectToAction("Index", "Home");
        }
    }
}