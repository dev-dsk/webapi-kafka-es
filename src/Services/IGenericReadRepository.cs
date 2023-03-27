using System.Linq.Expressions;

namespace Permissions.API.Services
{
    public interface IGenericReadRepository<T> where T : class
    {
        Task<IEnumerable<T>> All();
        Task<T> GetById(int id);
        //Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
    }
}
