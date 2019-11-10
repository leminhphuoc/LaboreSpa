using FonSpa.Filter;
using FonSpa.Services.IServices;
using Models.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FonSpa.Areas.Admin.Controllers
{
    [AuthData]
    public class ServicesCategoryAdminController : Controller
    {
        // GET: Admin/ServicesCategory
        private readonly IServiceCategoryAdminServices _serviceCategoryAdminServices;
        public ServicesCategoryAdminController(IServiceCategoryAdminServices serviceCategoryAdminServices)
        {
            _serviceCategoryAdminServices = serviceCategoryAdminServices;
        }
        // GET: Admin/ServicesAdmin
        public ActionResult Index(int? page, string searchString = null)
        {
            var listServices = _serviceCategoryAdminServices.ListAllByName(searchString);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var listServicesPaged = listServices.ToPagedList(pageNumber, pageSize);
            return View(listServicesPaged);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(ServiceCategory serviceCategory)
        {

            if (ModelState.IsValid)
            {
                var addServices = _serviceCategoryAdminServices.AddServiceCategory(serviceCategory);
                var idServices = addServices;
                if (idServices == 0) ModelState.AddModelError("", "Thêm sản phẩm không thành công !");
                return RedirectToAction("Index");
            }
            return View(serviceCategory);
        }

        public ActionResult Edit(int id)
        {
            var Services = _serviceCategoryAdminServices.GetDetail(id);
            if (Services == null) return RedirectToAction("Index");
            return View(Services);
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(ServiceCategory ServicesCategory)
        {
            if (ModelState.IsValid)
            {
                var editServices = _serviceCategoryAdminServices.Edit(ServicesCategory);
                var editServicesSuccess = editServices;
                if (!editServicesSuccess) ModelState.AddModelError("", "Sửa sản phẩm không thành công !");
                return RedirectToAction("Index");
            }
            return View(ServicesCategory);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var deleteAccountSuccess = _serviceCategoryAdminServices.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var res = _serviceCategoryAdminServices.ChangeStatus(id);
            return Json(new
            {
                Status = res
            });
        }
    }
}