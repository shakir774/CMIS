using System.Collections.Generic;
using Domain.Repository.Interfaces;

namespace Domain.Services.Interfaces
{
    public interface IService<T, E, R> where T : class
    {
         bool Add(T dto);
         IEnumerable<T> GetAll();
    }
}