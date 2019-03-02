using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Flipping.Models;
using Xamarin.Forms;

namespace Flipping.Services
{
    public class TransactionService : ITransactionService
    {

        public ObservableCollection<Transaction> transactions = new ObservableCollection<Transaction>
        {

        };

        public void SaveToDevice(ObservableCollection<Transaction> transactions)
        {
            var x = 0;
            foreach (Transaction transaction in transactions)
            {
                string[] values = new string[]
                {
                    transaction.Name,
                    transaction.Amount.ToString(),
                    transaction.BroughtAt.ToString(),
                    transaction.SoldAt.ToString()
                };
                Application.Current.Properties[x.ToString()] = values;
                x++;
            }
        }
        
        public void SaveToDevice(Transaction transaction)
        {
            string[] values = new string[]
                {
                    transaction.Name,
                    transaction.Amount.ToString(),
                    transaction.BroughtAt.ToString(),
                    transaction.SoldAt.ToString()
                };
            Application.Current.Properties[transaction.Name] = values;
        }

        public ObservableCollection<Transaction> GetAll()
        {
            return transactions;
        }
    }
}
