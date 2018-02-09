using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ChiTrung.Domain.Models;
using ChiTrung.Infra.Data.Extensions;


namespace ChiTrung.Infra.Data.Mappings
{
    public class ScheduleMap : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(e => e.ScheduleId);

            builder.Ignore(e => e.Id);

            builder.Property(e => e.ScheduleId)
                .IsRequired();

            builder.Property(e => e.EmployeeId)
                .IsRequired();

            builder.Property(e => e.From)
                .IsRequired();

            builder.Property(e => e.To)
                .IsRequired();

            builder.Property(e => e.IsDeleted)
                .HasColumnType("bit")
                .IsRequired();
        }
    }
}