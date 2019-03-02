using System;
using System.Threading.Tasks;

namespace Flipping.Services
{
    public interface INavigationService
    {
        Task CreateModal<T>();
        Task RemoveModal();
        void ReloadMainPage();
    }
}
