using Flipping.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Flipping.Services
{
    public interface ITransactionService
    {
        ObservableCollection<Transaction> GetAll();
        
    }
}
