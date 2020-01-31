using System.Collections.Generic;

namespace Domain.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
         bool Add(T entity);
         IEnumerable<T> GetAll();
         void Save();
    }
}