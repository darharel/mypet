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
	public partial class EditTreatmentPage : ContentPage
	{
        public event EventHandler<TreatmentModel> TreatmentUpdated;
        public event EventHandler<TreatmentModel> TreatmentAdded;

        public EditTreatmentPage (TreatmentModel treat)
		{
			InitializeComponent ();
            TableForm.BindingContext = treat;
            Button_Save.Clicked += Button_Save_Clicked;

        }

        private async void Button_Save_Clicked(object sender, EventArgs e)
        {
            TreatmentModel treatment = TableForm.BindingContext as TreatmentModel;

            await App.TreatmentsController.SaveTreatment(treatment);

            TreatmentUpdated?.Invoke(this, treatment);

            await Navigation.PopAsync();
        }


    }
}