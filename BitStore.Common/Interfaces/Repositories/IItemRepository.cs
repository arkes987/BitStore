namespace BitStore.Common.Interfaces.Repositories
{
    public interface IItemRepository
    {
        Task<Models.Item> GetItem(Guid id);
        Task SaveItem(Models.Item @object);
    }
}
