using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonSpa.Services.IServices
{
    public interface IMenuAdminServices
    {
        List<MenuType> GetMenuTypes();
        long AddMenu(Menu menu);
        bool Delete(int id);
        Menu GetDetail(int id);
        bool Edit(Menu menu);
        bool? ChangeStatus(int id);
    }
}