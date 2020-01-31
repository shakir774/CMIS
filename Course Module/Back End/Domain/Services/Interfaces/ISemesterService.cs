using System.Collections.Generic;
using Core.Entities;
using Domain.Dtos;
using Domain.Repository.Interfaces;
using Domain.Repository.Repositories;

namespace Domain.Services.Interfaces
{
    public interface ISemesterService : IService<SemesterDto, Semester, ISemesterRepository>
    {
        SemesterDto Get(int id);
        IEnumerable<StudentDto> GetStudents(int semesterId);
        IEnumerable<CourseDto> GetCourses(int semesterId);
        bool Remove(int id);
        bool Update(int id, SemesterDto semesterDto);
    }
}