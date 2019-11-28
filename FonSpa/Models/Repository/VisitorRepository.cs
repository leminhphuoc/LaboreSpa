using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public class VisitorRepository
    {
        private FonSpaDbContext _db = null;

        public FonSpaDbContext Db { get => _db; set => _db = value; }

        public VisitorRepository()
        {
            _db = new FonSpaDbContext();

        }

        
    }
}
