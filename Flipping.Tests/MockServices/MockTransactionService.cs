using Flipping.Models;
using Flipping.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Flipping.Tests.MockServices
{
    class MockTransactionService : ITransactionService
    {
        public void SaveToDevice(ObservableCollection<Transaction> transactions)
        {

        }
        public void SaveToDeviceNew(Transaction transaction)
        {

        }
        public void SaveToDeviceEdit(Transaction transaction)
        {

        }

        public Transaction GetByName(string name)
        {
            return new Transaction("something", 0, 0, 0);
        }

        public ObservableCollection<Transaction> GetAll()
        {
            return new ObservableCollection<Transaction>
            {
                new Transaction("Dragon Longsword", 70, 59001, 60500)
            };
        }

    }
}
