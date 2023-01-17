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

		public Student Create(Student student)
		{
			applicationDbContext.Students.Add(student);
			applicationDbContext.SaveChanges();
			return student;
		}

		public void Delete(int id)
		{
			var student = applicationDbContext.Students.Find(id);
			applicationDbContext.Students.Remove(student);
			applicationDbContext.SaveChanges();
		}

		public Student Update(Student student)
		{
			applicationDbContext.Students.Update(student);
			applicationDbContext.SaveChanges();
			return student;
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
