using Foodler.Repository.Entities.Recipes;
using Foodler.Repository.Managers.Interfaces;

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
