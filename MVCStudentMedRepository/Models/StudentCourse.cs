using System.ComponentModel;

namespace MVCStudentMedRepository.Models
{
	public class StudentCourse
	{
		public int Id { get; set; }
		[DisplayName("Student")]
		public int StudentId { get; set; }
		[DisplayName("Course")]
		public int CourseId { get; set; }
		public string Grade { get; set; } = "";
		public bool Completed { get; set; }
	}
}
