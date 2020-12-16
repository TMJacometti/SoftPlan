using SoftPlan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftPlan.Domain.Interfaces
{
    public partial interface IUserRepository : IRepository<User>
    {
        User Login(string Email, string Senha);
    }
}
