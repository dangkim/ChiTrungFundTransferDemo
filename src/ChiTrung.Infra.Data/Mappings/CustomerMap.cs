using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ChiTrung.Domain.Models;
using ChiTrung.Infra.Data.Extensions;


namespace ChiTrung.Infra.Data.Mappings
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public override void Map(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(11)
                .IsRequired();

            //Unique Constraint: Make sure all values in two columns are different.
            builder.HasIndex(c => new { c.Name }).IsUnique(true);

            //Unique Constraint: Make sure all values in two columns are different.
            builder.HasIndex(c => new { c.Email }).IsUnique(true);
        }
    }
}