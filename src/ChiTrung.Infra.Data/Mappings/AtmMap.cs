using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ChiTrung.Domain.Models;
using ChiTrung.Infra.Data.Extensions;


namespace ChiTrung.Infra.Data.Mappings
{
    public class AtmMap : IEntityTypeConfiguration<Atm>
    {
        public void Configure(EntityTypeBuilder<Atm> builder)
        {
            builder.HasKey(a => a.AtmCode);

            builder.Ignore(a => a.Id);

            builder.Property(a => a.AtmCode)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(a => a.BankCode)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(a => a.AtmName)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}