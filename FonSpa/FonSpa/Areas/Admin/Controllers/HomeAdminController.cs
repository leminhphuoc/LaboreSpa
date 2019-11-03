using FonSpa.Filter;
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

        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            return View();
        }
    }
}