using Core.Entitites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class BaseRepository<T, TContext> : IRepository<T> where T : BaseEntity
        where TContext : System.Data.Entity.DbContext
    {
        public TContext Context { get; private set; }

        public BaseRepository(TContext context)
        {
            Context = context;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var set = Context.Set<T>();

            var item = await set.FirstOrDefaultAsync(t => t.Id == id);

            await DeleteItemAsync(item);
        }

        public async Task DeleteItemAsync(T item)
        {
            await Task.Run(() =>
            {
                var set = Context.Set<T>();

                set.Remove(item);
            });
        }

        public IQueryable<T> Filter(Expression<Func<T, bool>> expression)
        {
            var set = Context.Set<T>();

            return set.Where(expression);
        }

        public async Task<List<T>> GetAllItemsAsync()
        {
            var set = Context.Set<T>();

            return await set.ToListAsync();
        }

        public async Task<T> GetItemAsync(Expression<Func<T, bool>> expression)
        {
            return await Filter(expression).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetItemsAsync(Expression<Func<T, bool>> expression)
        {
            return await Filter(expression).ToListAsync();
        }

        public async Task<int> GetCount(Expression<Func<T, bool>> expression)
        {
            return await Filter(expression).CountAsync();
        }
        public async Task<T> InsertAsync(T item)
        {
            var set = Context.Set<T>();
            var entityEntry = set.Add(item);
            await Context.SaveChangesAsync();
            return entityEntry;
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T item)
        {
            var set = Context.Set<T>();
            set.Attach(item);
            Context.Entry(item).State = System.Data.Entity.EntityState.Modified;
            await Context.SaveChangesAsync();
            return item;
        }

        public IQueryable<T> GetQuery()
        {
            return Context.Set<T>().AsQueryable();
        }
    }
}
