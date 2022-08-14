namespace Foodler.Repository.Managers.Interfaces
{
    public interface IEntityManager<TEntity> where TEntity : class
    {
        abstract TEntity Create(string name);
    }
}
