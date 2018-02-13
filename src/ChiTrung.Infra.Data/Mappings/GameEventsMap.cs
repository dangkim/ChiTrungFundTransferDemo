using ChiTrung.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChiTrung.Infra.Data.Mappings
{
    public class GameEventsMap : IEntityTypeConfiguration<GameEvents>
    {
        public void Configure(EntityTypeBuilder<GameEvents> builder)
        {
            builder.Property(e => e.GameId)
                    .IsRequired()
                    .HasColumnName("GameID")
                    .HasMaxLength(128);

            builder.Property(e => e.MemberId)
                .IsRequired()
                .HasColumnName("MemberID")
                .HasMaxLength(128);

            builder.Property(e => e.MerchantId)
                .IsRequired()
                .HasColumnName("MerchantID")
                .HasMaxLength(128);

            builder.Property(e => e.TransactionId).HasColumnName("TransactionID");

            //Unique Constraint: Make sure all values in 3 columns are different.
            builder.HasIndex(e => new { e.MerchantId, e.MemberId, e.GameId }).IsUnique(true);

            builder.HasIndex(c => new { c.TransactionId });
        }
    }
}
