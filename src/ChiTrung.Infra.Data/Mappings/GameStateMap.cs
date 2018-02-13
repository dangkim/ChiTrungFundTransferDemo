using ChiTrung.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChiTrung.Infra.Data.Mappings
{
    public class GameStateMap : IEntityTypeConfiguration<GameState>
    {
        public void Configure(EntityTypeBuilder<GameState> builder)
        {
            builder.HasKey(e => new { e.MerchantId, e.MemberId, e.GameId });

            builder.Property(e => e.MerchantId)
                .HasColumnName("MerchantID")
                .HasMaxLength(128);

            builder.Property(e => e.MemberId)
                .HasColumnName("MemberID")
                .HasMaxLength(128);

            builder.Property(e => e.GameId)
                .HasColumnName("GameID")
                .HasMaxLength(128);
        }
    }
}
