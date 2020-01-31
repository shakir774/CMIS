using System.Collections.Generic;
using Core.Entities;

namespace Domain.Repository.Interfaces
{
    public interface ILecturerRepository : IRepository<Lecturer>
    {
        Lecturer Get(int id);
        IEnumerable<LecturerCoursePolicy> GetLecturerCoursePolicies(int lecturerId);
        bool Remove(int id);
        bool Update(int id, Lecturer entity);
        bool AddLecturerCoursePolicies(int lecturerId, LecturerCoursePolicy policy);
        IEnumerable<Course> GetCourses(int id);
        bool AddCourse(string code, int id, int semesterId);
    }
}