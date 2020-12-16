using System;
using System.Collections.Generic;
using System.Text;

namespace SoftPlan.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}

