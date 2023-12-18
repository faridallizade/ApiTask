using ApiTask.Entitites;
using Microsoft.EntityFrameworkCore;

namespace ApiTask.DAL
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }
        public DbSet<Car> Car {  get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Colour> Color { get; set; }
    }
}
