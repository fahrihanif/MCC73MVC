using System.ComponentModel.DataAnnotations;

namespace MCC73MVC.Models
{
    public class Division
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        // Relasi
        public ICollection<Department> Departments { get; set; }
    }
}
