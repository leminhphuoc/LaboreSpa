using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public class IPAddressRepository : IIPAddressRepository
    {
        private FonSpaDbContext _db = null;

        public FonSpaDbContext Db { get => _db; set => _db = value; }

        public IPAddressRepository()
        {
            _db = new FonSpaDbContext();
        }

        public bool AddIpAddress(string IpAddress)
        {
            if (IpAddress == null) return false;
            if (_db.IPAddresss.Where(x => x.IP == IpAddress).SingleOrDefault() != null) return false;
            var IP = new IPAddress() { IP = IpAddress };
            _db.IPAddresss.Add(IP);
            var Visitor = _db.UsefulInformations.Where(x=>x.Name == "Visitor").SingleOrDefault();
            Visitor.Value += 1;
            _db.SaveChanges();
            return true;
        }

        public int? CountVisitor()
        {
            var visitor = _db.UsefulInformations.Where(x => x.Name == "Visitor").SingleOrDefault();
            var value = visitor.Value;
            return value;
        }
    }
}
