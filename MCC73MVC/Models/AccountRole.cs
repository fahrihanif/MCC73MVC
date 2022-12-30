using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCC73MVC.Models
{
    public class AccountRole
    {
        [Key]
        public int Id { get; set; }
        public string AccountNIK { get; set; }
        public int RoleId { get; set; }

        // Relasi
        [ForeignKey("AccountNIK")]
        public Account Account{ get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}
