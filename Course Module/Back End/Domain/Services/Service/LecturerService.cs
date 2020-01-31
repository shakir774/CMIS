using System.Collections.Generic;
using AutoMapper;
using Core.Entities;
using Domain.Dtos;
using Domain.Repository.Interfaces;
using Domain.Repository.Repositories;
using Domain.Services.Interfaces;

namespace Domain.Services.Service
{
    public class LecturerService : Service<LecturerDto, Lecturer, ILecturerRepository>, ILecturerService
    {
        public LecturerService(ILecturerRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public bool AddCourse(string code, int id, int semesterId)
        {
            return repository.AddCourse(code, id, semesterId);
        }

        public bool AddLecturerCoursePolicies(int lecturerId, LecturerCoursePolicyDto policyDto)
        {
            var coursePolicy = mapper.Map<LecturerCoursePolicyDto, LecturerCoursePolicy>(policyDto);
            return repository.AddLecturerCoursePolicies(lecturerId, coursePolicy);
        }

        public LecturerDto Get(int id)
        {
            var lecturer = repository.Get(id);
            return mapper.Map<Lecturer, LecturerDto>(lecturer);
        }

        public IEnumerable<CourseDto> GetCourses(int id)
        {
            var courses = repository.GetCourses(id);
            return mapper.Map<IEnumerable<Course>, IEnumerable<CourseDto>>(courses);
        }

        public IEnumerable<LecturerCoursePolicyDto> GetLecturerCoursePolicies(int lecturerId)
        {
            var policies = repository.GetLecturerCoursePolicies(lecturerId);
            return mapper.Map<IEnumerable<LecturerCoursePolicy>, IEnumerable<LecturerCoursePolicyDto>>(policies);
        }

        public bool Remove(int id)
        {
            return repository.Remove(id);
        }

        public bool Update(int id, LecturerDto lecturerDto)
        {
            var lecturer = mapper.Map<LecturerDto, Lecturer>(lecturerDto);
            return repository.Update(id, lecturer);
        }
    }
}