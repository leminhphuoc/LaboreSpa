using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonSpa.Services.IServices
{
    public interface IBookingAdminServices
    {
        List<Booking> ListAll();
        List<Booking> ListBookingByDate(DateTime? date);
        long AddBooking(Booking booking);
        Booking GetDetail(int id);
        bool Edit(Booking booking);
        bool Delete(int id);
        List<Customer> ListCustomer();
        List<Service> ListService();
        List<Room> ListRoom();
        List<Bed> ListBed();
        List<Bed> GedBedsByTime(DateTime? date);
        Bed GetBed(int? id);
    }
}
