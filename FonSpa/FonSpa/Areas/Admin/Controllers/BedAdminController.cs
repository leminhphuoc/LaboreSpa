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
    public class BedAdminController : Controller
    {
        // GET: Admin/BedAdmin
        private readonly IBedAdminServices _bedAdminServices;
        public BedAdminController(IBedAdminServices bedAdminServices)
        {
            _bedAdminServices = bedAdminServices;
        }
        // GET: Admin/BedAdmin
        public ActionResult Index(int? page)
        {
            var listBed = _bedAdminServices.ListAll();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var listBedPaged = listBed.ToPagedList(pageNumber, pageSize);
            ViewBag.listRoom = _bedAdminServices.ListRoom();
            return View(listBedPaged);
        }
        public ActionResult Create()
        {
            ViewBag.listRoom = _bedAdminServices.ListRoom();
            return View();
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(Bed bed)
        {

            if (ModelState.IsValid)
            {
                var addBedSuccess = _bedAdminServices.AddBed(bed);
                if (addBedSuccess == 0) ModelState.AddModelError("", "Thêm sản phẩm không thành công !");
                return RedirectToAction("Index");
            }
            return View(bed);
        }
        public ActionResult Edit(int id)
        {
            var bed = _bedAdminServices.GetDetail(id);
            ViewBag.listRoom = _bedAdminServices.ListRoom();
            if (bed == null) return RedirectToAction("Index");
            return View(bed);
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(Bed bed)
        {
            if (ModelState.IsValid)
            {
                var editBedSuccess = _bedAdminServices.Edit(bed);
                if (!editBedSuccess) ModelState.AddModelError("", "Sửa sản phẩm không thành công !");
                return RedirectToAction("Index");
            }
            return View(bed);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var deleteSuccess = _bedAdminServices.Delete(id);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var res = _bedAdminServices.ChangeStatus(id);
            return Json(new
            {
                Status = res
            });
        }
    }
}