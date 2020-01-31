using System.Collections.Generic;
using System.Linq;
using Core.DbContexts;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly CourseDbContext context;
        protected DbSet<T> Entity;
        public Repository(CourseDbContext context)
        {
            this.context = context;
            Entity = this.context.Set<T>();
        }
        public bool Add(T entity)
        {
            try
            {
                Entity.Add(entity);
                Save();
                return true;
            }
            catch(System.Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return Entity.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}