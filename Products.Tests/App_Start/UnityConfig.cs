using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Products.Domain;

namespace Products.Tests
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IProducts, ProductService>();
            container.RegisterType<ICategory, CategoryService>();
            container.RegisterType<IProductDetails, ProductDetailsService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

        }
    }
}