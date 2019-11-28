using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FonSpa.Services.IServices
{
    public interface IServiceCategoryAdminServices
    {
        List<ServiceCategory> ListAllByName(string searchString);
        List<ServiceCategory> GetServiceCategory();
        long AddServiceCategory(ServiceCategory servicecategory);
        bool Delete(int id);
        ServiceCategory GetDetail(int id);
        bool Edit(ServiceCategory servicecategory);
        bool? ChangeStatus(int id);
    }
}