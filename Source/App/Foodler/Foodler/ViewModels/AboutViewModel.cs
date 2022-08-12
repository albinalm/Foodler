using Foodler.Models.Recipes;
using Foodler.Models.Schedules;
using Foodler.Networking;
using Foodler.Views;
using System;
using System.Linq;
using Xamarin.Forms;

namespace Foodler.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {


        public Command GetRecipesCommand { get; }
        public AboutViewModel()
        {
            Title = "About";

            GetRecipesCommand = new Command(OnGetRecipesClicked);
        }

        private void OnGetRecipesClicked(object obj)
        {
            //// Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            ////   await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            //var manager = new RecipeAPIManager();
            //var recipes = await manager.GetRandomRecipesAsync(1, 2);

            ////for (int i = 0; i < recipes.Count; i++)
            ////    recipes[i].Weekday = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), i.ToString());

            //Models.WeeklyPreview.WeeklyPreviewDataHolder.Schedule = new WeeklySchedule
            //{
            //    LocalStartDate = DateTime.Now,
            //    LocalEndDate = DateTime.Now.AddDays(7),
            //    Recipes = recipes
            //};

            //await Shell.Current.GoToAsync($"//{nameof(WeekPreview)}");

            var ingredient = new Ingredient
            {
                Name = "Tomato"
            };
            var recipe = new Recipe
            {
                Name = "Tomato soup"
            };
            var recipeIngredient = new RecipeIngredient
            {
                Ingredient = ingredient,
                Recipe = recipe
            };
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}