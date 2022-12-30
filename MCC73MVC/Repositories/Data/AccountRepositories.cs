using MCC73MVC.Contexts;
using MCC73MVC.Handlers;
using MCC73MVC.Models;
using MCC73MVC.ViewModels;

namespace MCC73MVC.Repositories.Data
{
    public class AccountRepositories : GeneralRepository<MyContext, Account, string>
    {
        private readonly MyContext _context;
        public AccountRepositories(MyContext context) : base(context)
        {
            _context = context;
        }

        public int Register(RegisterVM register)
        {
            register.NIK = GenerateNIK();

            if (!CheckEmailPhone(register.Email))
            {
                return 0; // Email atau Password sudah terdaftar
            }

            Division division = new Division()
            {
                Name = register.DivisionName
            };
            _context.Divisions.Add(division);
            _context.SaveChanges();

            Department department = new Department()
            {
                Name = register.DepartmentName,
                DivisionId = division.Id
            };
            _context.Departments.Add(department);
            _context.SaveChanges();

            _context.Employees.Add(new Employee()
            {
                NIK = register.NIK,
                FirstName = register.FirstName,
                LastName = register.LastName,
                Gender = register.Gender,
                Email = register.Email,
                DepartmentId = department.Id
            });
            _context.SaveChanges();

            _context.Accounts.Add(new Account()
            {
                NIK = register.NIK,
                Password = Hashing.HashPassword(register.Password),
            });
            _context.SaveChanges();

            _context.AccountRoles.Add(new AccountRole()
            {
                AccountNIK = register.NIK,
                RoleId = 1
            });
            _context.SaveChanges();

            return 1;
        }

        public int Login(LoginVM login)
        {
            var result = _context.Accounts.Join(_context.Employees, a => a.NIK, e => e.NIK, (a, e) =>
            new LoginVM
            {
                Email = e.Email,
                Password = a.Password
            }).SingleOrDefault(c => c.Email == login.Email);

            if (result == null)
            {
                return 0; // Email Tidak Terdaftar
            }
            if (!Hashing.ValidatePassword(login.Password, result.Password))
            {
                return 1; // Password Salah
            }
            return 2; // Email dan Password Benar
        }

        private bool CheckEmailPhone(string email)
        {
            var duplicate = _context.Employees.Where(s => s.Email == email).ToList();

            if (duplicate.Any())
            {
                return false; // Email atau Password sudah ada
            }
            return true; // Email dan Password belum terdaftar
        }

        private string GenerateNIK()
        {
            var empCount = _context.Employees.OrderByDescending(e => e.NIK).FirstOrDefault();

            if (empCount == null)
            {
                return "x1111";
            }
            string NIK = empCount.NIK.Substring(1, 4);
            return Convert.ToString("x" + (Convert.ToInt32(NIK) + 1));
        }

        public List<string> UserRoles(string email)
        {
            var getNIK = _context.Employees.SingleOrDefault(e => e.Email == email).NIK;
            var getRoles = _context.AccountRoles.Where(ar => ar.AccountNIK == getNIK)
                                                .Join(_context.Roles, ar => ar.RoleId, r => r.Id, (ar, r) => r.Name)
                                                .ToList();

            return getRoles;
        }
    }
}
