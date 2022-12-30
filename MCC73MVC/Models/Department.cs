using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCC73MVC.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int DivisionId { get; set; }

        //Relasi
        [ForeignKey("DivisionId")]
        public Division Division { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
