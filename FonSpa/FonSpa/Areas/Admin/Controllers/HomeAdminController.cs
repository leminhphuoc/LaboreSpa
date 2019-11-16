using FonSpa.Filter;
using FonSpa.Services.IServices;
using Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FonSpa.Areas.Admin.Controllers
{
    [AuthData]
    public class HomeAdminController : Controller
    {
       
        //GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            ViewBag.Visitor = new IPAddressRepository().CountVisitor();
            var services = new ServiceAdminRepository().Count();
            var product = new ProductAdminRepository().Count();
            ViewBag.Services = services + product;
            ViewBag.Customer = new CustomerAdminRepository().Count();
            return View();
        }
    }
}