using MVCStudentMedRepository.Models;

namespace MVCStudentMedRepository.Data
{
	public interface ICourse
	{
		Course GetById(int id);
		IEnumerable<Course> GetAll();
		Course Create(Course course);
		void Delete(int id);
		Course Update(Course course);
	}
}
