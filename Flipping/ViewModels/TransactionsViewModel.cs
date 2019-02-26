using Flipping.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Flipping.ViewModels
{
    class TransactionsViewModel : BindableObject
    {

        public ObservableCollection<Transaction> transactions = new ObservableCollection<Transaction>
        {
            new Transaction("Combat Potion(2)", 1000, 390, 415),
            new Transaction("Magic Potion(4)", 5000, 5, 25)
        };
    }
}
