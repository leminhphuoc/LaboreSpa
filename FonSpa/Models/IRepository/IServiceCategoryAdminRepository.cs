using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.IRepository
{
    public interface IServiceCategoryAdminRepository
    {
        ServiceCategory GetDetail(long id);
        List<ServiceCategory> GetListServiceCategory();
        bool? ChangeStatus(long id);
        long AddServiceCategory(ServiceCategory servicecategory);
        bool EditServiceCategory(ServiceCategory servicecategory);
        bool Delete(long id);
        List<ServiceCategory> ListSearchServiceCategory(string searchString);
        bool CheckExits(string name);
    }
}
