using MVCStudentMedRepository.Models;

namespace MVCStudentMedRepository.Data
{
    public interface IStudentCourse
    {
        StudentCourse GetById(int id);
        IEnumerable<StudentCourse> GetAll();
        StudentCourse Create(StudentCourse studentCourse);
        void Delete(StudentCourse studentCourse);
        StudentCourse Update(StudentCourse studentCourse);
    }
}
