using Foodler.IO;
using Foodler.Networking;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Foodler.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            
        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            var manager = new RecipeAPIManager();
            if(string.IsNullOrEmpty(await DeviceManager.GetAPIKey())) {
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
           
        }
    }
}