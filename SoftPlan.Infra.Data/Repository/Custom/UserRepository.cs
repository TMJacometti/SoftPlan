using SoftPlan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SoftPlan.Domain.Interfaces;

namespace SoftPlan.Infra.Data.Repository
{
    public partial class UserRepository : BaseRepository<User>, IUserRepository
    {
        public User Login(string Email, string Senha)
        {
            if (Email.Equals("thiago@tmjsistemas.com.br", StringComparison.OrdinalIgnoreCase) && Senha.Equals("123456"))
            {
                return new User()
                {
                    Email = "thiago@tmjsistemas.com.br",
                    Nome = "Thiago Mattar Jacometti",
                    Id = 1,
                    DataCadastro = DateTime.Now.AddDays(-10),
                    Password = "HDIU@#EHDFO**#$*()R@HDUIO"
                };
            }
            else
            {
                return null;
            }
        }
    }
}
