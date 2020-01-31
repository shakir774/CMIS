using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Domain.Repository.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        Course Get(string code);
        IEnumerable<CoursePolicy> GetCoursePolicies(string code);
        bool Remove(string code);
        bool Update(string code, Course entity);
        Task<bool> AddPolicyAsync(string code, CoursePolicy coursePolicy);
    }
}