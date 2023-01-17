using MVCStudentMedRepository.Models;

namespace MVCStudentMedRepository.Data
{
    public interface IStudent
    {
        Student GetById(int id);
        IEnumerable<Student> GetAll();
        Student Create(Student student);
        void Delete(int id);
        Student Update(Student student);
    }
}
