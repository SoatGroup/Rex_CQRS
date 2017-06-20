using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using SOAT_CQRS.Application.Query;
using SOAT_CQRS.Domain.Model;
using SOAT_CQRS.Domain.Services;
using SOAT_CQRS.Infrastructure.Repositories;

namespace SOAT_CQRS.Infrastructure
{
    public class DependencyFactory
    {
        private static IUnityContainer _container;

        /// <summary>
        /// Public reference to the unity container which will 
        /// allow the ability to register instrances or take 
        /// other actions on the container.
        /// </summary>
        public static IUnityContainer Container
        {
            get
            {
                return _container;
            }
            private set
            {
                _container = value;
            }
        }

        /// <summary>
        /// Static constructor for DependencyFactory which will 
        /// initialize the unity container.
        /// </summary>
        static DependencyFactory()
        {
            _container = new UnityContainer();
            RegisterCommands();
            RegisterQueries();     
            RegisterFactories();           
        }

        /// <summary>
        /// Resolves the type parameter T to an instance of the appropriate type.
        /// </summary>
        /// <typeparam name="T">Type of object to return</typeparam>
        public static T Resolve<T>()
        {
            T ret = default(T);

            if (Container.IsRegistered(typeof(T)))
            {
                ret = Container.Resolve<T>();
            }

            return ret;
        }

        #region Enregistrement des services

        private static void RegisterFactories()
        {
            _container.RegisterType(typeof(IFoyerRepository), typeof(FoyerRepository));
            _container.RegisterType(typeof(IFoyerReadRepository), typeof(FoyerRepository));
            _container.RegisterType(typeof(IFoyerWriteRepository), typeof(FoyerRepository));
        }


        private static void RegisterQueries()
        {
            var queryHandlerType = typeof(IQueryHandler<,>);
            var types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(
                    t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == queryHandlerType))
                .ToList();

            foreach (var type in types)
            {
                var interfaceType = type.GetInterfaces().Single(i => i.IsGenericType && (i.GetGenericTypeDefinition() == queryHandlerType));
                _container.RegisterType(interfaceType, type);
            }

            //_container.RegisterType(typeof(IQueryHandler<ChargerListeFoyerQuery,ChargerListeFoyerDTO>), typeof(ChargerFoyerQueryHandler));           
        }

        private static void RegisterCommands()
        {
            var commandHandlerType = typeof(ICommandHandler<>);
            var types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(
                    t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == commandHandlerType))
                .ToList();

            foreach (var type in types)
            {
                var interfaceType = type.GetInterfaces().Single(i => i.IsGenericType && (i.GetGenericTypeDefinition() == commandHandlerType));
                _container.RegisterType(interfaceType, type);
            }
        }

        #endregion
    }
}
