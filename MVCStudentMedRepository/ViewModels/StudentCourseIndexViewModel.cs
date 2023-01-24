using System.ComponentModel;

namespace MVCStudentMedRepository.ViewModels
{
    public class StudentCourseIndexViewModel
    {
        public int Id { get; set; }
        public string Student { get; set; }
        public string Course { get; set; }
        public string Grade { get; set; } = "";
        public bool Completed { get; set; }
    }
}
