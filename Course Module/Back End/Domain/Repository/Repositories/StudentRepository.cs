using System.Runtime.InteropServices.ComTypes;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;
using Domain.Repository.Interfaces;
using Core.Entities;
using Core.DbContexts;

namespace Domain.Repository.Repositories {
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository (CourseDbContext context) : base(context)
        {
        }
        public bool Remove(int Id)
        {
            try
            {
                var entity = Entity.FirstOrDefault(e => e.Id == Id);
                if (entity != null)
                {
                    Entity.Remove(entity);
                    Save();
                    return true;
                }
                else return false;
               
            }
            catch (System.Exception e)
            {

                throw e;
            }
        }
        public Student Get(int Id) 
        {
             return Entity.FirstOrDefault(e => e.Id == Id);
        }
        public bool Update(int Id, Student entity)
        {
           try
            {
                if (entity.Id == Id)
                {
                    Entity.Update(entity);
                    Save();
                    return true;
                }
                else return false;
               
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }
}