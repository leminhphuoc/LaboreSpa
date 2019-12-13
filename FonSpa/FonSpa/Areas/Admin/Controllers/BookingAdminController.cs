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
        public ActionResult Create(DateTime? date = null, int? time = null, int? idBed = null)
        {
            ViewBag.listServices = _bookingAdminServices.ListService();
            ViewBag.listCustomer = _bookingAdminServices.ListCustomer();
            ViewBag.listRoom = _bookingAdminServices.ListRoom();
            ViewBag.listBed = _bookingAdminServices.ListBed();
            ViewBag.bed = _bookingAdminServices.GetBed(idBed);
            
            if (date != null)
            {
                var bookingDate = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day, time.Value, 0, 0);
                var bedsList = _bookingAdminServices.GedBedsByTime(bookingDate);
                ViewBag.bookingDate = bookingDate;
                if (bedsList.Count == 0) return View("FullBed");
                return View(bedsList);
            }

            return View();
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Create(Booking booking, string customerName, string customerPhone)
        {

            if (ModelState.IsValid)
            {
                var idCustomer = _bookingAdminServices.AddCustomer(customerName, customerPhone);
                booking.IdCustomer = idCustomer;
                var addBookingSuccess = _bookingAdminServices.AddBooking(booking);
                if (addBookingSuccess == 0) ModelState.AddModelError("", "Add Booking Fail !");
                return RedirectToAction("Schedule");
            }
            ViewBag.CustomerName = customerName;
            ViewBag.CustomerPhone = customerPhone;
            return View(booking);
        }
        public ActionResult Edit(int id , DateTime? date = null, int? time = null)
        {
            var booking = _bookingAdminServices.GetDetail(id);
            ViewBag.listServices = _bookingAdminServices.ListService();
            ViewBag.listCustomer = _bookingAdminServices.ListCustomer();
            ViewBag.listRoom = _bookingAdminServices.ListRoom();
            ViewBag.listBed = _bookingAdminServices.ListBed();
            ViewBag.emptyBedsList = null;
            if (date != null && time > DateTime.Now.Hour && date >= DateTime.Now.Date)
            {
                var bookingDate = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day, time.Value, 0, 0);
                var emptyBedsList = _bookingAdminServices.GedBedsByTime(bookingDate);
                ViewBag.bookingDate = bookingDate;
                if (emptyBedsList.Count == 0) return View("FullBed");
                ViewBag.emptyBedsList = emptyBedsList;
            }
            if (booking == null) return RedirectToAction("Index");
            if(time < DateTime.Now.Hour || date < DateTime.Now.Date)
                ModelState.AddModelError("", "The Arrival Time you choose must be after the current time  !");
            return View(booking);
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(Booking booking, string customerName, string customerPhone)
        {
            if (ModelState.IsValid)
            {
                var editCustomerSuccess = _bookingAdminServices.EditCustomer(booking.IdCustomer, customerName, customerPhone);
                var editBookingSuccess = _bookingAdminServices.Edit(booking);
                if (!editBookingSuccess) ModelState.AddModelError("", "Edit Booking Fail !");
                return RedirectToAction("Schedule");
            }
            return View(booking);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var deleteSuccess = _bookingAdminServices.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteInSchedule(int id)
        {
            var deleteSuccess = _bookingAdminServices.Delete(id);
            return RedirectToAction("Schedule");
        }

    }
}