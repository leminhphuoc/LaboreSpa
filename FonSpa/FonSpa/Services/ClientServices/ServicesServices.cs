using FonSpa.Services.IClientServices;
using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FonSpa.Services.ClientServices
{
    public class ServicesServices : IServicesServices
    {
        private readonly IServiceAdminRepository _serviceAdminRepository;
        public ServicesServices(IServiceAdminRepository serviceAdminRepository)
        {
            _serviceAdminRepository = serviceAdminRepository;
        }

        public List<Service> ListAll()
        {
            return _serviceAdminRepository.GetListService().Where(x=>x.status == true).OrderBy(x=>x.createdDate).ToList();
        }


        public List<Service> ListByCategory(int idCategory)
        {
            return _serviceAdminRepository.GetListService().Where(x => x.status == true && x.idCategory == idCategory).OrderBy(x => x.createdDate).ToList();
        }


        public Service GetDetail(long id)
        {
            return _serviceAdminRepository.GetDetail(id);
        }

    }
}