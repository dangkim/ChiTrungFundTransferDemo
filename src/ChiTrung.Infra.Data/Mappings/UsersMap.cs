using ChiTrung.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChiTrung.Infra.Data.Mappings
{
    public class UsersMap : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(e => new { e.MerchantId, e.MemberId });

            builder.Property(e => e.MerchantId)
                .HasColumnName("MerchantID")
                .HasMaxLength(128);

            builder.Property(e => e.MemberId)
                .HasColumnName("MemberID")
                .HasMaxLength(128);

            builder.Property(e => e.Country)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Currency)
                .IsRequired()
                .HasMaxLength(8);

            builder.Property(e => e.Language)
                .IsRequired()
                .HasMaxLength(8);

            builder.Property(e => e.Nickname)
                .IsRequired()
                .HasMaxLength(128);
        }
    }
}
