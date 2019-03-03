using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Flipping.Models;
using Xamarin.Forms;

namespace Flipping.Services
{
    public class TransactionService : ITransactionService
    {

        public void SaveToDevice(ObservableCollection<Transaction> transactions)
        {
            foreach (Transaction transaction in transactions)
            {
                SaveToDevice(transaction);
            }
        }
        
        public void SaveToDevice(Transaction transaction)
        {
            string objectToSave = $"{transaction.Name},{transaction.Amount.ToString()},{transaction.BroughtAt.ToString()},{transaction.SoldAt.ToString()}";
            Application.Current.Properties[transaction.Name] = objectToSave;
        }

        public ObservableCollection<Transaction> GetAll()
        {
            return KeyPairToObservable(Application.Current.Properties);
        }

        public ObservableCollection<Transaction> KeyPairToObservable(IDictionary<string, object> keyValuePairs)
        {
            ObservableCollection<Transaction> transactions = new ObservableCollection<Transaction>();

            foreach(KeyValuePair<string, object> keyValuePair in keyValuePairs)
            {
                string[] arr = keyValuePair.Value.ToString().Split(',');
                int.TryParse(arr[1], out int Amount);
                int.TryParse(arr[2], out int BroughtAt);
                int.TryParse(arr[3], out int SoldAt);
                transactions.Add(new Transaction(keyValuePair.Key, Amount, BroughtAt, SoldAt));
            }
            return transactions;
        }
    }
}
