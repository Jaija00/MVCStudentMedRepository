using MVCStudentMedRepository.Models;

namespace MVCStudentMedRepository.Data
{
    public class StudentRepository : IStudent
    {
        private readonly ApplicationDbContext applicationDbContext;

        public StudentRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public IEnumerable<Student> GetAll()
        {
            return applicationDbContext.Students.OrderBy(x => x.LastName);
        }

        public Student GetById(int id)
        {
            return applicationDbContext.Students.FirstOrDefault(x => x.Id == id);
        }
    }
}
