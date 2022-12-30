﻿using MCC73MVC.Contexts;
using MCC73MVC.Models;

namespace MCC73MVC.Repositories.Data
{
    public class RoleRepositories : GeneralRepository<MyContext, Role, int>
    {
        public RoleRepositories(MyContext context) : base(context)
        {
        }
    }
}
