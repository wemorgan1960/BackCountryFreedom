using BackCountryFreedom.Core.Contracts;
using BackCountryFreedom.Core.Models;
using BackCountryFreedom.DataAccess.InMemory;
using BackCountryFreedom.DataAccess.SQL;
using System;

using Unity;

namespace BackCountryFreedom.WebUI
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IRepository<ActivityType>, SQLRepository<ActivityType>>();
            container.RegisterType<IRepository<Country>, SQLRepository<Country>>();
            container.RegisterType<IRepository<Difficulty>, SQLRepository<Difficulty>>();
            container.RegisterType<IRepository<DistanceScale>, SQLRepository<DistanceScale>>();
            container.RegisterType<IRepository<ElevationScale>, SQLRepository<ElevationScale>>();
            container.RegisterType<IRepository<Location>, SQLRepository<Location>>();
            container.RegisterType<IRepository<Observation>, SQLRepository<Observation>>();
            container.RegisterType<IRepository<Province>, SQLRepository<Province>>();
            container.RegisterType<IRepository<Rating>, SQLRepository<Rating>>();
            container.RegisterType<IRepository<Season>, SQLRepository<Season>>();
            container.RegisterType<IRepository<Trail>, SQLRepository<Trail>>();
        }
    }
}