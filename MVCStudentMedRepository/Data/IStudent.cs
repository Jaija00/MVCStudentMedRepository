using MVCStudentMedRepository.Models;

namespace MVCStudentMedRepository.Data
{
    public interface IStudent
    {
        Student GetById(int id);
        IEnumerable<Student> GetAll();
        Student Add(Student student);
        void Delete(int id);
        Student Edit(Student student);
    }
}
