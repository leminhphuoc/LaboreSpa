using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public class ProductAdminRepository : IProductAdminRepository
    {
        private FonSpaDbContext _db = null;

        public FonSpaDbContext Db { get => _db; set => _db = value; }

        public ProductAdminRepository()
        {
            _db = new FonSpaDbContext();
        }

        public Product GetDetail(long id)
        {
            var product = _db.Products.Find(id);
            return product;
        }

        public List<Product> GetListProduct()
        {
            return _db.Products.ToList();
        }

        public long AddProduct(Product product)
        {
            var addProduct = _db.Products.Add(product);
            _db.SaveChanges();
            return addProduct.id;
        }

        public bool EditProduct(Product product)
        {
            var productEdit = _db.Products.Where(x => x.id == product.id).SingleOrDefault();
            productEdit.name = product.name;
            productEdit.metaTitle = productEdit.metaTitle;
            productEdit.description = productEdit.description;
            productEdit.image = productEdit.image;
            productEdit.moreImages = productEdit.moreImages;
            productEdit.price = productEdit.price;
            productEdit.promotionPrice = productEdit.promotionPrice;
            productEdit.quantity = productEdit.quantity;
            productEdit.idCategory = productEdit.idCategory;
            productEdit.detail = productEdit.detail;
            productEdit.modifiDate = DateTime.Now;
            productEdit.status = productEdit.status;
            productEdit.topHot = productEdit.topHot;
            _db.SaveChanges();
            return true;
        }

        public bool Delete(long id)
        {
            var product = _db.Products.Find(id);
            if (product != null)
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
            }
            return true;
        }

        public bool? ChangeStatus(long id)
        {
            if (id == 0) return false;
            var accountNeedChange = _db.Products.Find(id);
            accountNeedChange.status = !accountNeedChange.status;
            _db.SaveChanges();
            return accountNeedChange.status;
        }

        public List<Product> ListSearchProduct(string searchString)
        {
            if (searchString == null) return null;

            var listProduct = _db.Products.Where(x => x.name.ToUpper() == searchString.ToUpper());
            return listProduct.ToList();
        }

        public List<ProductCategory> GetProductCategories()
        {
            return _db.ProductCategories.ToList();
        }

    }
}
