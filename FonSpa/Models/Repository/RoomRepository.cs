using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public class RoomRepository
    {
        private FonSpaDbContext _db = null;

        public FonSpaDbContext Db { get => _db; set => _db = value; }

        public RoomRepository()
        {
            _db = new FonSpaDbContext();
        }

        public Room GetDetail(int id)
        {
            var room = _db.Rooms.Find(id);
            return room;
        }

        public List<Room> GetList()
        {
            return _db.Rooms.ToList();
        }

        public int Add(Room room)
        {
            var addRoom = _db.Rooms.Add(room);
            _db.SaveChanges();
            return addRoom.Id;
        }

        public bool Edit(Room room)
        {
            var editRoom = _db.Rooms.Where(x => x.Id == room.Id).SingleOrDefault();
            editRoom.Name = room.Name;
            _db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var room = _db.Rooms.Find(id);
            if (room != null)
            {
                _db.Rooms.Remove(room);
                _db.SaveChanges();
            }
            return true;
        }
    }
}
