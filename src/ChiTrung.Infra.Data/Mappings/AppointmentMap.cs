using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ChiTrung.Domain.Models;
using ChiTrung.Infra.Data.Extensions;


namespace ChiTrung.Infra.Data.Mappings
{
    public class AppointmentMap : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(d => d.AppointmentId);

            builder.Ignore(d => d.Id);

            builder.Property(d => d.AppointmentId)
                .IsRequired();

            builder.Property(d => d.DateCreated)
               .IsRequired();

            builder.Property(d => d.EmployeeCreated)
               .IsRequired();

            builder.Property(d => d.ClientId)
               .IsRequired();

            builder.Property(d => d.EmployeeId)
               .IsRequired();

            builder.Property(d => d.ClientName)
                .HasColumnType("varchar(128)")
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(d => d.ContactMobile)
                .HasColumnType("varchar(128)")
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(d => d.StartTime)
                .IsRequired();

            builder.Property(d => d.EndTimeExpected)
                .IsRequired();

            builder.Property(d => d.EndTime)
                .IsRequired();

            builder.Property(d => d.PriceExpected)
               .HasColumnType("float")
               .IsRequired();

            builder.Property(d => d.PriceFull)
               .HasColumnType("float")
               .IsRequired();

            builder.Property(d => d.Discount)
               .HasColumnType("float");

            builder.Property(d => d.PriceFinal)
               .HasColumnType("float")
               .IsRequired();

            builder.Property(d => d.Cancelled)
               .HasColumnType("bit")
               .IsRequired();

            builder.Property(d => d.CancellationReason)
               .HasColumnType("varchar(128)");

            builder.Property(e => e.IsDeleted)
               .HasColumnType("bit")
               .IsRequired();

        }
    }
}