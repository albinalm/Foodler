using Foodler.Repository.Database.Context;
using Foodler.Repository.Entities.Recipes;
using Foodler.Repository.Repositories.Bases;

namespace Foodler.Repository.Repositories
{
    public class MeasurmentRepository : RepositoryBase<Measurment>
    {
        private readonly FoodlerDatabaseContext context;

        public MeasurmentRepository(FoodlerDatabaseContext context) : base(context)
        {
            this.context = context;
        }

        public override IQueryable<Measurment> Query()
        {
            return context.Measurments;
        }
    }
}
