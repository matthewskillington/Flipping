using Flipping.Models;
using Flipping.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Flipping.ViewModels
{
    public class AddTransactionModalViewModel : BindableObject
    {
        public ITransactionService transactionService;
        public INavigationService navigationService;
        public IGrandExchangeService grandExchangeService;

        public AddTransactionModalViewModel(ITransactionService _transactionService, 
                                            INavigationService _navigationService,
                                            IGrandExchangeService _grandExchangeService)
        {
            transactionService = _transactionService;
            navigationService = _navigationService;
            grandExchangeService = _grandExchangeService;
        }

        public Transaction selectedTransction;
        private string errormessage;
        public string ErrorMessage {
            get => errormessage;
            set
            {
                errormessage = value;
                OnPropertyChanged();
            }
        }
        public Guid id;
        public Guid Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        public string name;
        public string Name {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        private int amount;
        public int Amount {
            get => amount;
            set
            {
                amount = value;
                OnPropertyChanged();
            }
        }
        public int broughtAt;
        public int BroughtAt
        {
            get => broughtAt;
            set
            {
                broughtAt = value;
                OnPropertyChanged();
            }
        }
        public int soldAt;
        public int SoldAt
        {
            get => soldAt;
            set
            {
                soldAt = value;
                OnPropertyChanged();
            }
        }

        public RunescapeItem suggestedItem;
        public RunescapeItem SuggestedItem
        {
            get => suggestedItem;
            set
            {
                suggestedItem = value;
                OnPropertyChanged();
            }
        }

        public bool displaySuggestions;
        public bool DisplaySuggestions
        {
            get => displaySuggestions;
            set
            {
                displaySuggestions = value;
                OnPropertyChanged();
            }
        }


        public ICommand SubmitCommand => new Command(ValidateTransaction);
        public ICommand CancelCommand => new Command(CancelAdd);

        private void CancelAdd()
        {
            navigationService.RemoveModal();
        }

        private void ValidateTransaction()
        {
            if (Name == null)
            {
                ErrorMessage = "You cannot leave the name field blank";
                return;
            }
            if (Amount <= 0)
            {
                ErrorMessage = "Amount must be greater than 0";
                return;
            }
            if (BroughtAt <= 0)
            {
                ErrorMessage = "Price Brought for must be greater than 0";
                return;
            }
            if (Amount > 2147000000 || BroughtAt > 2147000000){
                ErrorMessage = "You cannot hold or sell for more than 2147M";
                return;
            }
            else
            {
                ConstructTransaction();
            }
        }

        private void ConstructTransaction()
        {
            var newTransaction = new Transaction(Name, Amount, BroughtAt);

            if (SoldAt > 0)
            {
                newTransaction.SoldAt = SoldAt;
            }
            selectedTransction = newTransaction;

            transactionService.SaveToDeviceNew(newTransaction);
            navigationService.RemoveModal();
            navigationService.ReloadMainPage();
        }

        public async Task HandleSearchNameChange()
        {
            if(Name.Length >= 1)
            {
                string response = await grandExchangeService.GetAsync("http://services.runescape.com/m=itemdb_oldschool/api/catalogue/items.json?category=1&alpha=a&page=1");
                object deserializedItems = JsonConvert.DeserializeObject(response.items); 
                SuggestedItem = new RunescapeItem("", "", 5405, "Fish", "", 140);
                DisplaySuggestions = true;
            }
            else
            {
                if (DisplaySuggestions)
                {
                    DisplaySuggestions = !DisplaySuggestions;
                }
            }
            
        }
    }
}
