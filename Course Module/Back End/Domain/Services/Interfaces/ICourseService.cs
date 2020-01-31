using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Domain.Dtos;
using Domain.Repository.Interfaces;
using Domain.Repository.Repositories;
using Domain.Services.Service;

namespace Domain.Services.Interfaces
{
    public interface ICourseService : IService<CourseDto, Course, ICourseRepository>
    {
        CourseDto Get(string code);
        IEnumerable<CoursePolicyDto> GetCoursePolicies(string code);
        bool Remove(string code);
        bool Update(string code, CourseDto courseDto);
        Task<bool> AddPolicyAsync(string code, CoursePolicyDto coursePolicyDto);
    }
}