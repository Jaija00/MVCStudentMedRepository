namespace MVCStudentMedRepository.Models
{
	public class Course
	{
		public int Id { get; set; }
		public string Name { get; set; } = "";
		public string Teacher { get; set; } = "";
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
	}
}
