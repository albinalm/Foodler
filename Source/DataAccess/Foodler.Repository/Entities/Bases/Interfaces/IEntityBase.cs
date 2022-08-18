using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodler.Repository.Entities.Bases.Interfaces
{
    public interface IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        protected virtual IEnumerable<ValidationResult> CustomValidation(ValidationContext validationContext) => Enumerable.Empty<ValidationResult>();
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
}
