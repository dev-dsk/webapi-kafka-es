namespace Permissions.API.Services
{
    public interface IGenericWriteRepository<T> where T : class
    {
        Task<bool> Add(T entity);
        Task<bool> Delete(Guid id);
        Task<bool> Upsert(T entity);
    }
}
