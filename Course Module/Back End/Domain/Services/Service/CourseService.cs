using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Domain.Dtos;
using Domain.Repository.Interfaces;
using Domain.Repository.Repositories;
using Domain.Services.Interfaces;

namespace Domain.Services.Service
{
    public class CourseService : Service<CourseDto, Course, ICourseRepository>, ICourseService
    {
        public CourseService(ICourseRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<bool> AddPolicyAsync(string code, CoursePolicyDto coursePolicyDto)
        {
            var coursePolicy = mapper.Map<CoursePolicyDto, CoursePolicy>(coursePolicyDto);
            return await repository.AddPolicyAsync(code, coursePolicy);
        }

        public CourseDto Get(string code)
        {
            var course = repository.Get(code);
            return mapper.Map<Course, CourseDto>(course);
        }
        public IEnumerable<CoursePolicyDto> GetCoursePolicies(string code)
        {
            var policies = repository.GetCoursePolicies(code);
            return mapper.Map<IEnumerable<CoursePolicy>, IEnumerable<CoursePolicyDto>>(policies);
        }
        public bool Remove(string code)
        {
            return repository.Remove(code);
        }

        public bool Update(string code, CourseDto courseDto)
        {
            var entity = mapper.Map<CourseDto, Course>(courseDto);
            return repository.Update(code, entity);
        }
    }
}