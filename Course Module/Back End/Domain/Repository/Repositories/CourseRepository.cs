using System.Runtime.InteropServices.ComTypes;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;
using Core.DbContexts;
using Domain.Repository.Interfaces;
using Core.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository.Repositories {
    public class CourseRepository :  Repository<Course>, ICourseRepository
    {    

        public CourseRepository (CourseDbContext context) : base(context)
        {
        }
        public bool Remove(string code)
        {
            try
            {
                var entity = Entity.FirstOrDefault(e => e.Code == code);
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

        public Course Get (string code) 
        {
            return Entity.FirstOrDefault(e => e.Code == code);
        }

        public bool Update(string code, Course entity)
        {
           try
            {
                if (entity.Code == code)
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

        public IEnumerable<CoursePolicy> GetCoursePolicies(string code)
        {
            var policies = context.CoursePolicies
                    .Select(s => new {
                        Policy = s,
                        details = s.Details
                    })
                    .Where(o => o.Policy.CourseCode == code).ToList() as IEnumerable<CoursePolicy>;
            return policies;
        }

        public async Task<bool> AddPolicyAsync(string code, CoursePolicy coursePolicy)
        {
            context.CoursePolicies.Add(coursePolicy);
            var course = Entity.FirstOrDefault(c => c.Code == code);
            course.Policies.Add(coursePolicy);
            await context.SaveChangesAsync();
            return true;
        }
    }
}