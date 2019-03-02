using System;
using Autofac;
using Flipping.Services;
using Flipping.ViewModels;

namespace Flipping.Bootstrap
{
    public class AppContainer
    {
        private static IContainer _container;

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            //ViewModels
            builder.RegisterType<MainPageViewModel>();
            builder.RegisterType<AddTransactionModalViewModel>();
            //Services
            builder.RegisterType<NavigationService>().As<INavigationService>();
            builder.RegisterType<TransactionService>().As<ITransactionService>();

            _container = builder.Build();
        }


        public static object Resolve(Type type)
        {
            return _container.Resolve(type);
        }

        public static T resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
