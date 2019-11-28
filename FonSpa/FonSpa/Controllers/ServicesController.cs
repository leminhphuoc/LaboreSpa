using FonSpa.Services.IClientServices;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FonSpa.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IServicesServices _servicesServices;
        public ServicesController(IServicesServices servicesServices)
        {
            _servicesServices = servicesServices;
        }
        // GET: Services
        public ActionResult Index(int? page, string searchString = null)
        {
            ViewBag.Tittle = "Services";
            var listProduct = _servicesServices.ListAll();
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            var listProductPaged = listProduct.ToPagedList(pageNumber, pageSize);
            return View(listProductPaged);
        }

        public ActionResult Detail(long id)
        {
            var services = _servicesServices.GetDetail(id);
            ViewBag.Tittle = "Services Detail";
            return View(services);
        }
    }
}