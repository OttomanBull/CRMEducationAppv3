using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IRepository<T> where T : class
    {
        Task<T> InsertAsync(T item);

        Task<T> UpdateAsync(T item);

        Task DeleteByIdAsync(int id);

        IQueryable<T> Filter(Expression<Func<T, bool>> expression);

        Task<List<T>> GetAllItemsAsync();

        Task<List<T>> GetItemsAsync(Expression<Func<T, bool>> expression);

        Task<T> GetItemAsync(Expression<Func<T, bool>> expression);

        IQueryable<T> GetQuery();

        Task SaveChangesAsync();
    }
}
