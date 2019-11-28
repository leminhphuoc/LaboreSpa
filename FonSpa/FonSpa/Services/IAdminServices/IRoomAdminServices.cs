using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonSpa.Services.IServices
{
    public interface IRoomAdminServices
    {
        List<Room> ListAll();
        long AddRoom(Room room);
        Room GetDetail(int id);
        bool Edit(Room room);
        bool Delete(int id);
        bool? ChangeStatus(int id);
    }
}
