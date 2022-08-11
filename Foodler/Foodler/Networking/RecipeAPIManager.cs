using Foodler.IO;
using Foodler.Models.Recipes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Foodler.Networking
{
    public class RecipeAPIManager
    {
        public async Task<List<Recipe>> GetRandomRecipesAsync(int amount, int servings)
        {
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync($"https://api.spoonacular.com/recipes/random?number={50}&tags=dinner&apiKey={await DeviceManager.GetAPIKey()}");
                var result = JsonConvert.DeserializeObject<RecipeHolder>(json);
                var recipes = result.Recipes.Where(x => x.Servings == servings).Take(7);

                return recipes.ToList();
            }
        }
        public async Task<bool> Authenticate(string apiKey)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var json = await httpClient.GetStringAsync($"https://api.spoonacular.com/recipes/random?apiKey={apiKey}");
                }
                return true;
            }
            catch (HttpRequestException httpException)
            {
                if (httpException.Message.Contains("401"))
                    return false;
                else
                    throw;
            }
            catch(Exception)
            {
                throw;
            }
        }

      
    }
}
