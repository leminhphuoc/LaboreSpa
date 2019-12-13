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
        private readonly IBedRepository _bedRepository;
        private readonly ICustomerAdminRepository _customerAdminRepository;
        public BookingAdminServices(IBookingRepository bookingRepository, IBedRepository bedRepository, ICustomerAdminRepository customerAdminRepository)
        {
            _bookingRepository = bookingRepository;
            _bedRepository = bedRepository;
            _customerAdminRepository = customerAdminRepository;
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
            var idBooking = _bookingRepository.Add(booking);
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

        public Bed GetBed(int? id)
        {
            if (id == null) return null;
            int idNotNull = id ?? default(int);
            return _bedRepository.GetDetail(idNotNull) ;   
        }
        
        public long AddCustomer(string name, string phone)
        {
            var customersList = _customerAdminRepository.GetListCustomer();
            if (customersList.Where(x => x.phone == phone).Count() > 0)
            {
                var customerExits = customersList.Where(x => x.phone == phone).FirstOrDefault();
                return customerExits.id;
            }
            var customer = new Customer() { Name = name, phone = phone };
            var idCustomer = _customerAdminRepository.AddCustomer(customer);
            return idCustomer;
        }
        public bool EditCustomer(long id, string name, string phone)
        {
            var customer = new Customer() { id = id ,Name = name, phone = phone };
            var ediCustomerSuccess = _customerAdminRepository.EditCustomer(customer);
            return ediCustomerSuccess;
        }


    }
}