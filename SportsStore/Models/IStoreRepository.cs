namespace SportsStore.Models
{
    public interface IStoreRepository
    {
        IQueryable<Product> products { get; }
    }
}
