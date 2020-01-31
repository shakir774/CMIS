using AutoMapper;
using Core.Entities;
using Domain.Dtos;
using Domain.Repository.Interfaces;
using Domain.Repository.Repositories;
using Domain.Services.Interfaces;

namespace Domain.Services.Service
{
    public class StudentService : Service<StudentDto, Student, IStudentRepository>, IStudentService
    {
        public StudentService(IStudentRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
        public StudentDto Get(int id)
        {
            Student student = repository.Get(id);
            return mapper.Map<Student, StudentDto>(student);
        }

        public bool Remove(int id)
        {
            return repository.Remove(id);
        }

        public bool Update(int id, StudentDto studentDto)
        {
            var student = mapper.Map<StudentDto, Student>(studentDto);
            return repository.Update(id, student);
        }
    }
}