using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonSpa.Services.IServices
{
    public interface IMenuTypeSerivces
    {
        List<MenuType> ListAllByName(string searchString);
        List<MenuType> GetMenuType();
        long AddMenuType(MenuType menutype);
        MenuType GetDetail(int id);
        bool Edit(MenuType menutype);
        bool Delete(int id);
    }
}
