using PetitBear.Models;
using PetitBear.Views.Menu;
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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            BackgroundColor = Constants.BackgroundColor;
            Label_Username.TextColor = Constants.MainTextColor;
            Label_Password.TextColor = Constants.MainTextColor;
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;
            App.StartCheckIfInternet(Label_NoInternet, this);

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => Button_Signin_Clicked(s, e);
        }


        private async void Button_Signin_Clicked(object sender, EventArgs e)
        {
            if (Entry_Username.Text == null || Entry_Password.Text == null)
            {
                await DisplayAlert("Login", "Incorrect username or password", "OK");
                ActivitySpinner.IsVisible = false;
                return;
            }

            User user = new User(Entry_Username.Text, Entry_Password.Text);
            ActivitySpinner.IsVisible = true;

            //await DisplayAlert("Login", "Login Success", "OK");
            //var result = await App.RestService.Login(user); //When Launched API
            var result = new Token();
            //if (result.access_token != null)
            if (result != null) // *
            {
                ActivitySpinner.IsVisible = false;

                await App.UserController.SaveUser(user);
                await App.TokenController.SaveToken(result);
                if (Device.RuntimePlatform == Device.iOS)
                {
                    await Navigation.PushModalAsync(new MasterDetail());
                }
                else if (Device.RuntimePlatform == Device.Android)
                {
                    Application.Current.MainPage = new MasterDetail();
                }

             
            }            
        }



    }
}