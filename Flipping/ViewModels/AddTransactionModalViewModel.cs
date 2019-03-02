﻿using Flipping.Models;
using Flipping.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Flipping.ViewModels
{
    class AddTransactionModalViewModel : BindableObject
    {
        public ITransactionService _transactionService;

        public AddTransactionModalViewModel(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        private Transaction selectedTransction;
        public string name;
        public string Name {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        private int amount;
        public int Amount {
            get => amount;
            set
            {
                amount = value;
                OnPropertyChanged();
            }
        }
        public int broughtAt;
        public int BroughtAt
        {
            get => broughtAt;
            set
            {
                broughtAt = value;
                OnPropertyChanged();
            }
        }
        public int soldAt;
        public int SoldAt
        {
            get => soldAt;
            set
            {
                soldAt = value;
                OnPropertyChanged();
            }
        }

        public AddTransactionModalViewModel()
        {

        }

        public ICommand SubmitCommand => new Command(ConstructTransaction);

        

        private void ConstructTransaction()
        {
            var newTransaction = new Transaction(Name, Amount, BroughtAt);

            if (SoldAt > 0)
            {
                newTransaction.SoldAt = SoldAt;
            }
            selectedTransction = newTransaction;

            _transactionService.SaveToDevice(newTransaction);

        }
    }
}
