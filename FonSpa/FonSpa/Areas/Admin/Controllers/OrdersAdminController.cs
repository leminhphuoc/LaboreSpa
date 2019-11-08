using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FonSpa.Areas.Admin.Controllers
{
    public class OrdersAdminController : Controller
    {
        // GET: Admin/OrdersAdmin
        public ActionResult Index()
        {
            return View();
        }
    }
}