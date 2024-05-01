using PetitBear.Models;
using PetitBear.Services;
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
	public partial class ProfilePetPage : ContentPage
	{
        

        public ProfilePetPage()
        {
            InitializeComponent();
            InitializeControl();
            mainGrid.BindingContext = App.MyPetsController.GetMyPets().Result[0];
            ToolBarItemSearch.Clicked += ToolBarItemSearch_Clicked;
        }

        private void ToolBarItemSearch_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SearchPage());

        }

        public ProfilePetPage(PetDetailsModel pet)
        {
            InitializeComponent();
            InitializeControl();
            mainGrid.BindingContext = pet;

        }

        private void InitializeControl()
        {
            var vetImgTap = new TapGestureRecognizer();
            vetImgTap.Tapped += (object sender, EventArgs e) => {
                Navigation.PushAsync(new MyVetPage());

            };
            btnVet.GestureRecognizers.Add(vetImgTap);

            imgCurved.Source = ImageSource.FromResource("PetitBear.Images.CurvedMask.png");


        }



    }
}