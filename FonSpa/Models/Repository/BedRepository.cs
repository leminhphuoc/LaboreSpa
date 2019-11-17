using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public class BedRepository : IBedRepository
    {
        private FonSpaDbContext _db = null;

        public FonSpaDbContext Db { get => _db; set => _db = value; }

        public BedRepository()
        {
            _db = new FonSpaDbContext();
        }

        public Bed GetDetail(int id)
        {
            var bed = _db.Beds.Find(id);
            return bed;
        }

        public List<Bed> GetList()
        {
            return _db.Beds.ToList();
        }

        public int Add(Bed bed)
        {
            var addBed = _db.Beds.Add(bed);
            _db.SaveChanges();
            return addBed.Id;
        }

        public bool Edit(Bed bed)
        {
            var editBed = _db.Beds.Where(x => x.Id == bed.Id).SingleOrDefault();
            editBed.Name = bed.Name;
            editBed.Status = bed.Status;
            _db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var Bed = _db.Beds.Find(id);
            if (Bed != null)
            {
                _db.Beds.Remove(Bed);
                _db.SaveChanges();
            }
            return true;
        }

        public bool? ChangeStatus(int id)
        {
            if (id == 0) return false;
            var Bed = _db.Beds.Find(id);
            Bed.Status = !Bed.Status;
            _db.SaveChanges();
            return Bed.Status;
        }

        public Room GetRoom(int id)
        {
            if (id == 0) return null;
            var bed = _db.Beds.Find(id);
            var room = _db.Rooms.Find(bed.IdRoom);
            return room;
        }

        public List<Room> ListRoom()
        {
            return _db.Rooms.ToList();
        }

    }
}
