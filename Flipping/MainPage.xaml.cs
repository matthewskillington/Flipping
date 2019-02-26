using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flipping.Models;
using Flipping.ViewModels;
using Xamarin.Forms;

namespace Flipping
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = new TransactionsViewModel();
            InitializeComponent();
            RenderTransactions();
        }

        

        public void RenderTransactions()
        {
            var vm = BindingContext as TransactionsViewModel;

            var row = 0;
            foreach (Transaction transaction in vm.transactions)
            {
                grid.Children.Add(new Label
                {
                    Text = transaction.Name,
                    TextColor = Color.Cyan,
                }, 0, row);
                grid.Children.Add(new Label
                {
                    Text = transaction.Amount.ToString()
                }, 1, row);
                grid.Children.Add(new Label
                {
                    Text = transaction.BroughtAt.ToString() + "gp"
                }, 2, row);
                grid.Children.Add(new Label
                {
                    Text = transaction.SoldAt.ToString() + "gp"
                }, 3, row);
                grid.Children.Add(new Label
                {
                    Text = transaction.Profit.ToString() + "gp"
                }, 4, row);
                row++;

            }
        }
    }
}
