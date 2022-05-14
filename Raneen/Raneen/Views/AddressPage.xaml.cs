using Raneen.Data;
using Raneen.Models;
using Raneen.Services;
using Raneen.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Raneen.Views
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddressPage : ContentPage
    {
        public AddressPage()
        {
            this.InitializeComponent();
            StateEntry.ItemsSource = AddressData.states;
            //BindingContext = new AddressPageViewModel();

        }

        private void showCity(object sender, System.EventArgs e)
        {
            City.IsVisible = true;
            string city = AddressData.states[StateEntry.SelectedIndex];
            switch (city)
            {
                case "Alexandria":
                    CityEntry.ItemsSource = AddressData.Alexandria;
                    break;
                case "Aswan":
                    CityEntry.ItemsSource = AddressData.Aswan;
                    break;
                case "Asyut":
                    CityEntry.ItemsSource = AddressData.Asyut;
                    break;
                case "Beheira":
                    CityEntry.ItemsSource = AddressData.Beheira;
                    break;
                case "Beni_Suef":
                    CityEntry.ItemsSource = AddressData.Beni_Suef;
                    break;
                case "Cairo":
                    CityEntry.ItemsSource = AddressData.Cairo;
                    break;
                case "Dakahlia":
                    CityEntry.ItemsSource = AddressData.Dakahlia;
                    break;
                case "Damietta":
                    CityEntry.ItemsSource = AddressData.Damietta;
                    break;
                case "Faiyum":
                    CityEntry.ItemsSource = AddressData.Faiyum;
                    break;
                case "Gharbia":
                    CityEntry.ItemsSource = AddressData.Gharbia;
                    break;
                case "Giza":
                    CityEntry.ItemsSource = AddressData.Giza;
                    break;
                case "Ismailia":
                    CityEntry.ItemsSource = AddressData.Ismailia;
                    break;
                case "Kafr_El_Sheikh":
                    CityEntry.ItemsSource = AddressData.Kafr_El_Sheikh;
                    break;
                case "Luxor":
                    CityEntry.ItemsSource = AddressData.Luxor;
                    break;
                case "Matruh":
                    CityEntry.ItemsSource = AddressData.Matruh;
                    break;
                case "Minya":
                    CityEntry.ItemsSource = AddressData.Minya;
                    break;
                case "Monufia":
                    CityEntry.ItemsSource = AddressData.Monufia;
                    break;
                case "New_Valley":
                    CityEntry.ItemsSource = AddressData.New_Valley;
                    break;
                case "North_Sinai":
                    CityEntry.ItemsSource = AddressData.North_Sinai;
                    break;
                case "Port_Said":
                    CityEntry.ItemsSource = AddressData.Port_Said;
                    break;
                case "Qalyubia":
                    CityEntry.ItemsSource = AddressData.Qalyubia;
                    break;
                case "Qena":
                    CityEntry.ItemsSource = AddressData.Qena;
                    break;
                case "Red_Sea":
                    CityEntry.ItemsSource = AddressData.Red_Sea;
                    break;
                case "Sharqia":
                    CityEntry.ItemsSource = AddressData.Sharqia;
                    break;
                case "Sohag":
                    CityEntry.ItemsSource = AddressData.Sohag;
                    break;
                case "South_Sinai":
                    CityEntry.ItemsSource = AddressData.South_Sinai;
                    break;
                case "Suez":
                    CityEntry.ItemsSource = AddressData.Suez;
                    break;
            }
        }

        private async void Save(object sender, System.EventArgs e)
        {
            if(FirstNameEntry.Text == null || SecondNameEntry.Text == null || PhoneEntry.Text == null || 
                StateEntry.SelectedIndex == -1 || CityEntry.SelectedIndex == -1 || StreetEntry.Text == null)
            {
                await DisplayAlert("Error", "Complete data", "OK");
            }
            else
            {
                string FirstName = FirstNameEntry.Text;
                string LastName = SecondNameEntry.Text;
                string Phone = PhoneEntry.Text;
                string State = StateEntry.SelectedItem.ToString();
                string City = CityEntry.SelectedItem.ToString();
                string Street = StreetEntry.Text;
                int UserId = 2;
                await Address.AddAddress(State, City, Street, UserId, FirstName, LastName);
            }

            //var r = await Address.getAddressByUserId(2);
            //List<AddressModel> list = r.ToList();

            //await DisplayAlert("Address", $"{list.Count}", "OK");
        }
    }
}