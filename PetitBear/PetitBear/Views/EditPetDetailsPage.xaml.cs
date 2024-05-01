using PetitBear.DB;
using PetitBear.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetitBear.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditPetDetailsPage : ContentPage
    {
        public event EventHandler<PetDetailsModel> PetAdded;
        public event EventHandler<PetDetailsModel> PetUpdated;
        private int tempID;
        //when the user wants to add a new pet
        public EditPetDetailsPage()
        {
            InitializeComponent();

            Button_Save.Clicked += Button_Save_Clicked;
        }

        //when the user wants to edit his details
        public EditPetDetailsPage(PetDetailsModel pet)
        {
            InitializeComponent();

            if (pet == null)
            {
                DisplayAlert("Error", "object (pet) is null", "OK");
                return;
            }
            tempID = pet.ID;
            TableForm.BindingContext = pet;
            Button_Save.Clicked += Button_Save_Clicked;

        }

        private async void Button_Save_Clicked(object sender, System.EventArgs e)
        {
            //var pet = TableForm.BindingContext as PetDetailsModel;
            PetDetailsModel pet = new PetDetailsModel()
            {
                Name = entry_Name.Text,
                ID = tempID,
                Age = int.Parse(entry_Age.Text),
                Race = entry_Race.Text,
                Weight = int.Parse(entry_weight.Text),
                Color = Color.Text,
                Gender = Gender.SelectedItem.ToString(),
                Size = Size.SelectedItem.ToString()
            };

            tempID = 0;
            if (pet == null)
            {
                await DisplayAlert("Error", "Bindingcontext is NULL", "OK");
                return;
            }
            if (String.IsNullOrWhiteSpace(pet.Name))
            {
                await DisplayAlert("Error", "Please enter the name.", "OK");
                return;
            }

            await App.MyPetsController.SavePet(pet);

            if (pet.isNewPet)
            {
                pet.isNewPet = false;
                PetAdded?.Invoke(this, pet);
            }
            else
                PetUpdated?.Invoke(this, pet);

            await Navigation.PopAsync();
        }


    }
}