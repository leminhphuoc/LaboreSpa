using FonSpa.Services.IServices;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FonSpa.Areas.Admin.Controllers
{
    public class MenuAdminController : Controller
    {
        // GET: Admin/MenuAdmin
        private readonly IMenuAdminServices _menuAdminServices;
        public MenuAdminController(IMenuAdminServices menuAdminServices)
        {
            _menuAdminServices = menuAdminServices;
        }
        // GET: Admin/ProductAdmin
        public ActionResult Index(int? page, string searchString = null)
        {
            var listMenu = _menuAdminServices.ListMenuByText(searchString);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var listMenuPaged = listMenu.ToPagedList(pageNumber, pageSize);
            ViewBag.MenuType = _menuAdminServices.GetMenuTypes();
            return View(listMenuPaged);
        }
    }
}