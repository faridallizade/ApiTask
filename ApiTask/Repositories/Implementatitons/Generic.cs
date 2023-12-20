using ApiTask.DAL;
using ApiTask.Entitites;
using ApiTask.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiTask.Repositories.Implementatitons
{
    public class Generic<T> : IGeneric<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private DbSet<T> _table;

        public Generic(AppDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, 
            Expression<Func<T, object>>? orderByExpression = null, bool isDescending = false, params string[] includes)
        {
            IQueryable<T> query = _table;
            if (expression is not null)
            {
                query = query.Where(expression);
            }
            if(orderByExpression != null)
            {
                query = isDescending? query.OrderByDescending(orderByExpression)
                    :query.OrderBy(orderByExpression);
            }
            if (includes is not null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            return query;   
        }
        public async Task<T> GetByIdAsync(int Id)
        {
            return await _table.AsNoTracking().FirstOrDefaultAsync(c => c.Id == Id);
        }
        public async Task<T> Create(T entity)
        {
            await _table.AddAsync(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
        }

        public void Update(T entity)
        {
            _table.Update(entity);
        }


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


    }
}
