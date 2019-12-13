using FonSpa.Services.IClientServices;
using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FonSpa.Services.ClientServices
{
    public class BookingServices : IBookingServices
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IServiceAdminRepository _serviceAdminRepository;
        private readonly IBedRepository _bedRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly ICustomerAdminRepository _customerAdminRepository;
        public BookingServices(IBookingRepository bookingRepository, IServiceAdminRepository serviceAdminRepository, IBedRepository bedRepository, IRoomRepository roomRepository,
            ICustomerAdminRepository customerAdminRepository)
        {
            _bookingRepository = bookingRepository;
            _serviceAdminRepository = serviceAdminRepository;
            _bedRepository = bedRepository;
            _roomRepository = roomRepository;
            _customerAdminRepository = customerAdminRepository;
        }

        public Service GetServices(long id)
        {
            if (id == 0) return null;
            var result = _serviceAdminRepository.GetDetail(id);
            return result;
        }

        public List<Service> ServicesList()
        {
            return _serviceAdminRepository.GetListService();
        }

        public List<Bed> BedsList()
        {
            return _bedRepository.GetList();
        }

        public List<Room> RoomsList()
        {
            return _roomRepository.GetList();
        }

        public long AddCustomer(Customer customer)
        {
            var customersList = _customerAdminRepository.GetListCustomer();
            if(customersList.Where(x=>x.phone == customer.phone).Count() > 0)
            {
                var customerExits = customersList.Where(x => x.phone == customer.phone).FirstOrDefault();
                return customerExits.id;
            }
            return _customerAdminRepository.AddCustomer(customer);
        }

        public long AddBooking(Booking booking)
        {
            return _bookingRepository.Add(booking);
        }
    }
}