using Flipping.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Flipping.Services
{
    public interface ITransactionService
    {
        void SaveToDevice(ObservableCollection<Transaction> transactions);
        void SaveToDevice(Transaction transaction);
        ObservableCollection<Transaction> GetAll();
    }
}
