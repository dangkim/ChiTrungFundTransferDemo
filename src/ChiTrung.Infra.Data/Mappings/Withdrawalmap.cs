using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ChiTrung.Domain.Models;
using ChiTrung.Infra.Data.Extensions;


namespace ChiTrung.Infra.Data.Mappings
{
    public class WithdrawalMap : EntityTypeConfiguration<Withdrawal>
    {
        public override void Map(EntityTypeBuilder<Withdrawal> builder)
        {
            builder.HasKey(w => w.WitCode);

            builder.Ignore(w => w.Id);

            builder.Property(w => w.WitCode)
                .IsRequired();

            builder.Property(w => w.AccCode)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(w => w.Amount)
                .HasColumnType("float")
                .IsRequired();

            builder.Property(w => w.AtmCode)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20);

        }
    }
}