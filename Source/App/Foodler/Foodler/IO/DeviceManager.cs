using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Foodler.IO
{
    public static class DeviceManager
    {
        public static async void SetAPIkey(string APIKey)
        {
            await SecureStorage.SetAsync("Foodler_APIKey", APIKey);
        }
        public static async Task<string> GetAPIKey()
        {
            var token = await SecureStorage.GetAsync("Foodler_APIKey");
            return token;
        }
    }
}
