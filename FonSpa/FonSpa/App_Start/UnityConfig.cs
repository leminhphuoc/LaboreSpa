using FonSpa.Services.IServices;
using FonSpa.Services.Services;
using Models.IRepository;
using Models.Repository;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace FonSpa
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IAccountAdminRepository, AccountAdminRepository>();
            container.RegisterType<IAccountAdminServices, AccountAdminServices>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}