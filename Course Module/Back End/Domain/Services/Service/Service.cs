using System.Collections.Generic;
using AutoMapper;
using Domain.Repository.Interfaces;
using Domain.Repository.Repositories;
using Domain.Services.Interfaces;

namespace Domain.Services.Service
{
    public class Service<T, E, R> : IService<T, E, R> where T : class where E : class where R : IRepository<E>
    {
        protected readonly R repository;
        protected readonly IMapper mapper;
        public Service(R repository, IMapper mapper)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
        public bool Add(T dto)
        {
            var entity = mapper.Map<T, E>(dto);
            return repository.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            var entities = repository.GetAll();
            return mapper.Map<IEnumerable<E>, IEnumerable<T>>(entities);
        }
    }
}