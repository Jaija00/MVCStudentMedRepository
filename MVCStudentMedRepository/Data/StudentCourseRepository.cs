using MVCStudentMedRepository.Models;

namespace MVCStudentMedRepository.Data
{
    public class StudentCourseRepository : IStudentCourse
    {
        private readonly ApplicationDbContext applicationDbContext;

        public StudentCourseRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public StudentCourse Create(StudentCourse studentCourse)
        {
            applicationDbContext.Add(studentCourse);
            applicationDbContext.SaveChanges();
            return studentCourse;
        }
        public StudentCourse Update(StudentCourse studentCourse)
        {
            applicationDbContext.Update(studentCourse);
            applicationDbContext.SaveChanges();
            return studentCourse;
        }

        public void Delete(StudentCourse studentCourse)
        {
            applicationDbContext.Remove(studentCourse);
            applicationDbContext.SaveChanges();
        }

        public IEnumerable<StudentCourse> GetAll()
        {
            return applicationDbContext.StudentCourses.OrderBy(c => c.Id);
        }

        public StudentCourse GetById(int id)
        {
            return applicationDbContext.StudentCourses.FirstOrDefault(x => x.Id == id);
        }

    }
}
