using ApiTask.DAL;
using ApiTask.Entitites;
using ApiTask.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiTask.Repositories.Implementatitons
{
    public class BrandRepo : IBrandRepo
    {
        private readonly AppDbContext _context;
        public BrandRepo(AppDbContext context)
        {
            _context = context;
        }

        

        public async Task<IQueryable<Brand>> GetAllAsync(Expression<Func<Brand, bool>>? expression = null, params string[] includes)
        {
            IQueryable<Brand> query = _context.Brand;
            if (includes is not null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            if (expression is not null)
            {
                query = query.Where(expression);
            }
            return query;
        }

        public async Task<Brand> GetByIdAsync(int id)
        {
            return await _context.Brand.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Create(Brand brand)
        {
            await _context.Brand.AddAsync(brand);
        }

        public void Delete(Brand brand)
        {
            _context.Brand.Remove(brand);
        }

        public void Update(Brand brand)
        {
            _context.Brand.Update(brand);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
