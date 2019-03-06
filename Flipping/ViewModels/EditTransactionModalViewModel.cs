using Flipping.Models;
using Flipping.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Flipping.ViewModels
{
    public class EditTransactionModalViewModel : AddTransactionModalViewModel
    {
        public EditTransactionModalViewModel(
            ITransactionService _transactionService,
            INavigationService _navigationService
        ): base(_transactionService, _navigationService)
        {
            InitializeMessenger();
        }


        private void InitializeMessenger()
        {
            MessagingCenter.Subscribe<MainPageViewModel, Transaction>(this, "EditingTransaction",
            (mainViewModel, transaction) => InitializeFields(transaction));
        }

        public ICommand SubmitEditCommand => new Command(EditTransaction);

        private void InitializeFields(Transaction transaction)
        {
            selectedTransction = transaction;
            Name = transaction.Name;
            Amount = transaction.Amount;
            BroughtAt = transaction.BroughtAt;
            SoldAt = transaction.SoldAt;
        }

        private void EditTransaction()
        {
            var newTransaction = new Transaction(Name, Amount, BroughtAt);

            if (SoldAt > 0)
            {
                newTransaction.SoldAt = SoldAt;
            }
            selectedTransction = newTransaction;

            transactionService.SaveToDeviceEdit(newTransaction);
            navigationService.RemoveModal();
            navigationService.ReloadMainPage();
        }
    }
}
