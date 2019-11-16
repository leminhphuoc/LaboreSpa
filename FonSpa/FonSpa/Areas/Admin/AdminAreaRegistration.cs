﻿using System.Web.Mvc;
using Unity.Mvc5;
using Unity;
using Models.IRepository;
using Models.Repository;
using FonSpa.Services.IServices;
using FonSpa.Services.Services;

namespace FonSpa.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
       
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            var container = new UnityContainer();
            container.RegisterType<IAccountAdminRepository, AccountAdminRepository>();
            container.RegisterType<IAccountAdminServices, AccountAdminServices>();
            container.RegisterType<IProductAdminRepository, ProductAdminRepository>();
            container.RegisterType<IProductAdminSerivces, ProductAdminSerivces>();
            container.RegisterType<IServiceAdminRepository, ServiceAdminRepository>();
            container.RegisterType<IServicesAdminServices, ServicesAdminServices>();
            container.RegisterType<IContentAdminRepository, ContentAdminRepository>();
            container.RegisterType<IContentServices, ContentServices>();
            container.RegisterType<ICustomerAdminRepository, CustomerAdminRepository>();
            container.RegisterType<ICustomerAdminServices, CustomerAdminServices>();
            container.RegisterType<IMenuAdminRepository, MenuAdminRepository>();
            container.RegisterType<IMenuAdminServices, MenuAdminServices>();
            container.RegisterType<IFooterAdminServices, FooterAdminServices>();
            container.RegisterType<IFooterAdminRepository, FooterAdminRepository>();
            container.RegisterType<IContactAdminServices, ContactAdminServices>();
            container.RegisterType<IContactAdminRepository, ContactAdminRepository>();
            container.RegisterType<ISlideAdminServices, SlideAdminServices>();
            container.RegisterType<ISlideAdminRepository, SlideAdminRepository>();
            container.RegisterType<IServicesAdminServices, ServicesAdminServices>();
            container.RegisterType<IServiceAdminRepository, ServiceAdminRepository>();
            container.RegisterType<IProductCategoryAdminServices, ProductCategoryAdminService>();
            container.RegisterType<IProductCategoryAdminRepository, ProductCategoryAdminRepository>();
            container.RegisterType<IAboutAdminServices, AboutAdminServices>();
            container.RegisterType<IAboutAdminRepository, AboutAdminRepository>();
            container.RegisterType<IStaffAdminServices, StaffAdminServices>();
            container.RegisterType<IStaffAdminRepository, StaffAdminRepository>();
            container.RegisterType<IContentCategoryAdminServices, ContentCategoryAdminServices>();
            container.RegisterType<IContentCategoryAdminRepository, ContentCategoryAdminRepository>();
            container.RegisterType<IServiceCategoryAdminServices, ServiceCategoryAdminServices>();
            container.RegisterType<IServiceCategoryAdminRepository, ServiceCategoryAdminRepository>();
            container.RegisterType<IMenuTypeSerivces, MenuTypeAdminServices>();
            container.RegisterType<IMenuTypeAdminRepository, MenuTypeAdminRepository>();
            container.RegisterType<IFooterCategoryAdminServices, FooterCategoryAdminServices>();
            container.RegisterType<IFooterCategoryAdminRepository, FooterCategoryAdminRepository>();

            container.RegisterType<IIPAddressRepository, IPAddressRepository>();


            container.RegisterType<IContactClientServices, ContactClientServices>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            //Admin Account

            context.MapRoute(
                "CreateAccount",
                "Admin/createaccount",
                new { action = "Create", Controller = "AccountAdmin" }
            );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}