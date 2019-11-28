using FonSpa.Services.IServices;
using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FonSpa.Services.Services
{
    public class BookingAdminServices : IBookingAdminServices
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingAdminServices(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public List<Booking> ListAll()
        {
            return _bookingRepository.GetList();
        }

        public List<Booking> ListBookingByDate(DateTime? date)
        {
            return _bookingRepository.ListBookingByDate(date);
        }

        public long AddBooking(Booking booking)
        {
            if (booking == null) return 0;
            var addBooking = _bookingRepository.Add(booking);
            var idBooking = addBooking;
            return idBooking;
        }

        public Booking GetDetail(int id)
        {
            if (id == 0) return null;
            var booking = _bookingRepository.GetDetail(id);
            return booking;
        }

        public bool Edit(Booking booking)
        {
            if (booking == null) return false;
            var editBooking = _bookingRepository.Edit(booking);
            return true;
        }

        public bool Delete(int id)
        {
            if (id == 0) return false;
            var deleteSuccess = _bookingRepository.Delete(id);
            return true;
        }


        public List<Customer> ListCustomer()
        {
            return _bookingRepository.ListCustomer();
        }

        public List<Service> ListService()
        {
            return _bookingRepository.ListService();
        }
        public List<Room> ListRoom()
        {
            return _bookingRepository.ListRoom();
        }
        public List<Bed> ListBed()
        {
            return _bookingRepository.ListBed();
        }
        public List<Bed> GedBedsByTime(DateTime? date)
        {
            return _bookingRepository.GetBedByTime(date);
        }

    }
}