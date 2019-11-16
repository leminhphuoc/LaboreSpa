using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.IRepository
{
    public interface IRoomRepository
    {
        Room GetDetail(int id);
        List<Room> GetList();
        int Add(Room room);
        bool Edit(Room room);
        bool Delete(int id);
    }
}
