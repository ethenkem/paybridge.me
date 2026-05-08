using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayBridge.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentAccountTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_milestone_contracts_contract_id",
                table: "milestone");

            migrationBuilder.DropPrimaryKey(
                name: "pk_milestone",
                table: "milestone");

            migrationBuilder.RenameTable(
                name: "milestone",
                newName: "milestones");

            migrationBuilder.RenameIndex(
                name: "ix_milestone_contract_id",
                table: "milestones",
                newName: "ix_milestones_contract_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_milestones",
                table: "milestones",
                column: "id");

            migrationBuilder.CreateTable(
                name: "payment_accounts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    bank_name = table.Column<string>(type: "text", nullable: false),
                    bank_code = table.Column<string>(type: "text", nullable: false),
                    account_number = table.Column<string>(type: "text", nullable: false),
                    account_balance = table.Column<decimal>(type: "numeric", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_payment_accounts", x => x.id);
                    table.ForeignKey(
                        name: "fk_payment_accounts_user_profiles_user_id",
                        column: x => x.user_id,
                        principalTable: "user_profiles",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_payment_accounts_user_id",
                table: "payment_accounts",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_milestones_contracts_contract_id",
                table: "milestones",
                column: "contract_id",
                principalTable: "contracts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_milestones_contracts_contract_id",
                table: "milestones");

            migrationBuilder.DropTable(
                name: "payment_accounts");

            migrationBuilder.DropPrimaryKey(
                name: "pk_milestones",
                table: "milestones");

            migrationBuilder.RenameTable(
                name: "milestones",
                newName: "milestone");

            migrationBuilder.RenameIndex(
                name: "ix_milestones_contract_id",
                table: "milestone",
                newName: "ix_milestone_contract_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_milestone",
                table: "milestone",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_milestone_contracts_contract_id",
                table: "milestone",
                column: "contract_id",
                principalTable: "contracts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
