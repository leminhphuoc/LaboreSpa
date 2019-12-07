using FonSpa.Services.IClientServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FonSpa.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutServices _aboutServices;
        public AboutController(IAboutServices aboutServices)
        {
            _aboutServices = aboutServices;
        }
        // GET: About
        public ActionResult Index()
        {
            ViewBag.Tittle = "About";
            var model = _aboutServices.GetAbouts();
            return View(model);
        }
    }
}