using Flipping.Models;
using Flipping.Services;
using System;
using System.Collections.Generic;
using System.Text;
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

        private void InitializeFields(Transaction transaction)
        {
            Name = transaction.Name;
            Amount = transaction.Amount;
            BroughtAt = transaction.BroughtAt;
            SoldAt = transaction.SoldAt;
        }
    }
}
