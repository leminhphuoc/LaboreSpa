using FonSpa.Filter;
using FonSpa.Services.IServices;
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
        //private readonly ICustomerAdminServices _customerAdminServices;
        //public CustomerAdminController(ICustomerAdminServices customerAdminServices)
        //{
        //    _customerAdminServices = customerAdminServices;
        //}
        //GET: Admin/HomeAdmin
        public ActionResult Index()
        {

            return View();
        }
    }
}