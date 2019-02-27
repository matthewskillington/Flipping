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
            builder.RegisterType<TransactionsViewModel>();
            builder.RegisterType<AddTransactionModalViewModel>();
            //Services
            builder.RegisterType<NavigationService>().As<INavigationService>();
        }
    }
}
