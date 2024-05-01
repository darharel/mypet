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
    public partial class MyVetPage : ContentPage
    {
        private ObservableCollection<TreatmentModel> _myTreatments;
        private bool _isDataLoaded;

        public MyVetPage()
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
            _myTreatments = new ObservableCollection<TreatmentModel>(await App.TreatmentsController.GetTreatmentsList());

            // 2) sets the items of the page to their Binding Context
            vetDetailStack.BindingContext = await App.MyVetController.GetMyVet();
            TreatList.ItemsSource = _myTreatments;

            Activityspinner.IsVisible = false;

            //3) Define the Event Functions
            EditTollbarItem.Clicked += EditVetItem_Clicked;
            TreatList.ItemSelected += TreatList_ItemSelected;

            BackgroundColor = Constants.BackgroundColor;

        }

        private void EditVetItem_Clicked(object sender, EventArgs e)
        {
            EditVetDetailsPage page = new EditVetDetailsPage(vetDetailStack.BindingContext as VetDetailModel);

            page.VetUpdated += (source, vet) =>
             {
                 vetDetailStack.BindingContext = vet;
             };

            if (Navigation.NavigationStack.Last().GetType() != typeof(ProfilePetPage))
                Navigation.PushAsync(page);
        }

        private async void TreatList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Sets the data in a variable
            var selectedTreatment = e.SelectedItem as TreatmentModel ;

            //Clean the listview checked item
            TreatList.SelectedItem = null;

            //create new page with the item selected
            var page = new EditTreatmentPage(selectedTreatment);

            //set the event for the Edit Page Property PetUpdated to work here when activated at EditPetPage
            page.TreatmentUpdated += (source, treatment) =>
            {
                //Set the New Details recieved from user
                selectedTreatment.ID = treatment.ID;
                selectedTreatment.Name = treatment.Name;
            };

            if (Navigation.NavigationStack.Last().GetType() != typeof(MyVetPage))
                await Navigation.PushAsync(page);
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var treatment = (sender as MenuItem).CommandParameter as TreatmentModel;
            if (await DisplayAlert("Warning", $"Are you sure you want to delete {treatment.Name}?", "Yes", "No"))
            {
                _myTreatments.Remove(treatment);

                await App.TreatmentsController.DeleteTreatment(treatment);
            }
        }



    }
}