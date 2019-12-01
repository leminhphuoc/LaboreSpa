using FonSpa.Services.IClientServices;
using FonSpa.Services.IServices;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FonSpa.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingServices _bookingServices;
        public BookingController(IBookingServices bookingServices)
        {
            _bookingServices = bookingServices;
        }
        // GET: Booking
        public ActionResult Index(long idServices = 0)
        {
            ViewBag.servicesList = _bookingServices.ServicesList();
            ViewBag.bedsList = _bookingServices.BedsList();
            ViewBag.roomsList = _bookingServices.RoomsList();

            if (idServices != 0)
            {
                var services = _bookingServices.GetServices(idServices);
                ViewBag.services = services;
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateBooking(Booking booking, string name, string phone , int time)
        {
            if(ModelState.IsValid)
            {
                var customer = new Customer() { Name = name, phone = phone };
                var idCustomer = _bookingServices.AddCustomer(customer);
                booking.IdCustomer = idCustomer;
                var bookingDate = new DateTime(booking.ArrivalTime.Year, booking.ArrivalTime.Month, booking.ArrivalTime.Day, time, 0, 0);
                booking.ArrivalTime = bookingDate;
                var idBooking = _bookingServices.AddBooking(booking);
                return RedirectToAction("Success",new {idBooking });
            }
            ViewBag.servicesList = _bookingServices.ServicesList();
            ViewBag.bedsList = _bookingServices.BedsList();
            ViewBag.roomsList = _bookingServices.RoomsList();
            if (booking.IdServices != 0)
            {
                var services = _bookingServices.GetServices(booking.IdServices);
                ViewBag.services = services;
            }
            return View(booking);
        }

        public ActionResult Success(long idBooking)
        {
            return View(idBooking);
        }

    }
}