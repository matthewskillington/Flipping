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
                SaveToDeviceNew(transaction);
            }
        }
        
        public void SaveToDeviceNew(Transaction transaction)
        {

            string objectToSave = $"{transaction.Name},{transaction.Amount.ToString()},{transaction.BroughtAt.ToString()},{transaction.SoldAt.ToString()}, {transaction.Id.ToString()}";
            Application.Current.Properties[transaction.Id.ToString()] = objectToSave;
        }

        public void SaveToDeviceEdit(Transaction transaction)
        {
            string objectToSave = $"{transaction.Name},{transaction.Amount.ToString()},{transaction.BroughtAt.ToString()},{transaction.SoldAt.ToString()}, {transaction.Id.ToString()}";
            Application.Current.Properties[transaction.Id.ToString()] = objectToSave;
        }

        public void RemoveFromDevice(Transaction transaction)
        {
            Transaction toDelete;
            toDelete = GetByName(transaction.Name);
            Application.Current.Properties[transaction.Name] = null;
        }

        public ObservableCollection<Transaction> GetAll()
        {
            return KeyPairToObservable(Application.Current.Properties);
        }

        public Transaction GetByName(string name)
        {
            ObservableCollection<Transaction> all = GetAll();

            return all.Single(x => x.Name == name);
        }

        public ObservableCollection<Transaction> KeyPairToObservable(IDictionary<string, object> keyValuePairs)
        {
            ObservableCollection<Transaction> transactions = new ObservableCollection<Transaction>();

            foreach(KeyValuePair<string, object> keyValuePair in keyValuePairs)
            {
                string[] arr = keyValuePair.Value.ToString().Split(',');
                string Name = arr[0];
                int.TryParse(arr[1], out int Amount);
                int.TryParse(arr[2], out int BroughtAt);
                int.TryParse(arr[3], out int SoldAt);
                try
                {
                    transactions.Add(new Transaction(Name, Amount, BroughtAt, SoldAt) { Id = new Guid(arr[4]) });
                }
                catch
                {
                    transactions.Add(new Transaction(Name, Amount, BroughtAt, SoldAt));
                }
            }
            return transactions;
        }
    }
}
