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
        public void SaveToDevice(Transaction transaction)
        {

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
