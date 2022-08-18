using Foodler.Repository.Entities.Bases;
using Foodler.Repository.Entities.Recipes;
using Foodler.Repository.Services.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodler.Repository.Services
{
    public class EntityValidationService : IEntityValidationService
    {
        public IEnumerable<ValidationResult> ValidateEntities(IEnumerable<EntityBase> entities, bool silent = false)
        {
            var failedValidations = new List<ValidationResult>();
            foreach (var e in entities)
            {
                var vc = new ValidationContext(e, null, null);
                var success = Validator.TryValidateObject(e, vc, failedValidations, validateAllProperties: true);
                if (!silent && !success)
                    throw new ValidationException($"Validation failed for entity: {e.GetType().Name}\n{failedValidations.First().ErrorMessage}");
            }
            return failedValidations;
        }
    }
}
