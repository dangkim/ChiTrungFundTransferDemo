using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ChiTrung.Domain.Models;
using ChiTrung.Infra.Data.Extensions;


namespace ChiTrung.Infra.Data.Mappings
{
    public class RTokenMap : IEntityTypeConfiguration<RToken>
    {
        public void Configure(EntityTypeBuilder<RToken> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.ClientId)
                .HasColumnType("varchar(256)")
                .IsRequired();

            builder.Property(a => a.RefreshToken)
                .HasColumnType("varchar(256)")
                .IsRequired();

            builder.Property(a => a.IsStop)
                .HasColumnType("bit")
                .IsRequired();

        }
    }
}