using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonSpa.Services.IClientServices
{
    public interface IBookingServices
    {
        Service GetServices(long id);
        List<Service> ServicesList();
        List<Bed> BedsList();
        List<Room> RoomsList();
        long AddCustomer(Customer customer);
        long AddBooking(Booking booking);
    }
}
