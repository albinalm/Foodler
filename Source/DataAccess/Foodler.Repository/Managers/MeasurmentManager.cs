using Foodler.Repository.Entities.Recipes;
using Foodler.Repository.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodler.Repository.Managers
{
    public class MeasurmentManager : IEntityManager<Measurment>
    {
        public Measurment Create(string name)
        {
            return new Measurment
            {
                Name = name
            };
        }
    }
}
