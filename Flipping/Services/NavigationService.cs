﻿using Flipping.Bootstrap;
using Flipping.ViewModels;
using Flipping.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Flipping.Services
{
    public class NavigationService : INavigationService
    {
        protected Application CurrentApplication => Application.Current;

        private readonly Dictionary<Type, Type> _mappings;

        public NavigationService()
        {
            _mappings = new Dictionary<Type, Type>();
            CreatePageViewModelMappings();
        }

        private void CreatePageViewModelMappings()
        {
            _mappings.Add(typeof(AddTransactionModalViewModel), typeof(AddTransactionModal));
            _mappings.Add(typeof(EditTransactionModalViewModel), typeof(EditTransactionModal));
            _mappings.Add(typeof(MainPageViewModel), typeof(MainPage));
        }

        public async Task CreateModal<TViewModel>()
        {
            var page = CreateAndBindPage(typeof(TViewModel));
            await CurrentApplication.MainPage.Navigation.PushModalAsync(page);
        }

        public void ReloadMainPage()
        {
            Application.Current.MainPage = new MainPage();
        }

        public async Task RemoveModal()
        {
            await CurrentApplication.MainPage.Navigation.PopModalAsync();
        }
        
        private Page CreatePage(Type type)
        {
            Type pageType = GetPageTypeForViewModel(type);

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {type} is null in the NavigationService");
            }
            Page page = Activator.CreateInstance(pageType) as Page;
            return page;
        }

        private Page CreateAndBindPage(Type type)
        {
            var pageType = GetPageTypeForViewModel(type);

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {type} is null in the NavigationService");
            }

            var page = Activator.CreateInstance(pageType) as Page;

            var vm = AppContainer.Resolve(type);

            page.BindingContext = vm;

            return page;
        }

        private Type GetPageTypeForViewModel(Type type)
        {
           if (!_mappings.ContainsKey(type))
            {
                throw new KeyNotFoundException($"No mapping found for ${type} in the NavigationService");
            }
            return _mappings[type];
        }
    }
}
