using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Flipping.Models
{
    public class TransactionList
    {
        public TransactionList()
        {
            transactions = new ObservableCollection<Transaction>();
        }

        private ObservableCollection<Transaction> _transactions;

        public ObservableCollection<Transaction> transactions {
            get
            {
                return _transactions;
            }
            set
            {
                //TODO: STILL NEED TO CHECK IF ID ALREADY EXISTS!
                Random random = new Random();
                value.Single(x => x.Id == "").Id = random.Next(1, 100000).ToString();
                _transactions = value;
            }
        }

        public int Count {
            get => transactions.Count();
        }
    }
}
