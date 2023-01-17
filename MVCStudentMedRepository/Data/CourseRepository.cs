using MVCStudentMedRepository.Models;

namespace MVCStudentMedRepository.Data
{
	public class CourseRepository : ICourse
	{
		private readonly ApplicationDbContext applicationDbContext;

		public CourseRepository(ApplicationDbContext applicationDbContext)
		{
			this.applicationDbContext = applicationDbContext;
		}
		public Course Create(Course course)
		{
			applicationDbContext.Course.Add(course);
			applicationDbContext.SaveChanges();
			return course;
		}

		public void Delete(int id)
		{
			var course = applicationDbContext.Course.Find(id);
			applicationDbContext.Course.Remove(course);
			applicationDbContext.SaveChanges();
		}

		public Course Update(Course course)
		{
			applicationDbContext.Course.Update(course);
			applicationDbContext.SaveChanges();
			return course;
		}

		public IEnumerable<Course> GetAll()
		{
			return applicationDbContext.Course.OrderBy(c => c.Name);
		}

		public Course GetById(int id)
		{
			return applicationDbContext.Course.FirstOrDefault(c => c.Id == id);
		}
	}
}
