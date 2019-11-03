using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.IRepository
{
    public interface IServiceAdminRepository
    {
        Service GetDetail(long id);
        List<Service> GetListService();
        bool? ChangeStatus(long id);
        long AddService(Service service);
        bool EditService(Service service);
        bool Delete(long id);
        List<Service> ListSearchService(string searchString);
        List<ServiceCategory> GetServiceCategories();
    }
}
