using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ChiTrung.Domain.Models;
using ChiTrung.Infra.Data.Extensions;


namespace ChiTrung.Infra.Data.Mappings
{
    public class AccountMap : EntityTypeConfiguration<Account>
    {
        public override void Map(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.AccCode);

            builder.Ignore(a => a.Id);

            builder.Property(a => a.AccCode)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(a => a.CusId)
                .HasColumnName("CusId")
                .IsRequired();

            builder.Property(a => a.BankCode)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();

        }
    }
}