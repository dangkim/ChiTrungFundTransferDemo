using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ChiTrung.Domain.Models;
using ChiTrung.Infra.Data.Extensions;


namespace ChiTrung.Infra.Data.Mappings
{
    public class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        public override void Map(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.EmployeeId);

            builder.Ignore(e => e.Id);

            builder.Property(e => e.EmployeeId)
                .IsRequired();

            builder.Property(e => e.FirstName)
                .HasColumnType("varchar(64)")
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(e => e.LastName)
                .HasColumnType("varchar(64)")
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(e => e.IsDeleted)
                .HasColumnType("bit")
                .IsRequired();
        }
    }
}