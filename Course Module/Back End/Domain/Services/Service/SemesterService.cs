using System.Collections.Generic;
using AutoMapper;
using Core.Entities;
using Domain.Dtos;
using Domain.Repository.Interfaces;
using Domain.Repository.Repositories;
using Domain.Services.Interfaces;

namespace Domain.Services.Service
{
    public class SemesterService : Service<SemesterDto, Semester, ISemesterRepository>, ISemesterService
    {
        public SemesterService(ISemesterRepository repository, IMapper mapper): base(repository, mapper)
        {
        }
        public SemesterDto Get(int id)
        {
            var semester = repository.Get(id);
            return mapper.Map<Semester, SemesterDto>(semester);
        }

        public IEnumerable<CourseDto> GetCourses(int semesterId)
        {
            var courses = repository.GetCourses(semesterId);
            return mapper.Map<IEnumerable<Course>, IEnumerable<CourseDto>>(courses);
        }

        public IEnumerable<StudentDto> GetStudents(int semesterId)
        {
            var students = repository.GetStudents(semesterId);
            return mapper.Map<IEnumerable<Student>, IEnumerable<StudentDto>>(students);
        }

        public bool Remove(int id)
        {
            return repository.Remove(id);
        }

        public bool Update(int id, SemesterDto semesterDto)
        {
            var semester = mapper.Map<SemesterDto, Semester>(semesterDto);
            return repository.Update(id, semester);
        }
    }
}