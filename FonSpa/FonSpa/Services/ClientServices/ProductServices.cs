using FonSpa.Services.IClientServices;
using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FonSpa.Services.ClientServices
{
    public class ProductServices : IProductServices
    {
        private readonly IProductAdminRepository _productAdminRepository;
        public ProductServices(IProductAdminRepository productAdminRepository)
        {
            _productAdminRepository = productAdminRepository;
        }

        public List<Product> ListAll()
        {
            return _productAdminRepository.GetListProduct();
        }

        public Product GetDetail(long id)
        {
            if (id == 0) return null;
            return _productAdminRepository.GetDetail(id);
        }

    }
}