using FonSpa.Filter;
using FonSpa.Services.IServices;
using Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FonSpa.Areas.Admin.Controllers
{
    [AuthData]
    public class HomeAdminController : Controller
    {
       
        //GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            ViewBag.Visitor = new IPAddressRepository().CountVisitor();
            var services = new ServiceAdminRepository().Count();
            var product = new ProductAdminRepository().Count();
            ViewBag.Services = services;
            ViewBag.Customer = new CustomerAdminRepository().Count();
            ViewBag.Booking = new BookingRepository().Count();

            ViewBag.CountBooking = new BookingRepository().CountByMonth(DateTime.Now.Month);
            ViewBag.CountBooking1 = new BookingRepository().CountByMonth(DateTime.Now.AddMonths(-1).Month);
            ViewBag.CountBooking2 = new BookingRepository().CountByMonth(DateTime.Now.AddMonths(-2).Month);
            ViewBag.CountBooking3 = new BookingRepository().CountByMonth(DateTime.Now.AddMonths(-3).Month);
            ViewBag.CountBooking4 = new BookingRepository().CountByMonth(DateTime.Now.AddMonths(-4).Month);
            ViewBag.CountBooking5 = new BookingRepository().CountByMonth(DateTime.Now.AddMonths(-5).Month);
            ViewBag.CountBooking6 = new BookingRepository().CountByMonth(DateTime.Now.AddMonths(-6).Month);
            ViewBag.CountBooking7 = new BookingRepository().CountByMonth(DateTime.Now.AddMonths(-7).Month);
            ViewBag.CountBooking8 = new BookingRepository().CountByMonth(DateTime.Now.AddMonths(-8).Month);



            ViewBag.CountCustomer = new CustomerAdminRepository().CountByMonth(DateTime.Now.Month);
            ViewBag.CountCustomer1 = new CustomerAdminRepository().CountByMonth(DateTime.Now.AddMonths(-1).Month);
            ViewBag.CountCustomer2 = new CustomerAdminRepository().CountByMonth(DateTime.Now.AddMonths(-2).Month);
            ViewBag.CountCustomer3 = new CustomerAdminRepository().CountByMonth(DateTime.Now.AddMonths(-3).Month);
            ViewBag.CountCustomer4 = new CustomerAdminRepository().CountByMonth(DateTime.Now.AddMonths(-4).Month);
            ViewBag.CountCustomer5 = new CustomerAdminRepository().CountByMonth(DateTime.Now.AddMonths(-5).Month);
            ViewBag.CountCustomer6 = new CustomerAdminRepository().CountByMonth(DateTime.Now.AddMonths(-6).Month);
            ViewBag.CountCustomer7 = new CustomerAdminRepository().CountByMonth(DateTime.Now.AddMonths(-7).Month);
            ViewBag.CountCustomer8 = new CustomerAdminRepository().CountByMonth(DateTime.Now.AddMonths(-8).Month);



            ViewBag.CountVisitor = new IPAddressRepository().CountByMonth(DateTime.Now.Month);
            ViewBag.CountVisitor1 = new IPAddressRepository().CountByMonth(DateTime.Now.AddMonths(-1).Month);
            ViewBag.CountVisitor2 = new IPAddressRepository().CountByMonth(DateTime.Now.AddMonths(-2).Month);
            ViewBag.CountVisitor3 = new IPAddressRepository().CountByMonth(DateTime.Now.AddMonths(-3).Month);
            ViewBag.CountVisitor4 = new IPAddressRepository().CountByMonth(DateTime.Now.AddMonths(-4).Month);
            ViewBag.CountVisitor5 = new IPAddressRepository().CountByMonth(DateTime.Now.AddMonths(-5).Month);
            ViewBag.CountVisitor6 = new IPAddressRepository().CountByMonth(DateTime.Now.AddMonths(-6).Month);
            ViewBag.CountVisitor7 = new IPAddressRepository().CountByMonth(DateTime.Now.AddMonths(-7).Month);
            ViewBag.CountVisitor8 = new IPAddressRepository().CountByMonth(DateTime.Now.AddMonths(-8).Month);
            return View();
        }
    }
}