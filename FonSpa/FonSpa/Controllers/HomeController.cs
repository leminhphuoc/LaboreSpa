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
            ViewBag.SlideList = _homeServices.ListSlide();
            ViewBag.roomsList = _homeServices.ListRoom();
            ViewBag.bedsList = _homeServices.ListBed();
            ViewBag.servicesList = _homeServices.ListServices();
            ViewBag.FooterCategories = _homeServices.ListFooterCategory();
            ViewBag.Footers = _homeServices.ListFooter();
            ViewBag.About = _homeServices.ListAbout();
            //ViewBag.ListMenu = _homeServices.ListMenu();
            return View();
        }

        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            ViewBag.BlogCategories = _homeServices.ListContentCategory();
            ViewBag.ServicesCategories = _homeServices.ListServiceCategory();
            ViewBag.ProductsCategories = _homeServices.ListProductCategories();
            var menus = _homeServices.ListMenu();
            return PartialView(menus);
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            ViewBag.FooterCategories = _homeServices.ListFooterCategory();
            var footers = _homeServices.ListFooter();
            return PartialView(footers);
        }
    }
}
