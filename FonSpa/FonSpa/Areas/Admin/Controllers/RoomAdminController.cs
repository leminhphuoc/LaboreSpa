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
    public class RoomAdminController : Controller
    {
        private readonly IRoomAdminServices _roomAdminServices;
        public RoomAdminController(IRoomAdminServices roomAdminServices)
        {
            _roomAdminServices = roomAdminServices;
        }
        // GET: Admin/RoomAdmin
        public ActionResult Index(int? page)
        {
            var listRoom = _roomAdminServices.ListAll();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var listRoomPaged = listRoom.ToPagedList(pageNumber, pageSize);
            return View(listRoomPaged);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(Room room)
        {

            if (ModelState.IsValid)
            {
                var addRoomSuccess = _roomAdminServices.AddRoom(room);
                if (addRoomSuccess == 0) ModelState.AddModelError("", "Thêm sản phẩm không thành công !");
                return RedirectToAction("Index");
            }
            return View(room);
        }
        public ActionResult Edit(int id)
        {
            var room = _roomAdminServices.GetDetail(id);
            if (room == null) return RedirectToAction("Index");
            return View(room);
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(Room room)
        {
            if (ModelState.IsValid)
            {
                var editRoomSuccess = _roomAdminServices.Edit(room);
                if (!editRoomSuccess) ModelState.AddModelError("", "Sửa sản phẩm không thành công !");
                return RedirectToAction("Index");
            }
            return View(room);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var deleteSuccess = _roomAdminServices.Delete(id);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var res = _roomAdminServices.ChangeStatus(id);
            return Json(new
            {
                Status = res
            });
        }
    }
}