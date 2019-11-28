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
    public class ServiceCategoryAdminServices : IServiceCategoryAdminServices
    {
        private readonly IServiceCategoryAdminRepository _serviceCategoryAdminRepository;
        public ServiceCategoryAdminServices(IServiceCategoryAdminRepository serviceCategoryAdminRepository)
        {
            _serviceCategoryAdminRepository = serviceCategoryAdminRepository;
        }

        public List<ServiceCategory> ListAllByName(string searchString)
        {
            if (searchString == null || searchString == "")
            {
                return _serviceCategoryAdminRepository.GetListServiceCategory();
            }
            else
            {
                searchString = Helper.RemoveSign4VietnameseString(searchString);
                var ListServiceCategory = _serviceCategoryAdminRepository.ListSearchServiceCategory(searchString);
                return ListServiceCategory;
            }
        }

        public List<ServiceCategory> GetServiceCategory()
        {
            return _serviceCategoryAdminRepository.GetListServiceCategory();
        }

        public long AddServiceCategory(ServiceCategory servicecategory)
        {
            if (servicecategory == null) return 0;
            var addserviceCategory = _serviceCategoryAdminRepository.AddServiceCategory(servicecategory);
            var idServiceCategory = addserviceCategory;
            return idServiceCategory;
        }

        public ServiceCategory GetDetail(int id)
        {
            if (id == 0) return null;
            var servicecategory = _serviceCategoryAdminRepository.GetDetail(id);
            return servicecategory;
        }

        public bool Edit(ServiceCategory servicecategory)
        {
            if (servicecategory == null) return false;
            var editServiceCategory = _serviceCategoryAdminRepository.EditServiceCategory(servicecategory);
            return true;
        }

        public bool Delete(int id)
        {
            if (id == 0) return false;
            var deleteSuccess = _serviceCategoryAdminRepository.Delete(id);
            return true;
        }

        public bool? ChangeStatus(int id)
        {
            var status = _serviceCategoryAdminRepository.ChangeStatus(id); 
            return status;
        }
    }
}