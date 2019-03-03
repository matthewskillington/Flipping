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
                    Text = transaction.Amount + " x " + transaction.Name,
                }, 0, row);
                grid.Children.Add(new Label
                {
                    Text = IntToGp(transaction.BroughtAt)
                }, 1, row);
                grid.Children.Add(new Label
                {
                    Text = IntToGp(transaction.SoldAt)
                }, 2, row);
                grid.Children.Add(new Label
                {
                    Text = IntToGp(transaction.Profit),
                    TextColor = transaction.Profit > 0 ? Color.Green : Color.Red

                }, 3, row);
                row++;

            }

            string IntToGp(int number)
            {
                bool positive;
                if (number < 0)
                {
                    positive = false;
                    number = number * -1;
                }
                else
                {
                    positive = true;
                }

                if (number >= 10000000)
                {
                    if (positive)
                    {
                        return (number / 1000000).ToString() + "M";
                    }
                    return ((number * -1) / 1000000).ToString() + "M";
                }
                if (number >= 100000)
                {
                    if (positive)
                    {
                        return (number / 1000).ToString() + "K";
                    }
                    return ((number * -1)/ 1000).ToString() + "K";
                }
                if (positive)
                {
                    return number.ToString();
                }
                return (number * -1).ToString();
            }
        }
    }
}
