using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPlan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftPlan.Infra.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(c => c.Id).HasName("User_Id");

            builder.Property(c => c.DataCadastro)
                 .HasColumnName("DataCadastro").HasDefaultValueSql("GETDATE()")
                 .HasColumnType("DATETIME");

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("VARCHAR(150)");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("VARCHAR(250)");

            builder.Property(c => c.Password)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("VARCHAR(50)");
        }
    }
}
