using FonSpa.Services.IServices;
using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FonSpa.Services.Services
{
    public class BedAdminServices : IBedAdminServices
    {
        private readonly IBedRepository _bedRepository;
        public BedAdminServices(IBedRepository bedRepository)
        {
            _bedRepository = bedRepository;
        }

        public List<Bed> ListAll()
        {
            return _bedRepository.GetList();
        }

        public long AddBed(Bed Bed)
        {
            if (Bed == null) return 0;
            var addBed = _bedRepository.Add(Bed);
            var idBed = addBed;
            return idBed;
        }

        public Bed GetDetail(int id)
        {
            if (id == 0) return null;
            var Bed = _bedRepository.GetDetail(id);
            return Bed;
        }

        public bool Edit(Bed Bed)
        {
            if (Bed == null) return false;
            var editBed = _bedRepository.Edit(Bed);
            return true;
        }

        public bool Delete(int id)
        {
            if (id == 0) return false;
            var deleteSuccess = _bedRepository.Delete(id);
            return true;
        }

        public bool? ChangeStatus(int id)
        {
            var status = _bedRepository.ChangeStatus(id);
            return status;
        }

        public Room GetRoom(int id)
        {
            if (id == 0) return null;
            return _bedRepository.GetRoom(id);
        }

        public List<Room> ListRoom()
        {
            return _bedRepository.ListRoom();
        }
            
    }
}