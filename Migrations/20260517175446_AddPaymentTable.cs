using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayBridge.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "payment_id",
                table: "milestones",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    released_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    reference = table.Column<string>(type: "text", nullable: true),
                    metadata = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_payments", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_milestones_payment_id",
                table: "milestones",
                column: "payment_id");

            migrationBuilder.AddForeignKey(
                name: "fk_milestones_payments_payment_id",
                table: "milestones",
                column: "payment_id",
                principalTable: "payments",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_milestones_payments_payment_id",
                table: "milestones");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropIndex(
                name: "ix_milestones_payment_id",
                table: "milestones");

            migrationBuilder.DropColumn(
                name: "payment_id",
                table: "milestones");
        }
    }
}
