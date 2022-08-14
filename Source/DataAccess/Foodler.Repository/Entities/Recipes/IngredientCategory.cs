using Foodler.Repository.Entities.Bases;
using Foodler.Repository.Entities.Recipes.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodler.Repository.Entities.Recipes
{
    public class IngredientCategory : EntityBase, IIngredientCategory
    {
        public void SetName(string name)
        {
            this.Name = name;
        }

        protected override IEnumerable<ValidationResult> CustomValidation(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
