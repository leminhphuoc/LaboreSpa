using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonSpa.Services.IClientServices
{
    public interface IProductServices
    {
        List<Product> ListAll();
        Product GetDetail(long id);
    }
}
