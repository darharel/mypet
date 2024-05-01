using PetitBear.Models;
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
	public partial class ProfileUserPage : ContentPage
	{
        private ObservableCollection<PetDetailsModel> _myPets;
       

        public ProfileUserPage ()
		{
			InitializeComponent ();
            EditPetsToolBarItem.Clicked += EditPets_Clicked;
		}      

        protected override async void OnAppearing()
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

            BackgroundColor = Constants.BackgroundColor;

            base.OnAppearing();
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
            var page = new ProfilePetPage(selectedPet);


            await Navigation.PushAsync(page);
        }

        private void EditPets_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MyPetsPage());
        }
    }
}