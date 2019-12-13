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
        public ActionResult Index(Booking booking, string name, string phone , int time)
        {
            long idBooking = 0;
            if(ModelState.IsValid && booking.IdBed != 0 && booking.IdServices != 0 && time > DateTime.Now.Hour && booking.ArrivalTime.Date >= DateTime.Now.Date)
            {

                var customer = new Customer() { Name = name, phone = phone };
                var idCustomer = _bookingServices.AddCustomer(customer);
                booking.IdCustomer = idCustomer;
                var bookingDate = new DateTime(booking.ArrivalTime.Year, booking.ArrivalTime.Month, booking.ArrivalTime.Day, time, 0, 0);
                booking.ArrivalTime = bookingDate;
                idBooking = _bookingServices.AddBooking(booking);
                if(idBooking > 0)
                {
                    return RedirectToAction("Success", new { idBooking });
                }
               
            }
            if (booking.ArrivalTime < DateTime.Now || time < DateTime.Now.Hour)
            {
                ModelState.AddModelError("", "The Arrival Time you choose must be after the current time  !");
            }
            else if (idBooking == 0)
            {
                ModelState.AddModelError("", "The bed in arrival Time you choose isn't empty ! Please select other bed or time. ");
            }
            else
            {
                ModelState.AddModelError("", "Please fill full information for booking !");
            }
            ViewBag.servicesList = _bookingServices.ServicesList();
            ViewBag.bedsList = _bookingServices.BedsList();
            ViewBag.roomsList = _bookingServices.RoomsList();
            ViewBag.name = name;
            ViewBag.phone = phone;
            
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