using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public class ServiceAdminRepository : IServiceAdminRepository
    {
        private FonSpaDbContext _db = null;

        public FonSpaDbContext Db { get => _db; set => _db = value; }

        public ServiceAdminRepository()
        {
            _db = new FonSpaDbContext();
        }

        public Service GetDetail(long id)
        {
            var service = _db.Services.Find(id);
            return service;
        }

        public List<Service> GetListService()
        {
            return _db.Services.ToList();
        }

        public long AddService(Service service)
        {
            var addService = _db.Services.Add(service);
            _db.SaveChanges();
            return addService.id;
        }

        public bool EditService(Service service)
        {
            var serviceEdit = _db.Services.Where(x => x.id == service.id).SingleOrDefault();
            serviceEdit.name = service.name;
            serviceEdit.metaTitle = service.metaTitle;
            serviceEdit.description = service.description;
            serviceEdit.image = service.image;
            serviceEdit.moreImages = service.moreImages;
            serviceEdit.price = service.price;
            serviceEdit.promotionPrice = service.promotionPrice;
            serviceEdit.quantity = service.quantity;
            serviceEdit.idCategory = service.idCategory;
            serviceEdit.detail = service.detail;
            serviceEdit.modifiDate = DateTime.Now;
            serviceEdit.status = service.status;
            serviceEdit.topHot = service.topHot;
            _db.SaveChanges();
            return true;
        }

        public bool Delete(long id)
        {
            var service = _db.Services.Find(id);
            if (service != null)
            {
                _db.Services.Remove(service);
                _db.SaveChanges();
            }
            return true;
        }

        public bool? ChangeStatus(long id)
        {
            if (id == 0) return false;
            var accountNeedChange = _db.Services.Find(id);
            accountNeedChange.status = !accountNeedChange.status;
            _db.SaveChanges();
            return accountNeedChange.status;
        }

        public List<Service> ListSearchService(string searchString)
        {
            if (searchString == null) return null;

            var listService = _db.Services.Where(x => x.name.ToUpper() == searchString.ToUpper());
            return listService.ToList();
        }

        public List<ServiceCategory> GetServiceCategories()
        {
            return _db.ServiceCategories.ToList();
        }

    }
}
