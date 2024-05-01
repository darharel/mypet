using PetitBear.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetitBear.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public ObservableCollection<SettingItemsModel> MenuItems;

        public SettingsPage()
        {
            InitializeComponent();
            
        }
        
        private void SwitchCell_OnChanged(object sender, ToggledEventArgs e)
        {

        }

        private void LogOut_Tapped(object sender, EventArgs e)
        {

        }
    }
}