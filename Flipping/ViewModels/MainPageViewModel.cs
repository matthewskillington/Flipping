using Flipping.Models;
using Flipping.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Flipping.ViewModels
{
    class MainPageViewModel : BindableObject
    {

        private INavigationService navigationService;
        public ITransactionService transactionService;

        public MainPageViewModel(INavigationService _navigationService, ITransactionService _transactionService)
        {
            navigationService = _navigationService;
            transactionService = _transactionService;
            PopulateTransactions();
        }

        public ObservableCollection<Transaction> transactions;

        public ICommand AddCommand => new Command(OpenNewModal);

        public bool isSaving = false;

        public async void OpenNewModal()
        {
            if (isSaving)
            {
                return;
            }
            isSaving = true;
            await navigationService.CreateModal<AddTransactionModalViewModel>();
            isSaving = false;
        }

        public void PopulateTransactions()
        {
            ObservableCollection<Transaction> transac1 = new ObservableCollection<Transaction>
            {
                new Transaction("cb pot", 100, 230, 250),
                new Transaction("mage pot", 100, 200, 250)
            };
            transactionService.SaveToDevice(transac1);
            transactions = transactionService.GetAll();
        }
    }
}
