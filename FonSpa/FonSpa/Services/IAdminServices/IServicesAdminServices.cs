using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonSpa.Services.IServices
{
    public interface IServicesAdminServices
    {
        List<Service> ListAllByName(string searchString);
        List<ServiceCategory> GetServiceCategory();
        long AddService(Service service);
        bool Delete(int id);
        Service GetDetail(int id);
        bool Edit(Service service);
        bool? ChangeStatus(int id);
    }
}
