using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCC73MVC.Models
{
    public class Employee
    {
        [Key]
        public string NIK { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }

        // Relasi
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public Account Account { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
