using MCC73MVC.Contexts;
using MCC73MVC.Models;

namespace MCC73MVC.Repositories.Data
{
    public class DepartmentRepositories : GeneralRepository<MyContext, Department, int>
    {
        public DepartmentRepositories(MyContext context) : base(context)
        {
        }
    }
}
