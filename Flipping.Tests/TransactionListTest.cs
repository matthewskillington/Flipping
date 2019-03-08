using Flipping.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xunit;

namespace Flipping.Tests.ModelTest
{
    public class TransactionListTest
    {
        [Fact]
        public void CheckIdIsAssignedTest()
        {
            TransactionList list = new TransactionList();

            list.transactions = new ObservableCollection<Transaction>{
                new Transaction("Dragon Longsword", 70, 59001, 60800){ Id = "3224" },
                new Transaction("Elysian Spirit Shield", 1, 600000000, 610000000){ Id = "6532"}
            };

            list.transactions.Add(new Transaction("Dragon Dagger(p++)", 70, 59001, 60800));

            Assert.NotEqual("", list.transactions[2].Id);

            
        }
    }
}
