using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.IRepository
{
    public interface IBedRepository
    {
        Bed GetDetail(int id);
        List<Bed> GetList();
        int Add(Bed Bed);
        bool Edit(Bed Bed);
        bool Delete(int id);
        bool? ChangeStatus(int id);
        Room GetRoom(int id);
        List<Room> ListRoom();
    }
}
