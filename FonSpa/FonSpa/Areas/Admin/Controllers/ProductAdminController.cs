using FonSpa.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace FonSpa.Areas.Admin.Controllers
{
    public class ProductAdminController : Controller
    {
        private readonly IProductAdminSerivces _productAdminServices;
        public ProductAdminController(IProductAdminSerivces productAdminServices)
        {
            _productAdminServices = productAdminServices;
        }
        // GET: Admin/ProductAdmin
        public ActionResult Index(int? page,string searchString = null)
        {
            var listProduct = _productAdminServices.ListAllByName(searchString);
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            var listProductPaged = listProduct.ToPagedList(pageNumber, pageSize);
            ViewBag.ProductCategory = _productAdminServices.GetProductCategory();
            return View(listProductPaged);
        }

        public ActionResult Create()
        {
            ViewBag.ProductCategory = _productAdminServices.GetProductCategory();
            return View();
        }
    }
}