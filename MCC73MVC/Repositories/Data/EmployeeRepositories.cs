using MCC73MVC.Contexts;
using MCC73MVC.Models;
using MCC73MVC.ViewModels;

namespace MCC73MVC.Repositories.Data
{
    public class EmployeeRepositories : GeneralRepository<MyContext, Employee, string>
    {
        public MyContext _context;
        public EmployeeRepositories(MyContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<MEmployeeVM> MasterEmployee()
        {
            var results = (from e in _context.Employees
                           join d in _context.Departments on e.DepartmentId equals d.Id
                           join div in _context.Divisions on d.DivisionId equals div.Id
                           select new MEmployeeVM
                           {
                               NIK = e.NIK,
                               FullName = e.FirstName + " " + e.LastName,
                               Gender = e.Gender.ToString(),
                               Email = e.Email,
                               DepartmentName = d.Name,
                               DivisionName = div.Name,
                           }).ToList();

            return results;
        }
    }
}
