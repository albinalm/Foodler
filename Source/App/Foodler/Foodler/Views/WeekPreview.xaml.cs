using Foodler.Models.Recipes;
using Foodler.Models.WeeklyPreview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Foodler.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeekPreview : ContentPage
    {
        public WeekPreview()
        {
            InitializeComponent();
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            foreach (var recipe in WeeklyPreviewDataHolder.Schedule.Recipes)
            {
                AddRecipeContentHolder(recipe, stackLayout);
            }
        }
        public void AddRecipeContentHolder(Recipe recipe, StackLayout parent)
        {
            var titleLabel = new Label
            {
                Text = recipe.Name
            };
            var instructionsLabel = new Label
            {
                Text = recipe.Name
            };
            parent.Children.Add(titleLabel);
            parent.Children.Add(instructionsLabel);
        }
    }
}