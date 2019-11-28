using FonSpa.Services.IServices;
using HelperLibrary;
using Models.Entity;
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

        public List<Service> ListAllByName(string searchString)
        {
            if (searchString == null || searchString == "")
            {
                return _servicesAdminRepository.GetListService();
            }
            else
            {
                searchString = Helper.RemoveSign4VietnameseString(searchString);
                var ListService = _servicesAdminRepository.ListSearchService(searchString);
                return ListService;
            }
        }

        public List<ServiceCategory> GetServiceCategory()
        {
            return _servicesAdminRepository.GetServiceCategories();
        }

        public long AddService(Service service)
        {
            if (service == null) return 0;
            var addService = _servicesAdminRepository.AddService(service);
            var idService = addService;
            return idService;
        }

        public Service GetDetail(int id)
        {
            if (id == 0) return null;
            var service = _servicesAdminRepository.GetDetail(id);
            return service;
        }

        public bool Edit(Service service)
        {
            if (service == null) return false;
            var editService = _servicesAdminRepository.EditService(service);
            return true;
        }

        public bool Delete(int id)
        {
            if (id == 0) return false;
            var deleteSuccess = _servicesAdminRepository.Delete(id);
            return true;
        }

        public bool? ChangeStatus(int id)
        {
            var status = _servicesAdminRepository.ChangeStatus(id);
            return status;
        }
    }
}