using FonSpa.Services.IClientServices;
using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FonSpa.Services.ClientServices
{
    public class HomeServices : IHomeServices
    {
        private readonly IMenuAdminRepository _menuAdminRepository;
        private readonly ISlideAdminRepository _slideAdminRepository;
        private readonly IProductCategoryAdminRepository _productCategoryAdminRepository;
        private readonly IServiceCategoryAdminRepository _serviceCategoryAdminRepository;
        private readonly IContentCategoryAdminRepository _contentCategoryAdminRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IBedRepository _bedRepository;
        private readonly IServiceAdminRepository _serviceAdminRepository;
        private readonly IFooterCategoryAdminRepository _footerCategoryAdminRepository;
        private readonly IFooterAdminRepository _footerAdminRepository;
        private readonly IAboutAdminRepository _aboutAdminRepository;
        public HomeServices(IMenuAdminRepository menuAdminRepository, ISlideAdminRepository slideAdminRepository, IProductCategoryAdminRepository productCategoryAdminRepository, IServiceCategoryAdminRepository serviceCategoryAdminRepository, IContentCategoryAdminRepository contentCategoryAdminRepository, IBookingRepository bookingRepository, IRoomRepository roomRepository,
            IBedRepository bedRepository, IServiceAdminRepository serviceAdminRepository, IFooterAdminRepository footerAdminRepository, IFooterCategoryAdminRepository footerCategoryAdminRepository, IAboutAdminRepository aboutAdminRepository)
        {
            _menuAdminRepository = menuAdminRepository;
            _slideAdminRepository = slideAdminRepository;
            _productCategoryAdminRepository = productCategoryAdminRepository;
            _serviceCategoryAdminRepository = serviceCategoryAdminRepository;
            _contentCategoryAdminRepository = contentCategoryAdminRepository;
            _bookingRepository = bookingRepository;
            _roomRepository = roomRepository;
            _bedRepository = bedRepository;
            _serviceAdminRepository = serviceAdminRepository;
            _footerCategoryAdminRepository = footerCategoryAdminRepository;
            _footerAdminRepository = footerAdminRepository;
            _aboutAdminRepository = aboutAdminRepository;
        }

        public List<Menu> ListMenu()
        {
            return _menuAdminRepository.GetListMenu();
        }

        public List<Slide> ListSlide()
        {
            return _slideAdminRepository.GetListTrue();
        }

        public List<Booking> ListBooking()
        {
            return _bookingRepository.GetList();
        }

        public List<Room> ListRoom()
        {
            return _roomRepository.GetList();
        }

        public List<Bed> ListBed()
        {
            return _bedRepository.GetList();
        }

        public List<About> ListAbout()
        {
            return _aboutAdminRepository.GetListAbout();
        }

        public List<Service> ListServices()
        {
            return _serviceAdminRepository.GetListService().Where(x=>x.status == true ).OrderBy(x=>x.createdDate).ToList();
        }

        public List<ProductCategory> ListProductCategories()
        {
            return _productCategoryAdminRepository.GetListProductCategory();
        }

        public List<ServiceCategory> ListServiceCategory()
        {
            return _serviceCategoryAdminRepository.GetListServiceCategory();
        }
        public List<ContentCategory> ListContentCategory()
        {
            return _contentCategoryAdminRepository.GetListContentCategory();
        }

        public List<Footer> ListFooter()
        {
            return _footerAdminRepository.GetListFooter().Where(x=>x.status == true).OrderBy(x=>x.displayOrder).ToList(); 
        }

        public List<FooterCategory> ListFooterCategory()
        {
            return _footerAdminRepository.GetFooterCategories();
        }

    }
}