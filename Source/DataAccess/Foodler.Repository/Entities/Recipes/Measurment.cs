using Foodler.Repository.Entities.Bases;
using Foodler.Repository.Entities.Recipes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodler.Repository.Entities.Recipes
{
    public class Measurment : EntityBase, IMeasurment
    {
        public string ShortName { get; set; }

        public IMeasurment SetName(string name)
        {
            this.Name = name;
            return this;
        }

        public IMeasurment SetShortName(string shortName)
        {
            this.ShortName = shortName;
            return this;
        }
    }
}
