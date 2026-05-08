using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayBridge.Migrations
{
    /// <inheritdoc />
    public partial class AddNewFieldsToContracts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_contracts_user_profiles_user_profile_user_id",
                table: "contracts");

            migrationBuilder.DropIndex(
                name: "ix_contracts_user_profile_user_id",
                table: "contracts");

            migrationBuilder.DropColumn(
                name: "user_profile_user_id",
                table: "contracts");

            migrationBuilder.AlterColumn<Guid>(
                name: "user_id",
                table: "contracts",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<Guid>(
                name: "client_id",
                table: "contracts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "link_token",
                table: "contracts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "contracts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_contracts_client_id",
                table: "contracts",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "ix_contracts_user_id",
                table: "contracts",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_contracts_user_profiles_client_id",
                table: "contracts",
                column: "client_id",
                principalTable: "user_profiles",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_contracts_user_profiles_user_id",
                table: "contracts",
                column: "user_id",
                principalTable: "user_profiles",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_contracts_user_profiles_client_id",
                table: "contracts");

            migrationBuilder.DropForeignKey(
                name: "fk_contracts_user_profiles_user_id",
                table: "contracts");

            migrationBuilder.DropIndex(
                name: "ix_contracts_client_id",
                table: "contracts");

            migrationBuilder.DropIndex(
                name: "ix_contracts_user_id",
                table: "contracts");

            migrationBuilder.DropColumn(
                name: "client_id",
                table: "contracts");

            migrationBuilder.DropColumn(
                name: "link_token",
                table: "contracts");

            migrationBuilder.DropColumn(
                name: "status",
                table: "contracts");

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "contracts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "user_profile_user_id",
                table: "contracts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_contracts_user_profile_user_id",
                table: "contracts",
                column: "user_profile_user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_contracts_user_profiles_user_profile_user_id",
                table: "contracts",
                column: "user_profile_user_id",
                principalTable: "user_profiles",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
