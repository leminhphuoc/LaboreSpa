using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private FonSpaDbContext _db = null;

        public FonSpaDbContext Db { get => _db; set => _db = value; }

        public BookingRepository()
        {
            _db = new FonSpaDbContext();
        }

        public Booking GetDetail(long id)
        {
            var Booking = _db.Bookings.Find(id);
            return Booking;
        }

        public List<Booking> GetList()
        {
            UpdateStatusBed();
            return _db.Bookings.ToList();
        }

        public List<Bed> GetBedByTime(DateTime? date)
        {
            var bookingList = _db.Bookings.ToList();
            var bedExcept = new List<Bed>();
            foreach(var booking in bookingList)
            {
                if(booking.ArrivalTime == date)
                {
                    if(booking.ArrivalTime.Hour == date.Value.Hour)
                    {
                        var bed = _db.Beds.Find(booking.IdBed);
                        if(!bedExcept.Contains(bed))
                        {
                            bedExcept.Add(bed);
                        }                
                    }
                }
            }
            var bedsList = _db.Beds.ToList();
            var result = new List<Bed>();
            foreach(var bed in bedsList)
            {
                if(!bedExcept.Contains(bed))
                {
                    result.Add(bed);
                }
            }
            return result;
        }

        public void UpdateStatusBed()
        {
            var bookingList = _db.Bookings.ToList();
            foreach(var booking in bookingList)
            {
                var services = _db.Services.Find(booking.IdServices);
                if(services.ServingTime == 45)
                {
                    if(DateTime.Now == booking.ArrivalTime)
                    {
                        if(DateTime.Now.Hour - booking.ArrivalTime.Hour >= 1)
                        {
                            var bed = _db.Beds.Find(booking.IdBed);
                            bed.Status = true;
                            _db.SaveChanges();
                        }

                    }
                }
                else
                {
                    if (DateTime.Now == booking.ArrivalTime)
                    {
                        if (DateTime.Now.Hour - booking.ArrivalTime.Hour >= 2)
                        {
                            var bed = _db.Beds.Find(booking.IdBed);
                            bed.Status = true;
                            _db.SaveChanges();
                        }

                    }
                }
            }
        }

        public List<Booking> ListBookingByDate(DateTime? date)
        {
            if (date == null) return _db.Bookings.Where(x => x.ArrivalTime.Day == DateTime.Now.Day).ToList();
            return _db.Bookings.Where(x=>x.ArrivalTime.Day == date.Value.Day).ToList();
        }

        public long Add(Booking booking)
        {
            var addBooking = _db.Bookings.Add(booking);
            var bed = _db.Beds.Find(booking.IdBed);
            bed.Status = false;
            _db.SaveChanges();
            return addBooking.Id;
        }

        public bool Edit(Booking Booking)
        {
            var editBooking = _db.Bookings.Where(x => x.Id == Booking.Id).SingleOrDefault();
            editBooking.ArrivalTime = Booking.ArrivalTime;
            editBooking.IdCustomer = Booking.IdCustomer;
            editBooking.IdServices = Booking.IdServices;
            editBooking.IdBed = Booking.IdBed;
            editBooking.Message = Booking.Message;

            _db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var Booking = _db.Bookings.Find(id);
            if (Booking != null)
            {
                _db.Bookings.Remove(Booking);
                _db.SaveChanges();
            }
            return true;
        }


        public List<Customer> ListCustomer()
        {
            return _db.Customers.ToList();
        }

        public List<Service> ListService()
        {
            return _db.Services.ToList();
        }

        public List<Room> ListRoom()
        {
            return _db.Rooms.OrderBy(x=>x.Name).ToList();
        }

        public List<Bed> ListBed()
        {
            return _db.Beds.OrderBy(x => x.Name).OrderBy(x=>x.IdRoom).ToList();
        }

        public int Count()
        {
            return _db.Bookings.Count();
        }

        public int CountByMonth(int month)
        {
            return _db.Bookings.Where(x => x.ArrivalTime.Month == month).Count();
        }
    }
}
