using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public class ProductCategoryRepository
    {
        private FonSpaDbContext _db = null;

        public FonSpaDbContext Db { get => _db; set => _db = value; }

        public ProductCategoryRepository()
        {
            _db = new FonSpaDbContext();
        }

        public List<ProductCategory> GetList()
        {
            return _db.ProductCategories.ToList();
        }
    }
}
