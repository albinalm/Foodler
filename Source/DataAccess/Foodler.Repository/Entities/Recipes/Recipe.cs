using Foodler.Repository.Entities.Security;
using Foodler.Repository.Entities.Bases;
using Foodler.Repository.Entities.Recipes.Interfaces;
using System.ComponentModel.DataAnnotations;
using Foodler.Repository.Entities.Security.Interfaces;

namespace Foodler.Repository.Entities.Recipes
{
    public class Recipe : EntityBase, IRecipe
    {
        public Recipe(string name) : base(name)
        {
        }

        public virtual IEnumerable<Ingredient> Ingredients { get; set; }
        public string Instructions { get; set; }
        public User Author { get; set; }

        public IRecipe SetInstructions(string instructions)
        {
            this.Instructions = instructions;
            return this;
        }

        public IRecipe SetAuthor(User author)
        {
            this.Author = author;
            return this;
        }

        public IRecipe SetIngredients(IEnumerable<Ingredient> ingredients)
        {
            this.Ingredients = ingredients;
            return this;
        }

        public IRecipe SetName(string name)
        {
            this.Name = name;
            return this;
        }
        #region Overloads
        public IRecipe SetAuthor(IUser author)
        {
            return SetAuthor((User)author);
        }

        #endregion
        protected override IEnumerable<ValidationResult> CustomValidation(ValidationContext validationContext)
        {
            if (Ingredients == null || !Ingredients.Any())
            {
                yield return new ValidationResult(
                    "The property 'Ingredients' cannot be null or empty",
                    new[] { nameof(Ingredients) });
            }
            if (string.IsNullOrWhiteSpace(Instructions))
            {
                yield return new ValidationResult(
                    "The property 'Instructions' cannot be null or contain only whitespaces",
                    new[] { nameof(Ingredients) });
            }
            if (Author == null)
            {
                yield return new ValidationResult(
                    "The property 'Author' cannot be null.",
                    new[] { nameof(Ingredients) });
            }
        }
    }
}
