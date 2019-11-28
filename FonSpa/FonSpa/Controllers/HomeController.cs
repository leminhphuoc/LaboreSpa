using FonSpa.Filter;
using FonSpa.Services.IClientServices;
using FonSpa.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FonSpa.Controllers
{
    [CountVisitor]
    public class HomeController : Controller
    {

        private readonly IHomeServices _homeServices;
        //private readonly IContentServices _contentServices;

        public HomeController(IHomeServices homeServices)
        {
            _homeServices = homeServices;
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            //ViewBag.ListMenu = _homeServices.ListMenu();
            return View();
        }

        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = _homeServices.ListMenu();
            return PartialView(model);
        }
    }
}
