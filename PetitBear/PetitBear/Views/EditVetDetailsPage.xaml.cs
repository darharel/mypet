using PetitBear.Models;
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
    public partial class EditVetDetailsPage : ContentPage
    {
        public event EventHandler<VetDetailModel> VetUpdated;     

        public EditVetDetailsPage(VetDetailModel vet)
        {
            InitializeComponent();
            
            Button_Save.Clicked += Button_Save_Clicked;

            TableForm.BindingContext = vet;
        }

        async void Button_Save_Clicked(object sender, System.EventArgs e)
        {
            var vet = TableForm.BindingContext as VetDetailModel;

            await App.MyVetController.SaveMyVet(vet);

            VetUpdated?.Invoke(this, vet);

            await Navigation.PopAsync();
        }


    }
}