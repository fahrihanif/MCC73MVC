
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCC73MVC.Models
{
    public class Account
    {
        [Key]
        public string NIK { get; set; }
        public string Password { get; set; }

        // Relasi
        public Employee Employee { get; set; }
        public ICollection<AccountRole> AccountRoles { get; set; }
    }
}
