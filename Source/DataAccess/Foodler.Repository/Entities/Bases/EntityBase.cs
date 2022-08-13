using Foodler.Repository.Entities.Recipes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodler.Repository.Entities.Bases
{
    public class EntityBase
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
