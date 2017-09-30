using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ChiTrung.Domain.Models;
using ChiTrung.Infra.Data.Extensions;


namespace ChiTrung.Infra.Data.Mappings
{
    public class ClientMap : EntityTypeConfiguration<Client>
    {
        public override void Map(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(e => e.ClientId);

            builder.Ignore(e => e.Id);

            builder.Property(e => e.ClientId)
                .IsRequired();

            builder.Property(e => e.ClientName)
                .HasColumnType("varchar(128)")
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(e => e.ContactMobile)
                .HasColumnType("varchar(128)")
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(e => e.ContactMail)
                .HasColumnType("varchar(128)");

            builder.Property(e => e.IsDeleted)
                .HasColumnType("bit")
                .IsRequired();
        }
    }
}