using PetitBear.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetitBear.Views.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterPage : ContentPage
	{
        public ListView Listview { get { return listview; } }
        public List<MasterMenuItem> items;

		public MasterPage ()
		{
			InitializeComponent ();
            SetItems();
		}

        private void SetItems()
        {
            listview.ItemsSource = new List<MasterMenuItem>
            {
                new MasterMenuItem("My Profile", "dog.png", Color.White, typeof(ProfileUserPage)),
                new MasterMenuItem("Search", "search.png", Color.White, typeof(SearchPage)),
                new MasterMenuItem("News", "news.png", Color.White, typeof(NewsPage)),
                new MasterMenuItem("Settings", "settings.png", Color.White, typeof(SettingsPage))
            };
        }
    }
}