namespace WebAPIProj.Models
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public bool Permanent { get; set; }
        public string DepartmentName { get; set; }
        public List<string> Skills { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
