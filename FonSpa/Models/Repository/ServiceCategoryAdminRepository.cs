using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public class ServiceCategoryAdminRepository : IServiceCategoryAdminRepository
    {
        private FonSpaDbContext _db = null;

        public FonSpaDbContext Db { get => _db; set => _db = value; }

        public ServiceCategoryAdminRepository()
        {
            _db = new FonSpaDbContext();
        }

        public ServiceCategory GetDetail(long id)
        {
            var servicecategogry = _db.ServiceCategories.Find(id);
            return servicecategogry;
        }

        public List<ServiceCategory> GetListServiceCategory()
        {
            return _db.ServiceCategories.ToList();
        }

        public long AddServiceCategory(ServiceCategory servicecategory)
        {
            servicecategory.status = false;
            servicecategory.createdDate = DateTime.Now;
            var AddServiceCategory = _db.ServiceCategories.Add(servicecategory);
            _db.SaveChanges();
            return AddServiceCategory.id;
        }

        public bool EditServiceCategory(ServiceCategory servicecategory)
        {
            var ServiceCategoryEdit = _db.ServiceCategories.Where(x => x.id == servicecategory.id).SingleOrDefault();
            ServiceCategoryEdit.name = servicecategory.name;
            ServiceCategoryEdit.metatitle = servicecategory.metatitle;
            ServiceCategoryEdit.parentID = servicecategory.parentID;
            ServiceCategoryEdit.displayOrder = servicecategory.displayOrder;
            ServiceCategoryEdit.modifiedDate = DateTime.Now;
            ServiceCategoryEdit.status = servicecategory.status;
            ServiceCategoryEdit.showOnHome = servicecategory.showOnHome;
            _db.SaveChanges();
            return true;
        }

        public bool Delete(long id)
        {
            var servicecategory = _db.ServiceCategories.Find(id);
            if (servicecategory != null)
            {
                _db.ServiceCategories.Remove(servicecategory);
                _db.SaveChanges();
            }
            return true;
        }

        public bool? ChangeStatus(long id)
        {
            if (id == 0) return false;
            var accountNeedChange = _db.ServiceCategories.Find(id);
            accountNeedChange.status = !accountNeedChange.status;
            _db.SaveChanges();
            return accountNeedChange.status;
        }

        public List<ServiceCategory> ListSearchServiceCategory(string searchString)
        {
            if (searchString == null) return null;

            var listServiceCategory = _db.ServiceCategories.Where(x => x.name.ToUpper() == searchString.ToUpper());
            return listServiceCategory.ToList();
        }

        public bool CheckExits(string name)
        {
            var servicecategory = _db.ServiceCategories.Where(x => x.name == name).SingleOrDefault();
            if (servicecategory != null) return true;
            return false;
        }
    }
}
