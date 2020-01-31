using System.Collections.Generic;
using Core.Entities;
using Domain.Dtos;
using Domain.Repository.Interfaces;
using Domain.Repository.Repositories;

namespace Domain.Services.Interfaces
{
    public interface ILecturerService : IService<LecturerDto, Lecturer, ILecturerRepository>
    {
        LecturerDto Get(int id);
        IEnumerable<LecturerCoursePolicyDto> GetLecturerCoursePolicies(int lecturerId);
        bool Remove(int id);
        bool Update(int id, LecturerDto lecturerDto);
        bool AddLecturerCoursePolicies(int lecturerId, LecturerCoursePolicyDto policyDto);
        IEnumerable<CourseDto> GetCourses(int id);
        bool AddCourse(string code, int id, int semesterId);
    }
}