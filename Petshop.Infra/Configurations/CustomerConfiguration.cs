using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Petshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petshop.Infra.Configurations
{
    internal class CustomerConfiguration: IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customers");

            builder.HasKey(e => e.CustomerId);

            builder.Property(e => e.CustomerId)
                .HasColumnName("CustomerId")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                .HasColumnName("Name")
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(e => e.CellPhone)
                .HasColumnName("CellPhone")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(e => e.Email)
                .HasColumnName("Email")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Cpf)
                .HasColumnName("Cpf")
                .HasMaxLength(12)
                .IsRequired();

            builder.Property(e => e.BirthDate)
                .HasColumnName("BirthDate")
                .HasColumnType("date");


            builder.Property(e => e.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
