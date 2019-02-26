using Flipping.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Flipping.ViewModels
{
    class TransactionsViewModel : BindableObject
    {
        public TransactionsViewModel()
        {
        }

        public ObservableCollection<Transaction> transactions = new ObservableCollection<Transaction>
        {
            new Transaction("Combat Potion(2)", 1000, 390, 415),
            new Transaction("Magic Potion(4)", 5000, 5, 25)
        };

        

        public ICommand AddCommand => new Command(SaveToDevice);

        public void SaveToDevice()
        {
            transactions.Add(new Transaction("New item", 100, 10, 20));

            var x = 0;
            foreach(Transaction transaction in transactions)
            {
                string[] values = new string[]
                {
                    transactions[x].Name,
                    transactions[x].Amount.ToString(),
                    transactions[x].BroughtAt.ToString(),
                    transactions[x].SoldAt.ToString()
                };
                Application.Current.Properties[x.ToString()] =  values;
                x++;
            }
        }
    }
}
