using Core.Entities;

namespace Domain.Repository.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        Student Get(int id);
        bool Remove(int id);
        bool Update(int id, Student entity);
    }
}