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
        void SaveToDeviceNew(Transaction transaction);
        void SaveToDeviceEdit(Transaction transaction);
        void DeleteById(Guid id);
        ObservableCollection<Transaction> GetAll();
        Transaction GetByName(string name);
    }
}
