using System;
using System.Collections.Generic;
using System.Text;

namespace SoftPlan.Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }

        public virtual DateTime DataCadastro { get; set; }
}
}