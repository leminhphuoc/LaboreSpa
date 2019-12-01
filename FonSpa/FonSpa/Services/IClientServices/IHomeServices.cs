using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FonSpa.Services.IClientServices
{
    public interface IHomeServices
    {
        List<Menu> ListMenu();
        List<Slide> ListSlide();
        List<ProductCategory> ListProductCategories();
        List<ServiceCategory> ListServiceCategory();
        List<ContentCategory> ListContentCategory();
        List<Room> ListRoom();
        List<Bed> ListBed();
        List<Service> ListServices();
        List<Footer> ListFooter();
        List<FooterCategory> ListFooterCategory();
    }
}
