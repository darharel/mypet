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
	public partial class MasterDetail : MasterDetailPage
	{
		public MasterDetail ()
		{
			InitializeComponent ();
            masterpage.Listview.ItemSelected += OnitemSelected;

        }

        public void OnitemSelected (object sender, SelectedItemChangedEventArgs e)
        {

            var item = e.SelectedItem as MasterMenuItem;
            if(item !=null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterpage.Listview.SelectedItem = null;
                IsPresented = false;
            }

        }
    }
}