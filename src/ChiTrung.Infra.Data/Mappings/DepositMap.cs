using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ChiTrung.Domain.Models;
using ChiTrung.Infra.Data.Extensions;


namespace ChiTrung.Infra.Data.Mappings
{
    public class DepositMap : EntityTypeConfiguration<Deposit>
    {
        public override void Map(EntityTypeBuilder<Deposit> builder)
        {
            builder.HasKey(d => d.DepCode);

            builder.Ignore(d => d.Id);

            builder.Property(d => d.DepCode)
                .IsRequired();

            builder.Property(d => d.AccCode)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(d => d.CusId)
                .HasColumnName("CusId")
                .IsRequired();

            builder.Property(d => d.Amount)
                .HasColumnType("float")
                .IsRequired();

            builder.Property(d => d.WitCode);

        }
    }
}