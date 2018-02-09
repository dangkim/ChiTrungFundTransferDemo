using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ChiTrung.Domain.Models;
using ChiTrung.Infra.Data.Extensions;


namespace ChiTrung.Infra.Data.Mappings
{
    public class ServiceBookedMap : IEntityTypeConfiguration<ServiceBooked>
    {
        public void Configure(EntityTypeBuilder<ServiceBooked> builder)
        {
            builder.HasKey(e => e.ServiceBookedId);

            builder.Ignore(e => e.Id);

            builder.Property(e => e.ServiceBookedId)
                .IsRequired();

            builder.Property(e => e.AppointmentId)
                .IsRequired();

            builder.Property(e => e.ServiceId)
                .IsRequired();

            builder.Property(e => e.Price)
                .HasColumnType("float")
                .IsRequired();

            builder.Property(e => e.IsDeleted)
                .HasColumnType("bit")
                .IsRequired();
        }
    }
}