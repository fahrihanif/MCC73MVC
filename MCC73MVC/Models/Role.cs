namespace MCC73MVC.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Relasi
        public ICollection<AccountRole> AccountRoles { get; set; }
    }
}
