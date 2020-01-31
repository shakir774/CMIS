using System.Collections.Generic;
using Core.Entities;

namespace Domain.Repository.Interfaces
{
    public interface ISemesterRepository : IRepository<Semester>
    {
        Semester Get(int id);
        IEnumerable<Student> GetStudents(int semesterId);
        IEnumerable<Course> GetCourses(int semesterId);
        bool Remove(int id);
        bool Update(int id, Semester entity);
    }
}