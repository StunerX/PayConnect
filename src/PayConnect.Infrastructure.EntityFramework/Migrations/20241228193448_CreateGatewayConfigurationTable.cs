using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayConnect.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class CreateGatewayConfigurationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GatewayConfiguration",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MerchantId = table.Column<Guid>(type: "uuid", nullable: false),
                    PaymentGatewayId = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    IsSensitive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GatewayConfiguration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GatewayConfiguration_Merchant_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "Merchant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GatewayConfiguration_PaymentGateway_PaymentGatewayId",
                        column: x => x.PaymentGatewayId,
                        principalTable: "PaymentGateway",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GatewayConfiguration_MerchantId_PaymentGatewayId_Key",
                table: "GatewayConfiguration",
                columns: new[] { "MerchantId", "PaymentGatewayId", "Key" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GatewayConfiguration_PaymentGatewayId",
                table: "GatewayConfiguration",
                column: "PaymentGatewayId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GatewayConfiguration");
        }
    }
}
