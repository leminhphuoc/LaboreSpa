using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public class CustomerAdminRepository : ICustomerAdminRepository
    {
        private FonSpaDbContext _db = null;

        public FonSpaDbContext Db { get => _db; set => _db = value; }

        public CustomerAdminRepository()
        {
            _db = new FonSpaDbContext();
        }

        public Customer GetDetail(long id)
        {
            var customer = _db.Customers.Find(id);
            return customer;
        }

        public List<Customer> GetListCustomer()
        {
            return _db.Customers.ToList();
        }

        public long AddCustomer(Customer customer)
        {
            var addCustomer = _db.Customers.Add(customer);
            _db.SaveChanges();
            return addCustomer.id;
        }

        public bool EditCustomer(Customer customer)
        {
            var customerEdit = _db.Customers.Where(x => x.id == customer.id).SingleOrDefault();
            customerEdit.userName = customer.userName;
            customerEdit.passWord = customer.passWord;
            customerEdit.email = customer.email;
            customerEdit.phone = customer.phone;
            customerEdit.address = customer.address;
            customerEdit.typeMember = customer.typeMember;
            customerEdit.token = customer.token;
            customerEdit.modifiedDate = DateTime.Now;
            customerEdit.status = customer.status;
            _db.SaveChanges();
            return true;
        }

        public bool Delete(long id)
        {
            var customer = _db.Customers.Find(id);
            if (customer != null)
            {
                _db.Customers.Remove(customer);
                _db.SaveChanges();
            }
            return true;
        }

        public bool? ChangeStatus(long id)
        {
            if (id == 0) return false;
            var accountNeedChange = _db.Customers.Find(id);
            accountNeedChange.status = !accountNeedChange.status;
            _db.SaveChanges();
            return accountNeedChange.status;
        }

        public List<Customer> ListSearchCustomer(string searchString)
        {
            if (searchString == null) return null;

            var listCustomer = _db.Customers.Where(x => x.userName.ToUpper() == searchString.ToUpper());
            return listCustomer.ToList();
        }

    }
}
