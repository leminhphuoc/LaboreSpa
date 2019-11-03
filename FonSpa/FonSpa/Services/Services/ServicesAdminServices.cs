using FonSpa.Services.IServices;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FonSpa.Services.Services
{
    public class ServicesAdminServices : IServicesAdminServices
    {
        private readonly IServiceAdminRepository _servicesAdminRepository;
        public ServicesAdminServices(IServiceAdminRepository servicesAdminRepository)
        {
            _servicesAdminRepository = servicesAdminRepository;
        }
    }
}