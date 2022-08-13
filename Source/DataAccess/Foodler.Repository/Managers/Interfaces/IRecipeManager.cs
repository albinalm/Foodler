using Foodler.Repository.Entities;

namespace Foodler.Repository.Managers.Interfaces
{
    public interface IRecipeManager
    {
        Entities.Recipe Create();
        void SetRecipeName(ref Recipe recipe, string name);
    }
}
