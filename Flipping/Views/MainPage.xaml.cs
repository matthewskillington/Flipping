using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flipping.Models;
using Flipping.Utility;
using Flipping.ViewModels;
using Xamarin.Forms;

namespace Flipping.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            RenderTransactions();
        }

        public void RenderTransactions()
        {
            var vm = BindingContext as MainPageViewModel;

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
