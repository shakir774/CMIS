using Core.Entities;
using Domain.Dtos;
using Domain.Repository.Interfaces;
using Domain.Repository.Repositories;

namespace Domain.Services.Interfaces
{
    public interface IStudentService : IService<StudentDto, Student, IStudentRepository>
    {
        StudentDto Get(int id);
        bool Remove(int id);
        bool Update(int id, StudentDto studentDto);
    }
}