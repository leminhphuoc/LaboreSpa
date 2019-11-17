using FonSpa.Filter;
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
        private readonly IProductAdminSerivces _productAdminServices;
        private readonly IServicesAdminServices _servicesAdminServices;
        //private readonly IContentServices _contentServices;

        public HomeController(IProductAdminSerivces productAdminServices, IServicesAdminServices servicesAdminServices , IContentServices contentServices)
        {

            _productAdminServices = productAdminServices;
            _servicesAdminServices = servicesAdminServices;
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}
