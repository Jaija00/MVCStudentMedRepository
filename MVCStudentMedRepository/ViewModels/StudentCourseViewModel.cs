using MVCStudentMedRepository.Models;

namespace MVCStudentMedRepository.ViewModels
{
	public class StudentCourseViewModel
	{
		public Student Student { get; set; }
		public Course Course { get; set; }
		public StudentCourse StudentCourse { get; set; }
	}
}
