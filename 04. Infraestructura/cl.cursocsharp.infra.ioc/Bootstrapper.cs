using cl.cursocsharp.dominio;
using cl.cursocsharp.dominio.contratos;
using cl.cursocsharp.dominio.entidades;
using cl.cursocsharp.infra.datos;
using cl.cursocsharp.infra.datos.Repo;
using cl.cursocsharp.infra.datos.UoW;
using System.Data.Entity;
using System.Web.Mvc;
using Unity;
using Unity.Lifetime;

namespace cl.cursocsharp.infra.ioc
{
    public static class Bootstrapper
    {
        private static IUnityContainer container;

        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {

            if (container == null)
                container = new UnityContainer();

            RegisterTypes(container);
            RegisterUnitOfWork(container);
            RegisterProfiles();
            RegisterRepositories(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {            
            container.RegisterType<IEjemplo, ejemplo>(new PerResolveLifetimeManager());
            container.RegisterType<IProcesoFacturacion, ProcesoFacturacion>(new PerResolveLifetimeManager());
            
        }

        private static void RegisterRepositories(IUnityContainer container)
        {
            container.RegisterType(typeof(IRepository<Factura>), typeof(Repository<Factura>));

            
        }
        private static void RegisterProfiles()
        {
            //AutoMapper.Mapper.Initialize(c =>
            //{
            //    c.AddProfile<ADCCustom>();

            //});
        }

        private static void RegisterUnitOfWork(IUnityContainer container)
        {
           
            container.RegisterType<IUnitOfWork, UnitOfWork<Entities>>(new PerResolveLifetimeManager());
            container.RegisterType<DbSet>(new PerResolveLifetimeManager());
        }
    }
}
