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
    public class ServicesAdminController : Controller
    {
        // GET: Admin/ServicesAdmin
        private readonly IServicesAdminServices _serivcesAdminServices;
        public ServicesAdminController(IServicesAdminServices serivcesAdminServices)
        {
            _serivcesAdminServices = serivcesAdminServices;
        }
        // GET: Admin/SerivcesAdmin
        public ActionResult Index(int? page, string searchString = null)
        {
            var listSerivces = _serivcesAdminServices.ListAllByName(searchString);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var listSerivcesPaged = listSerivces.ToPagedList(pageNumber, pageSize);
            ViewBag.SerivcesCategory = _serivcesAdminServices.GetServiceCategory();
            return View(listSerivcesPaged);
        }

        public ActionResult Create()
        {
            ViewBag.SerivcesCategory = _serivcesAdminServices.GetServiceCategory();
            return View();
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(Service serivces)
        {

            if (ModelState.IsValid)
            {
                var addSerivces = _serivcesAdminServices.AddService(serivces);
                var idSerivces = addSerivces;
                if (idSerivces == 0) ModelState.AddModelError("", "Add About Fail !");
                return RedirectToAction("Index");
            }
            return View(serivces);
        }

        public ActionResult Edit(int id)
        {
            var Serivces = _serivcesAdminServices.GetDetail(id);
            if (Serivces == null) return RedirectToAction("Index");
            ViewBag.SerivcesCategory = _serivcesAdminServices.GetServiceCategory();
            return View(Serivces);
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(Service Serivce)
        {
            if (ModelState.IsValid)
            {
                var editSerivces = _serivcesAdminServices.Edit(Serivce);
                var editSerivcesSuccess = editSerivces;
                if (!editSerivcesSuccess) ModelState.AddModelError("", "Sửa sản phẩm không thành công !");
                return RedirectToAction("Index");
            }
            return View(Serivce);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var deleteAccountSuccess = _serivcesAdminServices.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var res = _serivcesAdminServices.ChangeStatus(id);
            return Json(new
            {
                Status = res
            });
        }
    }
}