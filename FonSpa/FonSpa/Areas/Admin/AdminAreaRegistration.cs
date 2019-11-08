using System.Web.Mvc;
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