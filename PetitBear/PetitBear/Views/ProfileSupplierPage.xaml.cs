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
    public partial class ProfileSupplierPage : ContentPage
    {
        public ProfileSupplierPage(SupplierModel item)
        {
            InitializeComponent();
            InitializeControl();
            MainGrid.BindingContext = item;
            commentsListView.ItemsSource = item.CommmentsList;
        }

        private void InitializeControl()
        {          
            favoriteBtn.Clicked += FavoriteBtn_Clicked;
            moreBtn.Clicked += MoreBtn_Clicked;
            callBtn.Clicked += CallBtn_Clicked;
        }

        private void CallBtn_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Start Follow", "now will appear in news page, and see his future posts", "OK");

        }

        private void FavoriteBtn_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Setting as Favorite", "now will appear as Favorite and on my profile page", "OK");
        }

        private void MoreBtn_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Redircting To FB Page", "Now you should be moved to His FB page,or Twitter, or w/e he chooses.", "OK");
            string supplierName = "darharel";
            Device.OpenUri(new Uri("https://www.facebook.com/" + supplierName) );
        }

        private void FollowBtn_Clicked(object sender, EventArgs e)
        {
            // set accept for getting posts from this user
        }




    }

}
