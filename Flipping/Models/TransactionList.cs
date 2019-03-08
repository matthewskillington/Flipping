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
                if (value.Count > 0)
                {
                    var x = 0;
                    foreach (Transaction item in value)
                    {
                        if (value[x].Id == "")
                        {
                            value[x] = AssignId(value[x]);
                        }
                        x++;
                    }
                    _transactions = value;
                }
            }
        }

        private Transaction AssignId(Transaction transaction)
        {
            //TODO: STILL NEED TO CHECK IF ID ALREADY EXISTS!
            Random random = new Random();
            transaction.Id = random.Next(1, 100000).ToString();
            return transaction;
        }

        public int Count {
            get => transactions.Count();
        }
    }
}
