using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Petshop.Domain.Entities;

namespace Petshop.Infra.Configurations
{
    internal class PetConfiguration: IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable("pets");

            builder.HasKey(e => e.PetId);

            builder.Property(e => e.PetId)
                .HasColumnName("PetId")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                .HasColumnName("Name")
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(e => e.Breed)
                .HasColumnName("Breed")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Type)
                .HasColumnName("Type")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(e => e.Size)
                .HasColumnName("Size")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(e => e.BirthDate)
                .HasColumnName("BirthDate")
                .HasColumnType("date");

            builder.Property(e => e.Observations)
                .HasColumnName("Observations")
                .HasColumnType("text");

            builder.Property(e => e.CustomerId)
                .HasColumnName("CustomerId")
                .IsRequired();

            builder.Property(e => e.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
