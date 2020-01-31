using System.Runtime.InteropServices.ComTypes;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;
using Domain.Repository.Interfaces;
using Core.Entities;
using Core.DbContexts;

namespace Domain.Repository.Repositories {
    public class SemesterRepository : Repository<Semester>, ISemesterRepository {
        public SemesterRepository (CourseDbContext context) : base(context) 
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
        public Semester Get(int Id) 
        {
             return Entity.FirstOrDefault(e => e.Id == Id);
        }
        public bool Update(int Id, Semester entity)
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

        public IEnumerable<Student> GetStudents(int semesterId)
        {
            // var entity = Entity.FirstOrDefault(i => i.Id == semesterId);
            // var student = context.SemesterStudents.FirstOrDefault(i => i.SemesterId == entity.Id);
            // var students = context.Students.Where(i => i.Id == student.Id)
            return null;
        }

        public IEnumerable<Course> GetCourses(int semesterId)
        {
            throw new NotImplementedException();
        }
    }
}