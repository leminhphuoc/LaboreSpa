using FonSpa.Services.IClientServices;
using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FonSpa.Services.ClientServices
{
    public class AboutServices: IAboutServices
    {
        private readonly IAboutAdminRepository _aboutAdminRepository;
        public AboutServices(IAboutAdminRepository aboutAdminRepository )
        {
            _aboutAdminRepository = aboutAdminRepository;
        }

        public About GetAbout(int id)
        {
            if (id == 0) return null;
            return _aboutAdminRepository.GetDetail(id);
        }

        public List<About> GetAbouts()
        {
            return _aboutAdminRepository.GetListAbout().Where(x=>x.status == true).OrderBy(x=>x.id).ToList();
        }

    }
}