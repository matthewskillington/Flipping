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

        public ICommand DeleteCommand => new Command(DeleteTransaction);

        private void InitializeFields(Transaction transaction)
        {
            selectedTransction = transaction;
            Name = transaction.Name;
            Amount = transaction.Amount;
            BroughtAt = transaction.BroughtAt;
            SoldAt = transaction.SoldAt;
            Id = transaction.Id;
            
        }

        private void DeleteTransaction()
        {
            transactionService.DeleteById(Id);
            navigationService.RemoveModal();
            navigationService.ReloadMainPage();
        }

        private void EditTransaction()
        {
            var newTransaction = new Transaction(Name, Amount, BroughtAt) { Id = Id };

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
