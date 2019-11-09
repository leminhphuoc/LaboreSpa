using FonSpa.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FonSpa.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactClientServices _contactClientServices;
        public ContactController(IContactClientServices contactClientServices)
        {
            _contactClientServices = contactClientServices;
        }
        // GET: Contact
        public ActionResult Index()
        {
            var listContact = _contactClientServices.GetContacts();
            return View(listContact);
        }
    }
}