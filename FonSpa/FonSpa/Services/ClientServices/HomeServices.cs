using FonSpa.Services.IClientServices;
using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FonSpa.Services.ClientServices
{
    public class HomeServices : IHomeServices
    {
        private readonly IMenuAdminRepository _menuAdminRepositor;
        public HomeServices(IMenuAdminRepository menuAdminRepositor)
        {
            _menuAdminRepositor = menuAdminRepositor;
        }

        public List<Menu> ListMenu()
        {
            return _menuAdminRepositor.GetListMenu();
        }

    }
}