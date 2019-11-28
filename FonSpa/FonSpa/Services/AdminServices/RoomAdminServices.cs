using FonSpa.Services.IServices;
using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FonSpa.Services.Services
{
    public class RoomAdminServices : IRoomAdminServices
    {
        private readonly IRoomRepository _roomRepository;
        public RoomAdminServices(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public List<Room> ListAll()
        {
            return _roomRepository.GetList();
        }

        public long AddRoom(Room room)
        {
            if (room == null) return 0;
            var addRoom = _roomRepository.Add(room);
            var idRoom = addRoom;
            return idRoom;
        }

        public Room GetDetail(int id)
        {
            if (id == 0) return null;
            var room = _roomRepository.GetDetail(id);
            return room;
        }

        public bool Edit(Room room)
        {
            if (room == null) return false;
            var editRoom = _roomRepository.Edit(room);
            return true;
        }

        public bool Delete(int id)
        {
            if (id == 0) return false;
            var deleteSuccess = _roomRepository.Delete(id);
            return true;
        }

        public bool? ChangeStatus(int id)
        {
            var status = _roomRepository.ChangeStatus(id);
            return status;
        }
    }
}