using ApiTask.Entitites;
using System.Linq.Expressions;

namespace ApiTask.Repositories.Interfaces
{
    public class ICarRepo
    {
        public interface ICarRepository:IGeneric<Car>
        {
        }
    }
}
