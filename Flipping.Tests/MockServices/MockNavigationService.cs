using Flipping.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flipping.Tests.MockServices
{
    class MockNavigationService : INavigationService
    {
        public Task CreateModal<T>()
        {
            return SimpleAsync();
        }
        public Task RemoveModal()
        {
            return SimpleAsync();
        }

        public void ReloadMainPage()
        {
            
        }

        public async Task SimpleAsync()
        {
            await Task.Delay(10);
        }
    }
}