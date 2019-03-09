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
    public class MainPageViewModel : BindableObject
    {

        private INavigationService navigationService;
        public ITransactionService transactionService;

        public MainPageViewModel(INavigationService _navigationService, ITransactionService _transactionService)
        {
            navigationService = _navigationService;
            transactionService = _transactionService;
            PopulateTransactions();
        }

        private ObservableCollection<Transaction> _transactions;
        public ObservableCollection<Transaction> transactions
        {
            get => _transactions;
            set
            {
                _transactions = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand => new Command(OpenNewModal);
        public ICommand UpdateCommand => new Command(PopulateTransactions);
        public ICommand EditCommand => new Command<Transaction>(EditModal);

        public bool isCreating = false;

        public async void OpenNewModal()
        {
            if (isCreating)
            {
                return;
            }
            isCreating = true;
            await navigationService.CreateModal<AddTransactionModalViewModel>();
            isCreating = false;
        }

        private async void EditModal(Transaction transaction)
        {
            if (isCreating)
            {
                return;
            }
            isCreating = true;
            await navigationService.CreateModal<EditTransactionModalViewModel>();
            MessagingCenter.Send(this, "EditingTransaction", transaction);
            isCreating = false;
        }

        public void PopulateTransactions()
        {
            transactions = transactionService.GetAll();
        }
    }
}
