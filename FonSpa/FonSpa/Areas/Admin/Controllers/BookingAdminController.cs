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
    public class BookingAdminController : Controller
    {
        // GET: Admin/BookingAdmin
        // GET: Admin/BookingAdmin
        private readonly IBookingAdminServices _bookingAdminServices;
        public BookingAdminController(IBookingAdminServices bookingAdminServices)
        {
            _bookingAdminServices = bookingAdminServices;
        }
        // GET: Admin/BookingAdmin
        public ActionResult Index(int? page)
        {
            var listBooking = _bookingAdminServices.ListAll();
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var listBookingPaged = listBooking.ToPagedList(pageNumber, pageSize);
            ViewBag.listServices = _bookingAdminServices.ListService();
            ViewBag.listCustomer = _bookingAdminServices.ListCustomer();
            ViewBag.listRoom = _bookingAdminServices.ListRoom();
            ViewBag.listBed = _bookingAdminServices.ListBed();
           


            return View(listBookingPaged);
        }

        public ActionResult Schedule(DateTime? date = null)
         {
            var listBookingbyday = _bookingAdminServices.ListBookingByDate(date);
            ViewBag.listServices = _bookingAdminServices.ListService();
            ViewBag.listCustomer = _bookingAdminServices.ListCustomer();
            ViewBag.listRoom = _bookingAdminServices.ListRoom();
            ViewBag.listBed = _bookingAdminServices.ListBed();
            if (date != null) ViewBag.date = date;
            else ViewBag.date = DateTime.Now;
            return View(listBookingbyday);
        }
        public ActionResult Create(DateTime? date = null, int? time = null)
        {
            ViewBag.listServices = _bookingAdminServices.ListService();
            ViewBag.listCustomer = _bookingAdminServices.ListCustomer();
            ViewBag.listRoom = _bookingAdminServices.ListRoom();
            ViewBag.listBed = _bookingAdminServices.ListBed(); 
            if(date != null)
            {
                var bookingDate = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day, time.Value, 0, 0);
                var bedsList = _bookingAdminServices.GedBedsByTime(bookingDate);
                ViewBag.bookingDate = bookingDate;
                return View(bedsList);
            }

            return View();
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(Booking booking)
        {

            if (ModelState.IsValid)
            {
                var addBookingSuccess = _bookingAdminServices.AddBooking(booking);
                if (addBookingSuccess == 0) ModelState.AddModelError("", "Thêm sản phẩm không thành công !");
                return RedirectToAction("Index");
            }
            return View(booking);
        }
        public ActionResult Edit(int id)
        {
            var booking = _bookingAdminServices.GetDetail(id);
            ViewBag.listServices = _bookingAdminServices.ListService();
            ViewBag.listCustomer = _bookingAdminServices.ListCustomer();
            ViewBag.listRoom = _bookingAdminServices.ListRoom();
            ViewBag.listBed = _bookingAdminServices.ListBed();
            if (booking == null) return RedirectToAction("Index");
            return View(booking);
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(Booking booking)
        {
            if (ModelState.IsValid)
            {
                var editBookingSuccess = _bookingAdminServices.Edit(booking);
                if (!editBookingSuccess) ModelState.AddModelError("", "Sửa sản phẩm không thành công !");
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var deleteSuccess = _bookingAdminServices.Delete(id);
            return RedirectToAction("Index");
        }

    }
}