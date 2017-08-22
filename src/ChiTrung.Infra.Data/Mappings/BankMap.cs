using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ChiTrung.Domain.Models;
using ChiTrung.Infra.Data.Extensions;


namespace ChiTrung.Infra.Data.Mappings
{
    public class BankMap : EntityTypeConfiguration<Bank>
    {
        public override void Map(EntityTypeBuilder<Bank> builder)
        {
            builder.HasKey(b => b.BankCode);

            builder.Ignore(b => b.Id);

            builder.Property(b => b.BankCode)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(b => b.BankName)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}