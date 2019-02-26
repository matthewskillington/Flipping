using System;
namespace Flipping.Models
{
    public class Transaction
    {

        public Transaction(string name, int amount, int broughtAt, int soldAt = 0, int profit = 0)
        {
            Name = name;
            Amount = amount;
            BroughtAt = broughtAt;
            SoldAt = soldAt;
            Profit = profit;
        }
        public string Name { get; set; }

        public int Amount { get; set; }

        public int BroughtAt { get; set; }

        public int SoldAt { get; set; }

        public int Profit { get; set; }
    }
}
