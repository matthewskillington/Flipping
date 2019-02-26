using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flipping.Models;
using Xamarin.Forms;

namespace Flipping
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            RenderTransactions();
        }
        // ViewModel logic to be seperated later
        private ObservableCollection<Transaction> transactions = new ObservableCollection<Transaction>
        {
            new Transaction("Combat Potion(2)", 1000, 390),
            new Transaction("Magic Potion(4)", 5000, 5),
        };


        public void RenderTransactions()
        {
            foreach (Transaction transaction in transactions)
            {
                layout.Children.Add(new Label
                {
                    Text = transaction.Name
                });
                layout.Children.Add(new Label
                {
                    Text = transaction.Amount.ToString()
                });
                layout.Children.Add(new Label
                {
                    Text = transaction.BroughtAt.ToString()
                });
            }

        }
    }
}
