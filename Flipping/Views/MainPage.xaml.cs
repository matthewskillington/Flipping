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
                // Name Label
                Label label1 = new Label
                {
                    Text = transaction.Amount + " x " + transaction.Name,
                };

                // Brought at label
                Label label2 = new Label
                {
                    Text = IntToGp(transaction.BroughtAt)
                };

                // Sold at label
                Label label3 = new Label
                {
                    Text = IntToGp(transaction.SoldAt)
                };

                // Profit label
                Label label4 = new Label
                {
                    Text = IntToGp(transaction.Profit),
                    TextColor = transaction.Profit > 0 ? Color.Green : Color.Red
                };

                
                Label[] labels = new Label[]
                {
                    label1,
                    label2,
                    label3,
                    label4
                };
                // Add a gesture recogniser for each label to pass information to edit
                // Then add the labels to the grid
                var x = 0;
                foreach(Label label in labels)
                {
                    label.GestureRecognizers.Add(new TapGestureRecognizer()
                    {
                        Command = vm.EditCommand,
                        CommandParameter = transaction
                    });
                    grid.Children.Add(label, x, row);
                    x++;
                }

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
