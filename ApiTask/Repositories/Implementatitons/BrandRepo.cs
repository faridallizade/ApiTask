using ApiTask.DAL;
using ApiTask.Entitites;
using ApiTask.Repositories.Interfaces;
using System.Linq.Expressions;

namespace ApiTask.Repositories.Implementatitons
{
    public class BrandRepo : Generic<Brand>, IBrandRepo
    {
        public BrandRepo(AppDbContext context) : base(context)
        {
        }

      
    }
}
