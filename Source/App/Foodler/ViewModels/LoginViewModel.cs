using Foodler.IO;
using Foodler.Networking;
using Foodler.Views;
using Xamarin.Forms;

namespace Foodler.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Private Props
        private bool authenticationFaileLabelVisible;
        private Color apiKeyTextBoxTextColor;
        private string apiKeyTextBoxTextValue;
        private string authenticationFailedLabelTextValue;
        private int authenticationFailedCount = 1;
        #endregion

        public Command AuthenticateCommand { get; }
        public bool AuthenticationFailedLabelVisible { get => authenticationFaileLabelVisible; set => SetProperty(ref authenticationFaileLabelVisible, value); }
        public Color ApiKeyTextBoxTextColor { get => apiKeyTextBoxTextColor; set => SetProperty(ref apiKeyTextBoxTextColor, value); }
        public string ApiKeyTextBoxTextValue { get => apiKeyTextBoxTextValue; set => SetProperty(ref apiKeyTextBoxTextValue, value); }
        public string AuthenticationFailedLabelTextValue { get => authenticationFailedLabelTextValue; set => SetProperty(ref authenticationFailedLabelTextValue, value); }

        public LoginViewModel()
        {
            AuthenticateCommand = new Command(Authentication);
            AuthenticationFailedLabelTextValue = "Authentication failed";
        }

        private async void Authentication(object obj)
        {
            var manager = new RecipeAPIManager();
        
            var authenticationSuccessful = await manager.Authenticate(ApiKeyTextBoxTextValue);
            if(authenticationSuccessful)
            {
                DeviceManager.SetAPIkey(ApiKeyTextBoxTextValue);
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            }
            else
            {
                if (AuthenticationFailedLabelVisible)
                {
                    authenticationFailedCount++;
                    AuthenticationFailedLabelTextValue = $"Authentication failed [{authenticationFailedCount}]";
                }
                AuthenticationFailedLabelVisible = true;
                ApiKeyTextBoxTextValue = "";
                
            }
        }
    }
}
