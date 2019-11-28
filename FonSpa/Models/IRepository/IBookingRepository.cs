using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.IRepository
{
    public interface IBookingRepository
    {
        Booking GetDetail(int id);
        List<Booking> GetList();
        List<Booking> ListBookingByDate(DateTime? date);
        long Add(Booking Booking);
        bool Edit(Booking Booking);
        bool Delete(int id);
        List<Customer> ListCustomer();
        List<Service> ListService();
        List<Room> ListRoom();
        List<Bed> ListBed();
        List<Bed> GetBedByTime(DateTime? date);
    }
}
