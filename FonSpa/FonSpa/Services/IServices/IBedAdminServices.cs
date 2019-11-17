using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonSpa.Services.IServices
{
    public interface IBedAdminServices
    {
        List<Bed> ListAll();
        long AddBed(Bed Bed);
        Bed GetDetail(int id);
        bool Edit(Bed Bed);
        bool Delete(int id);
        bool? ChangeStatus(int id);
        Room GetRoom(int id);
        List<Room> ListRoom();
    }
}
