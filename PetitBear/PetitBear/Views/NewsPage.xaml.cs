using PetitBear.Models;
using PetitBear.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetitBear.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsPage : ContentPage
    {
        NewsFeedService _newsService = new NewsFeedService();
        public ObservableCollection<string> Items { get; set; }

        public NewsPage()
        {
            InitializeComponent();



            newsListView.ItemTapped += NewsListView_ItemTapped;           
            newsListView.ItemsSource = _newsService.GetAllNewsFeed();

        }

        private async void NewsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            var temp = e.Item as NewsFeedModel;
           
            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            await Navigation.PushAsync(new ProfilePetPage(e.Item as PetDetailsModel));
            


            //Deselect Item
            ((ListView)sender).SelectedItem = null;
            
        }

      
    }
}
