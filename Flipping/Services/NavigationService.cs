using Flipping.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Flipping.Services
{
    public class NavigationService
    {
        protected Application CurrentApplication => Application.Current;

        private readonly Dictionary<Type, Type> _mappings;

        public NavigationService()
        {
            _mappings = new Dictionary<Type, Type>();
        }

        public async void CreateModal<TViewModel>()
        {
            var page = new AddTransactionModal();
            await CurrentApplication.MainPage.Navigation.PushModalAsync(page);
        }

    }
}
