using PetitBear.API;
using PetitBear.Models;
using PetitBear.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetitBear.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        private SearchController _searchController = new SearchController();
        private string _currentProffesion = "Pets";

        public SearchPage()
        {
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            BackgroundColor = Constants.BackgroundColor;
            
            //event for handling search bar changes
            searchBar.TextChanged += (s, e) => FilterItem(searchBar.Text);
            searchBar.SearchButtonPressed += (s, e) => FilterItem(searchBar.Text);

            //filters events to set the requested profession of the search.
            //pets.Clicked += (s, e) => ProfessionFilter_Clicked(pets.Text);
            vets.Clicked += (s, e) => ProfessionFilter_Clicked(vets.Text);
            pensions.Clicked += (s, e) => ProfessionFilter_Clicked(pensions.Text);
            trainers.Clicked += (s, e) => ProfessionFilter_Clicked(trainers.Text);
            foodStores.Clicked += (s, e) => ProfessionFilter_Clicked(foodStores.Text);

            //event when selecting an item from the list
            listView.ItemSelected += ListView_ItemSelected;
        }


        private async void ProfessionFilter_Clicked(string profession)
        {
            listView.BeginRefresh();

            _currentProffesion = profession;
            var _itemsList = await _searchController.GetItems(); // gpsLocation.toString();
            if (!Equals(_itemsList, null))
                listView.ItemsSource = _itemsList.Where(c => c.Profession == _currentProffesion);

            listView.EndRefresh();

        }


        private async void FilterItem(string filter)
        {
            listView.BeginRefresh();
            //var _itemsList = await _searchController.GetItems(new SearchModel { Proffesion = _currentProffesion, Area = "Tel Aviv" }); // gpsLocation.toString();

            var _itemsList = await _searchController.GetItems(); // gpsLocation.toString();

            if (!Equals(_itemsList, null))
            {
                if (string.IsNullOrWhiteSpace(filter.ToLower()))
                    listView.ItemsSource = _itemsList;
                else
                {
                    var temp = _itemsList.Where(c => c.Profession == _currentProffesion);
                    listView.ItemsSource = temp.Where(c => c.Name.ToLower().Contains(filter));
                }
            }
            listView.EndRefresh();
        }


        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            if (_currentProffesion != "Pets")
            {
                if (Navigation.NavigationStack.Last().GetType() != typeof(ProfileSupplierPage))
                {
                    var temp = e.SelectedItem as SupplierModel;
                    await Navigation.PushAsync(new ProfileSupplierPage(temp));
                }
            }
            else
            {
                if (Navigation.NavigationStack.Last().GetType() != typeof(ProfilePetPage))
                    await Navigation.PushAsync(new ProfilePetPage(e.SelectedItem as PetDetailsModel));
            }
            listView.SelectedItem = null;
        }




    }
}