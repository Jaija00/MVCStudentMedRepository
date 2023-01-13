using MVCStudentMedRepository.Models;

namespace MVCStudentMedRepository.Data
{
    public interface IStudent
    {
        Student GetById(int id);
        IEnumerable<Student> GetAll();
    }
}
