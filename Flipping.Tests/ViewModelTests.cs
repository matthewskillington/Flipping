using System;
using System.Collections.ObjectModel;
using Flipping.Models;
using Flipping.Services;
using Flipping.Tests.MockServices;
using Flipping.ViewModels;
using Xunit;

namespace Flipping.Tests
{
    public class ViewModelTests
    {
        [Fact]
        public void MainPageViewModelTest_PopulateTransactions()
        {
            INavigationService navservice = new MockNavigationService();
            ITransactionService transervice = new MockTransactionService();
            MainPageViewModel vm = new MainPageViewModel(navservice, transervice);

            ObservableCollection<Transaction> results = vm.transactions;
            ObservableCollection<Transaction> expected = new ObservableCollection<Transaction>{
                new Transaction("Dragon Longsword", 70, 59001, 60500)
            };   
            Assert.Equal(results[0].Name, expected[0].Name);
        }


    }
}
