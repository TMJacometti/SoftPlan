using SoftPlan.Domain.Entities;
using SoftPlan.Infra.Data.Repository;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftPlan.Service.Services
{
    public partial class UserService : BaseService<User>
    {
        private UserRepository repository = new UserRepository();

        public User Login(string CPF, string Senha)
        {
            return repository.Login(CPF, Senha);
        }
    }
}
