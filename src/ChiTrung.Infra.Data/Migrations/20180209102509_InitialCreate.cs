using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ChiTrung.Infra.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameEvents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Event = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameID = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    MemberID = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    MerchantID = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    TransactionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameState",
                columns: table => new
                {
                    MerchantID = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    MemberID = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    GameID = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Payload = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameState", x => new { x.MerchantID, x.MemberID, x.GameID });
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    MerchantID = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    MemberID = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Language = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => new { x.MerchantID, x.MemberID });
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameEvents_TransactionID",
                table: "GameEvents",
                column: "TransactionID");

            migrationBuilder.CreateIndex(
                name: "IX_GameEvents_MerchantID_MemberID_GameID",
                table: "GameEvents",
                columns: new[] { "MerchantID", "MemberID", "GameID" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameEvents");

            migrationBuilder.DropTable(
                name: "GameState");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
