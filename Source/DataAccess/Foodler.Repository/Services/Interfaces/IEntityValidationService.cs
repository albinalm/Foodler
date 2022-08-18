using Foodler.Repository.Entities.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodler.Repository.Services.Interfaces
{
    public interface IEntityValidationService
    {
        IEnumerable<ValidationResult> ValidateEntities(IEnumerable<EntityBase> entities, bool silent = false);
    }
}
