using Newtonsoft.Json;
using PetitBear.DB;
using PetitBear.Models;
using PetitBear.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetitBear.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyPetsPage : ContentPage
    {
        private ObservableCollection<PetDetailsModel> _myPets;
        private bool _isDataLoaded;

        public MyPetsPage()
        {
            InitializeComponent();
         }
        
        protected override async void OnAppearing()
        {
            if (_isDataLoaded)
                return;
            _isDataLoaded = true;

            await LoadData();

            base.OnAppearing();
        }

        private async Task LoadData()
        {
            Activityspinner.IsVisible = true;

            // 1) Get The items from the DB using the controller
            var pets = await App.MyPetsController.GetMyPets();

            // 2) checks if the items aren't null
            if (pets.Count() == 0)
                return;

            // 3) saves the items in local parameters
            _myPets = new ObservableCollection<PetDetailsModel>(pets);

            //4) sets the items of the page to their Binding Context
            PetsListView.ItemsSource = _myPets;

            Activityspinner.IsVisible = false;


            //5) Define the Event Functions
            PetsListView.ItemSelected += Pets_ItemSelected;
            addPetTollBarITem.Clicked += AddPet_Clicked;


            BackgroundColor = Constants.BackgroundColor;

        }
        
        async void AddPet_Clicked(object sender, System.EventArgs e)
        {
            var page = new EditPetDetailsPage();

            // this page->MyPetsPage can contain the function of the event from EditPetDetailsPage.
            page.PetAdded += (source, pet) =>
            {
                _myPets.Add(pet);
            };

            await Navigation.PushAsync(page);
        }
        
        async void Pets_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (PetsListView.SelectedItem == null)
                return;

            // Sets the data in a variable
            var selectedPet = e.SelectedItem as PetDetailsModel;

            //Clean the listview checked item
            PetsListView.SelectedItem = null;

            //create new page with the item selected
            var page = new EditPetDetailsPage(selectedPet);

            //set the event for the Edit Page Property PetUpdated to work here when activated at EditPetPage
            page.PetUpdated += (source, pet) =>
           {
                //Set the New Details recieved from user
                selectedPet.ID = pet.ID;
               selectedPet.Name = pet.Name;

           };
            //return to MyPetsPage
            await Navigation.PushAsync(page);
        }
                
        async void OnDeletePet(object sender, System.EventArgs e)
        {
            //get the object detail
            var pet = (sender as MenuItem).CommandParameter as PetDetailsModel;

            if (await DisplayAlert("Warning", $"Are you sure you want to delete {pet.Name}?", "Yes", "No"))
            {
                //if user press OK this will remove the pet from the db and the listview                
                await App.MyPetsController.DeletePet(pet);                
                _myPets.Remove(pet);
            }
        }
        
    }
}